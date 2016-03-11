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
                Vector x = initialSolution, rNew, rOld, z, az;
                rOld = matrix.QMultiply(rightPart - matrix.SMultiply(matrix.SourceMatrix.Multiply(x)));
                z = rOld;
                az = matrix.SMultiply(matrix.SourceMatrix.Multiply(matrix.QMultiply(z)));
                bNev = rightPart.Norm();
                scalRO = rOld * rOld;
                x = matrix.QMultiply(x);
                do
                {

                    alpha = scalRO / (az * z);
                    x = x + z * alpha;
                    rNew = rOld - az * alpha;
                    scaleRN = rNew * rNew;
                    beta = scaleRN / scalRO;
                    scalRO = scaleRN;
                    z = rNew + z * beta;
                    az = matrix.SMultiply(matrix.SourceMatrix.Multiply(matrix.QMultiply(z)));
                    rOld = rNew;
                    oIter++;
                    oNev = rNew.Norm() / bNev;

                    solverLogger.AddIterationInfo(oIter, oNev);//logger

                }
                while (oIter < ConGradParametrs.MaxIterations && oNev > ConGradParametrs.Epsilon);


                return matrix.QSolve(x);
            }

        }

        public override Type Type { get { return Type.MSG; } }
    }
}
