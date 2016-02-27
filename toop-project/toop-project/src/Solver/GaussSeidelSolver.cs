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
      Vector x = new Vector(rightPart.Size);
      if (parameters.initialSolution != null)
        x = parameters.initialSolution;
      Vector xnext = new Vector(rightPart.Size);

      Vector diagonal = matrix.Diagonal;
      Vector Dx = diagonalMult(diagonal, x);
      Vector Fx = matrix.LMult(x, false);
      Vector Ex = matrix.UMult(x, false);
      Vector r = Dx + Fx + Ex - rightPart;

      var rightPartNorm = rightPart.Norm();
      double relativeResidual = r.Norm() / rightPartNorm;

      Vector DEb = diagonalSolve(diagonal, rightPart);

      solverLogger.AddIterationInfo(0, relativeResidual);

      for (int k = 1; k <= parameters.MaxIterations && relativeResidual > parameters.Epsilon; k++) {
        Vector DEx = diagonalSolve(diagonal, Ex + Fx);
        xnext = (DEb + DEx) * w + x * (1 - w);

        Dx = diagonalMult(diagonal, xnext);
        Ex = matrix.UMult(x, false);
        r = Dx + Fx + Ex - rightPart;
        Fx = matrix.LMult(xnext, false);

        relativeResidual = r.Norm() / rightPartNorm;

        solverLogger.AddIterationInfo(k, relativeResidual);

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
