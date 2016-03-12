using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Logging;
using toop_project.src.Preconditioner;
using toop_project.src.Vector_;

namespace toop_project.src.Solver
{
    class BSGStab : ISolver
    {
        public override Type Type { get { return Type.BSGStab; } }

        public override Vector Solve(IPreconditioner matrix, Vector rightPart, Vector initialSolution, ILogger logger, ISolverLogger solverLogger, ISolverParametrs solverParametrs)
        {
            BSGStabParametrs ConGradParametrs = solverParametrs as BSGStabParametrs;
            if (ConGradParametrs == null)
            {
                logger.Error("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in BSGStab");
                throw new Exception("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in BSGSTab");
            }
            else
            {
                int oIter = 0;
                double nPi,oPi, alpha, w, oNev, bNev, betta;
                oPi = alpha = w = 1;
                int size = rightPart.Size;
                Vector x, r, rTab, s, t;
                Vector v = new Vector(size);
                Vector p = new Vector(size);
                v.Nullify();
                p.Nullify();
                x = initialSolution;
                r = matrix.QMultiply(rightPart - matrix.SMultiply(matrix.SourceMatrix.Multiply(x)));
                rTab = r;
                bNev =matrix.SMultiply(rightPart).Norm();
                oNev = r.Norm() / bNev;
                solverLogger.AddIterationInfo(oIter, oNev);//logger

                while (oIter<ConGradParametrs.MaxIterations && oNev>ConGradParametrs.Epsilon )
                {
                    nPi = rTab * r;
                    betta = (nPi / oPi) * (alpha/w);
                    p = r + (p - v * w) * betta;
                    v = matrix.SMultiply(matrix.SourceMatrix.Multiply(matrix.QMultiply(p)));
                    alpha = nPi / (rTab * v);
                    x = x + p * alpha;//УТОЧНИТЬ!!!!!!!!!!!!!!!
                    s = r - v * alpha;
                    t = matrix.SMultiply(matrix.SourceMatrix.Multiply(matrix.QMultiply(s)));
                    w = (s * t) / (t * t);
                    x = x + s * w;//УТОЧНИТЬ!!!!!!!!!!!!!!!!!!!
                    r = s - t * w; 

                    oPi = nPi;
                    oIter++;
                    oNev = r.Norm() / bNev;
                    solverLogger.AddIterationInfo(oIter, oNev);//logger
                }

                return matrix.QSolve(x);

            }
        }
    }
}
