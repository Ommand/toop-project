using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  toop_project.src.Vector_;

namespace toop_project.src.Matrix
{
    public enum Type {
        Diagonal,
        Sparse,
        Dense,
        Profile,
        Band
    }
    public abstract class BaseMatrix
    {
        public abstract Vector Multiply(Vector x);//A*x       
        public abstract Vector TMultiply(Vector x);// At*x

        public abstract Vector LMult(Vector x, bool UseDiagonal);//L*x , Если false, то диагональ нулевая
        public abstract Vector UMult(Vector x, bool UseDiagonal);//U*x, Если false, то диагональ нулевая

        public abstract Vector LtMult(Vector x, bool UseDiagonal);//Lt*x , Если false, то диагональ нулевая
        public abstract Vector UtMult(Vector x, bool UseDiagonal);//Ut*x, Если false, то диагональ нулевая

        public abstract Vector LSolve(Vector x, bool UseDiagonal);//L-1*x
        public abstract Vector USolve(Vector x, bool UseDiagonal);//U-1*x

        public abstract Vector LtSolve(Vector x, bool UseDiagonal);//Lt-1*x
        public abstract Vector UtSolve(Vector x, bool UseDiagonal);//Ut-1*x

        public abstract Vector Diagonal { get; }
        public abstract int Size { get; }
        
        //Функция, выполняющая обход ненулевых элементов матрицы и выполняющая над ними операцию fun
        public abstract void Run(Action<int,int,double> fun);
    }
}
