using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;
using toop_project.src.Preconditioner;

/*
    Реализация диагонального формата.
    Главная диагональ хранится в массиве di, побочные хранятся в массивах:
    al (нижний треугольник), au (верний треугольник).
    В массивах shift_l, shift_u хранятся сдвиги диагоналей.

    Пример:
    Общий вид матрицы:
    di    0    u21    0     0     0     0  ...
    l11   di    0    u22    0     0     0  ...
     0   l12   di     0    u23    0     0  ...
    l31   0    l13   di     0    u24    0  ...
     0   l32    0    l14   di     0    u25 ...
     0    0    l33    0    l15   di     0  ...
     0    0     0    l34    0    l16   di  ... 
    ....................................

    shift_l: {1, 3}
    shift_u: {2}
    
    al:           au:
    0    0        0   
    l11  0        0 
    l12  0        u21 
    l13  l31      u22 
    l14  l32      u23 
    ........      ...
*/

namespace toop_project.src.Matrix
{
    class DiagonalMatrix : BaseMatrix, IPreconditioner
    {
        private double[] di;
        private double[][] au;// верхняя половина
        private double[][] al;// нижняя половина
        private int[] shift_l;// сдвиги нижних диагоналей
        private int[] shift_u;// сдвиги верхних диагоналей

        public override Vector Diagonal
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int Size
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        #region Matrix
        public override Vector LMult(Vector x, bool UseDiagonal)
        {
            if (di.Length == x.Size)
            {
                Vector result = new Vector(di.Length);
                result.Nullify();

                for (int j = 0; j < shift_l.Length; j++)
                    for (int i = shift_l[j]; i < di.Length; i++)
                        result[i - shift_l[j]] += al[j][i] * x[i];

                if (UseDiagonal)
                    for (int i = 0; i < di.Length; i++)
                        result[i] += di[i] * x[i];

                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в умножении нижнего треугольника");

        }

        public override Vector LSolve(Vector x, bool UseDiagonal)
        {
            if (di.Length == x.Size)
            {
                Vector result = (Vector)x.Clone();

                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в умножении нижнего треугольника");
        }

        public override Vector LtMult(Vector x, bool UseDiagonal)
        {
            if (di.Length == x.Size)
            {
                Vector result = new Vector(di.Length);
                result.Nullify();

                for (int j = 0; j < shift_l.Length; j++)
                    for (int i = shift_l[j]; i < di.Length; i++)
                        result[i] += al[j][i] * x[i];

                if (UseDiagonal)
                    for (int i = 0; i < di.Length; i++)
                        result[i] += di[i] * x[i];

                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в умножении нижнего (T) треугольника");
        }

        public override Vector LtSolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector Multiply(Vector x)
        {
            if (di.Length == x.Size)
            {
                Vector result = new Vector(di.Length);
                result.Nullify();

                // Нижний треугольник
                for (int j = 0; j < shift_l.Length; j++)
                    for (int i = shift_l[j]; i < di.Length; i++)
                        result[i - shift_l[j]] += al[j][i] * x[i];

               // Диагональ
                for (int i = 0; i < di.Length; i++)
                    result[i] += di[i] * x[i];

                //Верхний треугольник
                for (int j = 0; j < shift_u.Length; j++)
                    for (int i = shift_u[j]; i < di.Length; i++)
                        result[i] += au[j][i] * x[i];

                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в умножении");
        }

        public override Vector TMultiply(Vector x)
        {
            if (di.Length == x.Size)
            {
                Vector result = new Vector(di.Length);
                result.Nullify();

                // Верхний треугольник
                for (int j = 0; j < shift_u.Length; j++)
                    for (int i = shift_u[j]; i < di.Length; i++)
                        result[i - shift_u[j]] += au[j][i] * x[i];

                // Диагональ
                for (int i = 0; i < di.Length; i++)
                    result[i] += di[i] * x[i];

                // Нижний треугольник
                for (int j = 0; j < shift_l.Length; j++)
                    for (int i = shift_l[j]; i < di.Length; i++)
                        result[i] += al[j][i] * x[i];

                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в умножении (T)");
        }

        public override Vector UMult(Vector x, bool UseDiagonal)
        {
            if (di.Length == x.Size)
            {
                Vector result = new Vector(di.Length);
                result.Nullify();

                for (int j = 0; j < shift_u.Length; j++)
                    for (int i = shift_u[j]; i < di.Length; i++)
                        result[i] += au[j][i] * x[i];

                if (UseDiagonal)
                    for (int i = 0; i < di.Length; i++)
                        result[i] += di[i] * x[i];

                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в умножении верхнего треугольника");
        }

        public override Vector USolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector UtMult(Vector x, bool UseDiagonal)
        {
            if (di.Length == x.Size)
            {
                Vector result = new Vector(di.Length);
                result.Nullify();

                for (int j = 0; j < shift_u.Length; j++)
                    for (int i = shift_u[j]; i < di.Length; i++)
                        result[i - shift_u[j]] += au[j][i] * x[i];

                if (UseDiagonal)
                    for (int i = 0; i < di.Length; i++)
                        result[i] += di[i] * x[i];

                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в умножении верхнего (T) треугольника");
        }

        public override Vector UtSolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Preconditioner
        public BaseMatrix LLt()
        {
            throw new NotImplementedException();
        }

        public BaseMatrix LU()
        {
            throw new NotImplementedException();
        }

        public BaseMatrix LUsq()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
