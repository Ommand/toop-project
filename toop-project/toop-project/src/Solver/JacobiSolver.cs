using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Vector_;
using toop_project.src.Logging;

namespace toop_project.src.Solver {
  public class JacobiSolver : ISolver {
    public override Type Type { get { return Type.Jacobi; } }

    public JacobiSolver() {
      parameters = new JacobiParameters();
    }

    private double w { get { return (parameters as JacobiParameters).Relaxation; } set { } }

    public override Vector Solve(BaseMatrix matrix, Vector rightPart) {
      int size = rightPart.Size;
      Vector x = new Vector(size);
      Vector r = new Vector(size);
      Vector diagonal = new Vector(size);

      if (parameters.initialSolution != null)
        x = parameters.initialSolution;

      diagonal = matrix.Diagonal;
      double rightPartNorm = rightPart.Norm();

      Vector Dx = Vector.Mult(diagonal, x);
      Vector Lx = matrix.LMult(x, false);
      Vector Ux = matrix.UMult(x, false);
      r = Lx + Dx + Ux - rightPart;
      double relativeResidual = r.Norm() / rightPartNorm;

      Vector Db = Vector.Division(rightPart, diagonal);

      solverLogger.AddIterationInfo(0, relativeResidual);
      Vector DULx;
      for (int k = 1; k <= parameters.MaxIterations && relativeResidual > parameters.Epsilon; k++) {
        DULx = Vector.Division(Ux + Lx, diagonal);

        x = (Db - DULx) * w + x * (1 - w);

        Dx = Vector.Mult(diagonal, x);
        Lx = matrix.LMult(x, false);
        Ux = matrix.UMult(x, false);
        r = Lx + Dx + Ux - rightPart;
        relativeResidual = r.Norm() / rightPartNorm;

        solverLogger.AddIterationInfo(k, relativeResidual);
      }

      return x;
    }
  }
}
