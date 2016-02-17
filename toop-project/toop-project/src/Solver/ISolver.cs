using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Solver
{
    interface ISolver
    {
   IVector Solve(IMatrix matr, IVector rightpart, IVector initial,
                        IIterationLogger logger, double eps, int maxiter);
        string Name { get; }
    }
}
