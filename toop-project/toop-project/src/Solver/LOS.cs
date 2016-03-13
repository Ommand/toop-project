using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;
using toop_project.src.Logging;
using toop_project.src.Preconditioner;

namespace toop_project.src.Solver
{
    class LOS : ISolver
    {
        public override Vector Solve(IPreconditioner matrix, Vector rightPart, Vector initialSolution,
                ILogger logger, ISolverLogger solverLogger, ISolverParametrs solverParametrs)
        {
            if (solverParametrs is LOSParametrs)
            {
                LOSParametrs GZParametrs = solverParametrs as LOSParametrs;

                Vector x, r, z, p;
                double alpha, betta;
                int size, k;
                double Residual, pnorm;
                Vector Ax;
                Vector LAU, Ur;

                size = initialSolution.Size;
                x = new Vector(size);
                r = new Vector(size);
                z = new Vector(size);
                p = new Vector(size);
                Ax = new Vector(size);
                LAU = new Vector(size);
                Ur = new Vector(size);

                Ax = matrix.SourceMatrix.Multiply(x);

                x = initialSolution;
                r = matrix.SSolve(rightPart - Ax);
                z = matrix.QSolve(r);
                p = matrix.SSolve(matrix.SourceMatrix.Multiply(z));

                r = Ax - rightPart;
                var rpnorm = rightPart.Norm();
                Residual = r.Norm() / rpnorm;

                solverLogger.AddIterationInfo(0, Residual);
                for (k = 1; k <= solverParametrs.MaxIterations && Residual > solverParametrs.Epsilon; k++)
                {
                    pnorm = p.Norm();

                    alpha = Math.Sqrt((p * r)) / pnorm;
                    x = x + z * alpha;
                    r = r - p * alpha;

                    Ur = matrix.QSolve(r);
                    LAU = matrix.SourceMatrix.Multiply(Ur);
                    LAU = matrix.SSolve(LAU);

                    betta = -Math.Sqrt(p * LAU) / pnorm;
                    z = Ur + z * betta;
                    p = LAU + p * betta;

                    Residual = r.Norm() / rpnorm;
                    solverLogger.AddIterationInfo(k, Residual);

                }

                return x;
            }
            else {
                logger.Error("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in GaussSeidel");
                throw new Exception("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in GaussSeidel");

            }
        }


        public override Type Type { get { return Type.LOS; } }
    }
}
