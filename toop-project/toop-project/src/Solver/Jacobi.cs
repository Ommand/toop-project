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
    public class Jacobi : ISolver
    {

        Vector ISolver.Solve(BaseMatrix matrix, Vector rightPart, Vector initialSolution,
                                     Logger logger, double epsilon, int maxIterations, double optionalRelaxationParameter)
        {
            Vector x, r, diagonal;
            int size, k;
            double relativeResidual, w;
            Vector DUx, DLx, Db, Dx, Lx, Ux;

            size = initialSolution.Size;
            x = new Vector(size);
            r = new Vector(size);
            diagonal = new Vector(size);

            x = initialSolution;
            w = optionalRelaxationParameter;
            diagonal = matrix.Diagonal;

            Dx = diagonalMult(diagonal, x);
            Lx = matrix.LMult(x, false);
            Ux = matrix.UMult(x, false);
            r = Lx + Dx + Ux - rightPart;
            relativeResidual = r.Norm() / rightPart.Norm();

            Db = diagonalSolve(diagonal, rightPart);

            logger.AddIterationInfo(0, relativeResidual);

            for(k = 1; k <= maxIterations && relativeResidual > epsilon; k++)
            {
                DUx = diagonalSolve(diagonal, Ux);
                DLx = diagonalSolve(diagonal, Lx);

                x = (Db - DUx - DLx) * w + x * (1 - w);

                Dx = diagonalMult(diagonal, x);
                Lx = matrix.LMult(x, false);
                Ux = matrix.UMult(x, false);
                r = Lx + Dx + Ux - rightPart;
                relativeResidual = r.Norm() / rightPart.Norm();

                logger.AddIterationInfo(k, relativeResidual);
            }

            return x;
        }

        public string Name
        {
            get
            {
                return "Jacobi";
            }
        }

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
