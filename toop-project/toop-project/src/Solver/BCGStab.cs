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
    class BCGStab : ISolver
    {
        public override Type Type { get { return Type.BCGStab; } }

        public override Vector Solve(IPreconditioner matrix, Vector rightPart, Vector initialSolution, ILogger logger, ISolverLogger solverLogger, ISolverParametrs solverParametrs)
        {
            BCGStabParametrs ConGradParametrs = solverParametrs as BCGStabParametrs;
            if (ConGradParametrs == null)
            {
                logger.Error("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in BSGStab");
                throw new Exception("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in BSGSTab");
            }
            else
            {
                int oIter = 0;
                double nPi, oPi, alpha, w, oNev, bNev, betta;
                oPi = alpha = w = 1;
                int size = rightPart.Size;
                Vector x, r, rTab, s, t, z, sqt, y;
                Vector v = new Vector(size);
                Vector p = new Vector(size);
                v.Nullify();
                p.Nullify();
                x = initialSolution;
                r = rightPart - matrix.SourceMatrix.Multiply(x);
                rTab = r;
                bNev = rightPart.Norm();
                oNev = r.Norm() / bNev;
                solverLogger.AddIterationInfo(oIter, oNev);//logger

                while (oIter < ConGradParametrs.MaxIterations && oNev > ConGradParametrs.Epsilon)
                {
                    nPi = rTab * r;
                    betta = (nPi / oPi) * (alpha / w);
                    p = r + (p - v * w) * betta;
                    y= matrix.QSolve(matrix.SSolve(p));
                    v = matrix.SourceMatrix.Multiply(y);
                    alpha = nPi / (rTab * v);
                    x = x + y * alpha;//УТОЧНИТЬ!!!!!!!!!!!!!!!
                    s = r - v * alpha;
                    if (s.Norm() / bNev < ConGradParametrs.Epsilon) return x;
                    z = matrix.QSolve(matrix.SSolve(s));
                    t = matrix.SourceMatrix.Multiply(z);
                    sqt = matrix.QSolve(matrix.SSolve(t));
                    w = (z * sqt) / (sqt * sqt);
                    x = x + z * w;//УТОЧНИТЬ!!!!!!!!!!!!!!!!!!!
                    r = s - t * w;

                    oPi = nPi;
                    oIter++;
                    oNev = r.Norm() / bNev;
                    solverLogger.AddIterationInfo(oIter, oNev);//logger
                }

                return x;
            }
        }
    }
}
