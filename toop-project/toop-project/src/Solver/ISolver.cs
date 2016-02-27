using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Vector_;
using toop_project.src.Logging;

namespace toop_project.src.Solver {
  public enum Type {
    Jacobi,
    Seidel,
    LOS,
    MSG,
    BSG,
    GMRES
  }
  abstract public class ISolver {
    public abstract Type Type { get; }
    protected src.Logging.ILogger logger = src.Logging.Logger.Instance;
    protected src.Logging.ISolverLogger solverLogger = src.Logging.Logger.Instance;
    public ISolverParameters Parameters { get { return parameters; } }
    protected ISolverParameters parameters;

    public abstract Vector Solve(BaseMatrix matrix, Vector rightPart);

    public static ISolver getSolver(Type type) {
      switch (type) {
        case Type.Jacobi:
          return new JacobiSolver();
        case Type.Seidel:
          return new GaussSeidelSolver();
      }
      return null;
    }
  }
}
