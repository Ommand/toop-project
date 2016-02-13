using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project
{
    interface IMatrix
    {
        bool InitializeFrom(IMatrix matr);

        //public delegate void ProcessElement(int i, int j, double d);
       // void Run(ProcessElement fun);//Пробежаться по всем ненулевым элементам матрицы

        //IVector Multiply(IVector x);
        //IVector TMultiply(IVector x);

        //IVector LMult(IVector x,bool UseDiagonal);//L*x , Если false, то диагональ нулевая
        //IVector UMult(IVector x, bool UseDiagonal);//U*x, Если false, то диагональ нулевая

        //IVector LSolve(IVector x, bool UseDiagonal);//L-1*x, Если false, то диагональ единички
        //IVector USolve(IVector x, bool UseDiagonal);//U-1*x, Если false, то диагональ единички

        //IVector LtSolve(IVector x, bool UseDiagonal);//Lt-1*x Если false, то диагональ единички
        //IVector UtSolve(IVector x, bool UseDiagonal);//Ut-1*x Если false, то диагональ единички
        IVector Diagonal { get; }
        int Size { get; }
    }
}
