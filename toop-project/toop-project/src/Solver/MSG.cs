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

        public override Vector Solve(BaseMatrix matrix, Vector rightPart, Vector initialSolution, ILogger logger, ISolverLogger solverLogger, ISolverParametrs solverParametrs)
        {
            if (solverParametrs is MSGParametrs)
            {
                MSGParametrs ConGradParametrs = solverParametrs as MSGParametrs;

                //prestart
                int oIter = 0;
                double alpha, beta, oNev;
                Vector x = initialSolution, rNew, rOld, z;

                rOld = rightPart - matrix.Multiply(x);
                z = rOld;

                /////////////
                //Start
                ///////////
                do
                {

                    alpha = (rOld * rOld) / (matrix.Multiply(z) * z);
                    x = x + z * alpha;
                    rNew = rOld - matrix.Multiply(z) * alpha;
                    beta = (rNew * rNew) / (rOld * rOld);
                    z = rNew + z * beta;

                    oIter++;
                    oNev = rNew.Norm() / rightPart.Norm();

                    solverLogger.AddIterationInfo(oIter, oNev);//logger

                }
                while (oIter < ConGradParametrs.MaxIterations && oNev > ConGradParametrs.Epsilon);


                return x;
            }
            else
            {
                logger.Error("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in MSG");
                throw new Exception("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in MSG");
            }
        }

        public string Name
        {
            get
            {
                return "MSG";
            }
        }
    }
}
