using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Vector_;
using toop_project.src.Logging;

namespace toop_project.src.Solver
{
    public enum Type {
        Jacobi,
        GZ,
        LOS,
        MSG,
        BSG,
        GMRES
    }
    abstract public class ISolver {
        public abstract Vector Solve(BaseMatrix matrix, Vector rightPart, Vector initialSolution,
                        ILogger logger,ISolverLogger solverLogger, ISolverParametrs solverParametrs);
        public static ISolver getSolver(Type type) {
            switch (type) {
                case Type.Jacobi:
                    return new src.Solver.Jacobi();
                case Type.MSG:
                    return new src.Solver.MSG();
                case Type.GZ:
                    return new src.Solver.GZ();

            }
            return null;
        }
    }
}
