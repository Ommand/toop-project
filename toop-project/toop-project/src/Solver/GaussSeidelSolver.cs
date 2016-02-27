using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Vector_;
using toop_project.src.Logging;

namespace toop_project.src.Solver {
  class GaussSeidelSolver : ISolver {
    public override Type Type { get { return Type.Seidel; } }

    public GaussSeidelSolver() {
      parameters = new GaussSeidelParameters();
    }

    private double w { get { return (parameters as GaussSeidelParameters).Relaxation; } set { } }

    public override Vector Solve(BaseMatrix matrix, Vector rightPart) {
      int size = rightPart.Size;
      Vector x = new Vector(size);
      Vector xnext = new Vector(size);
      Vector r = new Vector(size);
      Vector di = new Vector(size);

      if(parameters.initialSolution != null)
        x = parameters.initialSolution;
      di = matrix.Diagonal;

      Vector Dx = diagonalMult(di, x);
      Vector Fx = matrix.LMult(x, false);
      Vector Ex = matrix.UMult(x, false);
      r = Dx + Fx + Ex - rightPart;
      var rpnorm = rightPart.Norm();
      double Residual = r.Norm() / rpnorm;

      Vector DEb = diagonalSolve(di, rightPart);

      solverLogger.AddIterationInfo(0, Residual);

      for (int k = 1; k <= parameters.MaxIterations && Residual > parameters.Epsilon; k++) {
        Vector DEx = diagonalSolve(di, Ex + Fx);
        xnext = (DEb + DEx) * w + x * (1 - w);

        Dx = diagonalMult(di, xnext);
        Ex = matrix.UMult(x, false);
        r = Dx + Fx + Ex - rightPart;
        Fx = matrix.LMult(xnext, false);

        Residual = r.Norm() / rpnorm;

        solverLogger.AddIterationInfo(k, Residual);

        x = xnext;
      }

      return xnext;
    }

    private Vector diagonalSolve(Vector diagonal, Vector vector) {
      int size = diagonal.Size;
      Vector result = new Vector(size);

      for (int i = 0; i < size; i++)
        result[i] = vector[i] / diagonal[i];

      return result;
    }

    private Vector diagonalMult(Vector diagonal, Vector vector) {
      int size = diagonal.Size;
      Vector result = new Vector(size);

      for (int i = 0; i < size; i++)
        result[i] = vector[i] * diagonal[i];

      return result;
    }
  }
}
