using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project
{
    interface IMatrix
    {
        IVector Multiply(IVector x);
        IVector TMultiply(IVector x);
    }
    interface IVector
    {
       /* static double operator *(IVector v1, IVector v2);
        static IVector operator +(IVector v1, IVector v2);
        static IVector operator *(IVector v1, double v2);
        static IVector operator *(double v1, IVector v2);*/
        double Norm();
    }

    interface ISLAE
    {
        IMatrix Matrix { get; set; }
        IVector RightPart { get; set; }
    }

    interface IIterationLogger
    {
        int IterationNumber { get; set; }
        IVector Residual { get; set; }
        IVector CurrentSolution { get; set; }
        ISolver CurrentSolver { get; set; }
    }

    interface IPreconditioner : IMatrix
    {
        string Name { get; }
        void Create(IMatrix matrix);
    }

    interface ISolver
    {
        IVector Solve(ISLAE slae, IVector initial,
                        IIterationLogger logger, double eps, int maxiter);
        string Name { get; }
        IPreconditioner Preconditioner { set; }
    }

    interface Interface
    {
        int I { get; set; }
    }
}
