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
    public class Jacobi : ISolver
    {
        public override Vector Solve(IPreconditioner matrix, Vector rightPart, Vector initialSolution,
                                     ILogger logger,  ISolverLogger solverLogger, ISolverParametrs solverParametrs)
        {
            JacobiParametrs JacParametrs = solverParametrs as JacobiParametrs;

            if (JacParametrs != null)
            {
                Vector x, r, diagonal;
                int size, k;
                double relativeResidual, w, rightPartNorm;
                Vector Db, Dx, Lx, Ux, DULx;

                size = initialSolution.Size;
                x = new Vector(size);
                r = new Vector(size);
                diagonal = new Vector(size);

                x = initialSolution;
                w = JacParametrs.Relaxation;
                diagonal = matrix.SourceMatrix.Diagonal;
                rightPartNorm = rightPart.Norm();

                Dx = Vector.Mult(diagonal, x);
                Lx = matrix.SourceMatrix.LMult(x, false);
                Ux = matrix.SourceMatrix.UMult(x, false);
                r = Lx + Dx + Ux - rightPart;
                relativeResidual = r.Norm() / rightPartNorm;

                if (System.Double.IsInfinity(relativeResidual))
                {
                    logger.Error("Residual is infinity. It is impossible to solve this SLAE by Jacobi.");
                    return x;
                }

                if (System.Double.IsNaN(relativeResidual))
                {
                    logger.Error("Residual is NaN. It is impossible to solve this SLAE by Jacobi.");
                    return x;
                }

                Db = Vector.Division(rightPart, diagonal);

                solverLogger.AddIterationInfo(0, relativeResidual);

                for (k = 1; k <= solverParametrs.MaxIterations && relativeResidual > solverParametrs.Epsilon; k++)
                {
                    DULx = Vector.Division(Ux + Lx, diagonal);

                    x = (Db - DULx) * w + x * (1 - w);

                    Dx = Vector.Mult(diagonal, x);
                    Lx = matrix.SourceMatrix.LMult(x, false);
                    Ux = matrix.SourceMatrix.UMult(x, false);
                    r = Lx + Dx + Ux - rightPart;
                    relativeResidual = r.Norm() / rightPartNorm;

                    if (System.Double.IsInfinity(relativeResidual))
                    {
                        logger.Error("Residual is infinity. It is impossible to solve this SLAE by Jacobi.");
                        return x;
                    }

                    if (System.Double.IsNaN(relativeResidual))
                    {
                        logger.Error("Residual is NaN. It is impossible to solve this SLAE by Jacobi.");
                        return x;
                    }

                    solverLogger.AddIterationInfo(k, relativeResidual);
                }

                return x;
            }
            else {
                logger.Error("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in Jacobi");
                throw new Exception("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in Jacobi");
             
            }
        }

        public override Type Type { get { return Type.Jacobi; } }
    }
}
