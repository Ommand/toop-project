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
    public enum Type {
        Jacobi,
        Seidel,
        LOS,
        MSG,
        BSGStab,
        GMRES
    }
    abstract public class ISolver {
        public abstract Vector Solve(IPreconditioner matrix, Vector rightPart, Vector initialSolution,
                        ILogger logger,ISolverLogger solverLogger, ISolverParametrs solverParametrs);
        public static ISolver getSolver(Type type) {
            switch (type) {
                case Type.Jacobi:
                    return new src.Solver.Jacobi();
                case Type.Seidel:
                    return new src.Solver.GZ();
                case Type.GMRES:
                    return new src.Solver.GMRES();
                case Type.MSG:
                    return new src.Solver.MSG();
                case Type.BSGStab:
                    return new src.Solver.BSGStab();
                case Type.LOS:
                    return new src.Solver.LOS();
            }
            return null;
        }

       public abstract Type Type { get; }
    }
}
