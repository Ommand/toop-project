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
    interface ISolver
    {
   Vector Solve(BaseMatrix matrix, Vector rightPart, Vector initialSolution,
                        Logger logger, double epsilon, int maxIterations, double optionalRelaxationParameter = 1);
        string Name { get; }
    }

    public class Jacobi : ISolver
    {

       Vector ISolver.Solve(BaseMatrix matrix, Vector rightPart, Vector initialSolution,
                                    Logger logger, double epsilon, int maxIterations, double optionalRelaxationParameter)                    
        {
            Vector x, r, diagonal;
            int size, k;
            double relativeResidual, w;
            Vector DUx, DFx, Db;

            size = initialSolution.Size;           
            x = new Vector(size);
            r = new Vector(size);
            diagonal = new Vector(size);

            k = 0;
            x = initialSolution;
            w = optionalRelaxationParameter;
            diagonal = matrix.Diagonal;
            r = matrix.Multiply(x) + rightPart * (-1);
            relativeResidual = r.Norm() / rightPart.Norm();
            Db = diagonalSolve(diagonal, rightPart);

            logger.AddIterationInfo(k, relativeResidual);
            
            while (k <= maxIterations && relativeResidual > epsilon)
            {
                k++;

                DUx = diagonalSolve(diagonal, matrix.UMult(x, false));
                DFx = diagonalSolve(diagonal, matrix.LMult(x, false));
                
                x = (DUx + DFx + Db) * w + x * (1 - w);

                r = matrix.Multiply(x) + rightPart * (-1);
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
    }
}
