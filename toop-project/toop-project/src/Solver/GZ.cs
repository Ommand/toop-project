using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Vector_;
using toop_project.src.Logging;

namespace toop_project.src.Solver
{
    class GZ: ISolver
    {
        public override Vector Solve(BaseMatrix matrix, Vector rightPart, Vector initialSolution,
                                    ILogger logger, ISolverLogger solverLogger, ISolverParametrs solverParametrs)
        {
            if (solverParametrs is GZParametrs)
            {
                GZParametrs GZParametrs = solverParametrs as GZParametrs;

                Vector x,xnext, r, di;
                int size, k;
                double Residual, w;
                Vector DEx, DFx, DEb, Dx, Fx, Ex;

                size = initialSolution.Size;
                x = new Vector(size);
                xnext = new Vector(size);
                r = new Vector(size);
                di = new Vector(size);

                x = initialSolution;
                w = GZParametrs.Relaxation;
                di = matrix.Diagonal;

                Dx = diagonalMult(di, x);
                Fx = matrix.LMult(x, false)*(-1);
                Ex = matrix.UMult(x, false)*(-1);
                r = Fx + Dx + Ex - rightPart;
                Residual = r.Norm() / rightPart.Norm();

                DEb = diagonalSolve(di, rightPart);

                solverLogger.AddIterationInfo(0, Residual);

                for (k = 1; k <= solverParametrs.MaxIterations && Residual > solverParametrs.Epsilon; k++)
                {
                    DEx = diagonalSolve(di, Ex);
                    DFx = diagonalSolve(di, Fx);

                    xnext = (DEb - DEx - DFx) * w + x * (1 - w);

                    Dx = diagonalMult(di, xnext);
                    Fx = matrix.LMult(xnext, false)*(-1);
                    Ex = matrix.UMult(x, false) * (-1);
                    r = Fx + Dx + Ex - rightPart;
                    Residual = r.Norm() / rightPart.Norm();

                    solverLogger.AddIterationInfo(k, Residual);

                    x = xnext;
                }

                return xnext;
            }
            else {
                logger.Error("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in GaussSeidel");
                throw new Exception("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in GaussSeidel");

            }
        }

       public Type Type { get { return Type.Seidel; } private set { } }

        Vector diagonalSolve(Vector diagonal, Vector vector)
        {
            int size = diagonal.Size;
            Vector result = new Vector(size);

            for (int i = 0; i < size; i++)
                result[i] = vector[i] / diagonal[i];

            return result;
        }
        Vector diagonalMult(Vector diagonal, Vector vector)
        {
            int size = diagonal.Size;
            Vector result = new Vector(size);

            for (int i = 0; i < size; i++)
                result[i] = vector[i] * diagonal[i];

            return result;
        }
    }
}
