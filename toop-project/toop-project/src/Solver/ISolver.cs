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
   Vector Solve(BaseMatrix matr, Vector rightpart, Vector initial,
                        Logger logger, double eps, int maxiter);
        string Name { get; }
    }
}
