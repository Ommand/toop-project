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
    class GaussSeidel: ISolver
    {
        public override Vector Solve(IPreconditioner matrix, Vector rightPart, Vector initialSolution,
                                    ILogger logger, ISolverLogger solverLogger, ISolverParametrs solverParametrs)
        {
            if (solverParametrs is GaussSeidelParametrs)
            {
                GaussSeidelParametrs GZParametrs = solverParametrs as GaussSeidelParametrs;

                Vector x,xnext, r, di;
                int size, k;
                double Residual, w;
                Vector DEx,DEb, Dx, Fx, Ex;

                size = initialSolution.Size;
                x = new Vector(size);
                xnext = new Vector(size);
                r = new Vector(size);
                di = new Vector(size);

                x = initialSolution;
                w = GZParametrs.Relaxation;
                di = matrix.SourceMatrix.Diagonal;

                Dx = Vector.Mult(di, x);
                Fx = matrix.SourceMatrix.LMult(x, false);
                Ex = matrix.SourceMatrix.UMult(x, false);
                r = Dx+Fx+ Ex - rightPart;
                var rpnorm = rightPart.Norm();
                Residual = r.Norm() / rpnorm;

                DEb = Vector.Division(rightPart,di);
             

                solverLogger.AddIterationInfo(0, Residual);
                for (k = 1; k <= GZParametrs.MaxIterations && Residual > GZParametrs.Epsilon; k++)
                {
                
                    DEx = Vector.Division(Ex+Fx,di);                
                    xnext = (DEb - DEx) * w + x * (1 - w);
                    Ex = matrix.SourceMatrix.UMult(xnext, false);
                    Fx = matrix.SourceMatrix.LMult(xnext, false);
                    Dx = Vector.Mult(di, xnext);

                    
                    DEx = Vector.Division(Ex + Fx, di);
                    x = xnext;
                    xnext = (DEb - DEx) * w + x * (1 - w);
                    Dx = Vector.Mult(di, xnext);
                    Fx = matrix.SourceMatrix.LMult(xnext, false);


                    r = Dx + Fx + Ex - rightPart;

                    Residual = r.Norm() / rpnorm;
                    solverLogger.AddIterationInfo(k, Residual);

                }

                return xnext;
            }
            else {
                logger.Error("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in GaussSeidel");
                throw new Exception("Incorrect " + solverParametrs.GetType().Name.ToString() + " as a  SolverParametrs in GaussSeidel");

            }
        }

       public override Type Type { get { return Type.GaussSeidel; } }
    }
}
