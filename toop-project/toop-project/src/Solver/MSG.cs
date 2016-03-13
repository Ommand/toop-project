using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Preconditioner;
using toop_project.src.Vector_;
using toop_project.src.Logging;

namespace toop_project.src.Solver
{
    public class MSG : ISolver
    {
        public override Vector Solve(IPreconditioner matrix, Vector rightPart, Vector initialSolution, ILogger logger, ISolverLogger solverLogger, ISolverParametrs solverParametrs)
        {
            MSGParametrs ConGradParametrs = solverParametrs as MSGParametrs;

            if (ConGradParametrs==null)
            {
                logger.Error("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in MSG");
                throw new Exception("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in MSG");
            }
            else
            {
                //prestart
                int oIter = 0;
                double alpha, beta, oNev, bNev, scalRO,scaleRN;
                Vector x = initialSolution, rNew, rOld, z, ap, p;
                rOld =rightPart - matrix.SourceMatrix.Multiply(x);
                z = matrix.QSolve(matrix.SSolve(rOld));
                p = z;
                ap = matrix.SourceMatrix.Multiply(p);
                bNev =rightPart.Norm();
                oNev = rOld.Norm() / bNev;
                scalRO = z * rOld;
              //  x = matrix.QSolve(x);
                solverLogger.AddIterationInfo(oIter, oNev);//logger

                while (oIter < ConGradParametrs.MaxIterations && oNev > ConGradParametrs.Epsilon) 
                {

                    alpha = scalRO / (ap * p);
                    x = x + p * alpha;
                   // if (oIter % 100 == 0)
                   // rNew = matrix.QMultiply(rightPart - matrix.SMultiply(matrix.SourceMatrix.Multiply(x)));
                   // else
                    rNew = rOld - ap * alpha;
                    z= matrix.QSolve(matrix.SSolve(rNew));
                    scaleRN = z * rNew;
                    beta = scaleRN / scalRO;
                    scalRO = scaleRN;
                    p = z + p * beta;
                    ap =matrix.SourceMatrix.Multiply(p);
                    rOld = rNew;
                    oIter++;

                  
                    oNev = rNew.Norm() / bNev;

                    solverLogger.AddIterationInfo(oIter, oNev);//logger

                }

                return x;
            }

        }

        public override Type Type { get { return Type.MSG; } }
    }
}
