using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Vector_;
using toop_project.src.Logging;
using toop_project.src.Preconditioner;

namespace toop_project.src.Solver
{
    public class GMRES : ISolver
    {
        public override Vector Solve(IPreconditioner matrix, Vector rightPart, Vector initialSolution,
                                     ILogger logger, ISolverLogger solverLogger, ISolverParametrs solverParametrs)
        {
            GMRESParameters GMRESParameters = solverParametrs as GMRESParameters;
            if (GMRESParameters != null)
            {
                Vector[] V, H;
                Vector residual, x, d, z, w, tmp;
                bool continueCalculations;
                double epsilon = GMRESParameters.Epsilon;
                int m = GMRESParameters.M;
                int maxIterations = GMRESParameters.MaxIterations;
                int n = rightPart.Size;

                x = initialSolution;
                residual = rightPart - matrix.SourceMatrix.Multiply(x);
                residual = matrix.SSolve(residual);
                double rightPartNorm = matrix.SSolve(rightPart).Norm();
                double residualNorm = residual.Norm();

                if (System.Double.IsInfinity(residualNorm / rightPartNorm))
                {
                    logger.Error("Residual is infinity. It is impossible to solve this SLAE by GMRES.");
                    return x;
                }

                if (System.Double.IsNaN(residualNorm / rightPartNorm))
                {
                    logger.Error("Residual is NaN. It is impossible to solve this SLAE by GMRES.");
                    return x;
                }

                x = matrix.QMultiply(initialSolution);

                V = new Vector[m];
                for (int i = 0; i < m; i++)
                    V[i] = new Vector(n);

                H = new Vector[m];
                for (int i = 0; i < m; i++)
                    H[i] = new Vector(m + 1);

                d = new Vector(m + 1);

                for (int k = 1; k <= maxIterations && residualNorm / rightPartNorm > epsilon; k++)
                {
                    d.Nullify();
                    V[0] = residual * (1.0 / residualNorm);

                    continueCalculations = true;
                    for (int j = 1; j <= m && continueCalculations; j++)
                    {
                        tmp = matrix.QSolve(V[j - 1]);
                        w = matrix.SSolve(matrix.SourceMatrix.Multiply(tmp));

                        for (int l = 1; l <= j; l++)
                        {
                            H[j - 1][l - 1] = V[l - 1] * w;
                            w = w - V[l - 1] * H[j - 1][l - 1];
                        }

                        H[j - 1][j] = w.Norm();
                        if (Math.Abs(H[j - 1][j]) < 1e-10)
                        {
                            m = j;
                            continueCalculations = false;
                        }
                        else
                        {
                            if(j != m)
                                V[j] = w * (1.0 / H[j - 1][j]);
                        }                       
                    }

                    d[0] = residualNorm;
                    z = solveMinSqrProblem(d, H, m);
                    x = x + multiplyMatrixVector(z, V);

                    tmp = rightPart - matrix.SourceMatrix.Multiply(matrix.QSolve(x));
                    residual = matrix.SSolve(tmp);
                    residualNorm = residual.Norm();

                    if (System.Double.IsInfinity(residualNorm / rightPartNorm))
                    {
                        logger.Error("Residual is infinity. It is impossible to solve this SLAE by GMRES.");
                        return x;
                    }

                    if (System.Double.IsNaN(residualNorm / rightPartNorm))
                    {
                        logger.Error("Residual is NaN. It is impossible to solve this SLAE by GMRES.");
                        return x;
                    }

                    solverLogger.AddIterationInfo(k, residualNorm / rightPartNorm);
                }

                return matrix.QSolve(x);                
            }
            else {
                logger.Error("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in GMRES");
                throw new Exception("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in GMRES");

            }
        }

        public override Type Type { get { return Type.GMRES; } }

        Vector solveMinSqrProblem(Vector d, Vector[] H, int m)
        {            
            int m2 = H.Length;
            Vector result = new Vector(m2);
            Vector[] H_previous, H2;
            Vector d1, d2;
            double ci, si, tmp;

            double[] tmp1, tmp2;
            tmp1 = new double[m];
            tmp2 = new double[m];
            double tmp11, tmp22;

            H_previous = new Vector[m2];
            for (int i = 0; i < m2; i++)
                H_previous[i] = H[i];

            H2 = new Vector[m];
            for (int i = 0; i < m; i++)
                H2[i] = new Vector(m);

            d1 = d;//размер m2+1
            d2 = new Vector(m);

            for (int i = 0; i < m; i++)
            {
                tmp = Math.Sqrt(H_previous[i][i] * H_previous[i][i] +
                                            H[i][i + 1] * H[i][i + 1]);
                ci = H_previous[i][i] / tmp;
                si = H[i][i + 1] / tmp;

            #region H_prev=R*H_prev
                //расчитываем заранее элементы строк, где блок синусов-косинусов
                for (int l = 0; l < m; l++)
                {
                    tmp1[l] = H_previous[l][i] * ci + H_previous[l][i + 1] * si;
                    tmp2[l] = -H_previous[l][i] * si + H_previous[l][i + 1] * ci;
                }

                //заполняем строки,где блок синусов-косинусов
                for (int l = 0; l < m; l++)
                {

                    H_previous[l][i] = tmp1[l];
                    H_previous[l][i + 1] = tmp2[l];
                }

            #endregion

            #region d1=R*d1
                //рассчитываем элементы вектора, где блок синусов-косинусов
                tmp11 = d1[i] * ci + d1[i + 1] * si;
                tmp22 = -d1[i] * si + d1[i + 1] * ci;

                //заполняем элементы вектора, где блок синусов-косинусов
                //остальные не изменяются
                d1[i] = tmp11;
                d1[i + 1] = tmp22;
            #endregion
            }

            //исключаем m+1-ю строку и m+1-й элемент
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < m; i++)
                    H2[j][i] = H_previous[j][i];
                d2[j] = d1[j];
            }

            //находим неизвестный вектор из СЛАУ H2*result=d2
            for (int i = m - 1; i >= 0; i--)
            {
                result[i] = d2[i];
                for (int j = i + 1; j < m; j++)
                {
                    result[i] -= result[j] * H2[j][i];
                }
                result[i] = result[i] / H2[i][i];
            }
            return result;
        }

        Vector multiplyMatrixVector(Vector vector, Vector[] matrix)
        {
            int n_lines = matrix[0].Size;
            int n_columns = matrix.Length;
            Vector result = new Vector(n_lines);
            result.Nullify();

            if(vector.Size == n_columns)
            {
                for (int j = 0; j < n_columns; j++)
                    for (int i = 0; i < n_lines; i++)
                        result[i] += matrix[j][i] * vector[j];
            }
            else
                throw new Exception("GMRES: Несовпадение длины вектора и числа столбцов матрицы");

            return result;
        }
    }
}
