using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector;

namespace toop_project.src.Matrix
{
    interface IMatrix
    {
        IVector Multiply(IVector x);// A*x
        IVector TMultiply(IVector x);// At*x

        IVector LMult(IVector x, bool UseDiagonal);//L*x , Если false, то диагональ нулевая
        IVector UMult(IVector x, bool UseDiagonal);//U*x, Если false, то диагональ нулевая

		IVector LtMult(IVector x, bool UseDiagonal);//Lt*x , Если false, то диагональ нулевая
        IVector UtMult(IVector x, bool UseDiagonal);//Ut*x, Если false, то диагональ нулевая

        IVector LSolve(IVector x, bool UseDiagonal);//L-1*x
        IVector USolve(IVector x, bool UseDiagonal);//U-1*x

        IVector LtSolve(IVector x, bool UseDiagonal);//Lt-1*x
        IVector UtSolve(IVector x, bool UseDiagonal);//Ut-1*x

        IVector Diagonal { get; }
        int Size { get; }
    }
}
