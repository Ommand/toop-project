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
    interface ISolver
    {
   Vector Solve(BaseMatrix matrix, Vector rightPart, Vector initialSolution,
                        ILogger logger, ISolverLogger solverLogger , ISolverParametrs solverParametrs);
        string Name { get; }
    }
}
