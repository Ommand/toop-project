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

                x = matrix.QSolve(initialSolution);
                w = JacParametrs.Relaxation;
                diagonal = matrix.SourceMatrix.Diagonal;
                rightPartNorm = matrix.SSolve(rightPart).Norm();

                Dx = Vector.Mult(diagonal, x);
                Lx = matrix.SourceMatrix.LMult(x, false);
                Ux = matrix.SourceMatrix.UMult(x, false);
                r = matrix.SSolve(Lx + Dx + Ux - rightPart);
                relativeResidual = r.Norm() / rightPartNorm;

                Db = Vector.Division(matrix.SSolve(rightPart), matrix.SSolve(diagonal));

                solverLogger.AddIterationInfo(0, relativeResidual);

                for (k = 1; k <= solverParametrs.MaxIterations && relativeResidual > solverParametrs.Epsilon; k++)
                {
                    DULx = Vector.Division(Ux + Lx, diagonal);

                    x = matrix.SSolve((Db - DULx)) * w + x * (1 - w);

                    Dx = Vector.Mult(diagonal, x);
                    Lx = matrix.SourceMatrix.LMult(x, false);
                    Ux = matrix.SourceMatrix.UMult(x, false);
                    r = matrix.SSolve(Lx + Dx + Ux - rightPart);
                    relativeResidual = r.Norm() / rightPartNorm;

                    solverLogger.AddIterationInfo(k, relativeResidual);
                }

                return matrix.QMultiply(x);
            }
            else {
                logger.Error("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in Jacobi");
                throw new Exception("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in Jacobi");
             
            }
        }

        public override Type Type { get { return Type.Jacobi; } }
    }
}
