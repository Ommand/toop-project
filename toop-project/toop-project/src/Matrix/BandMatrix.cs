using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;
using toop_project.src.Preconditioner;

/*
    Реализация ленточного формата хранения матрицы.
    В качестве характеристики ленты выступает полуширина.
    Хранение следующее:
    di - массив главной диагонали.
    al - двумерный массив нижнего треугольника матрицы.
    au - двумерный массив верхнего треугольника матрицы.
    
    Общий вид матрицы:
    di  u11  u21  u31   0    0    0  ...
    l11  di  u12  u22  u32   0    0  ...
    l21 l12   di  u13  u23  u33   0  ...
    l31 l22  l13   di  u14  u24  u34 ...
     0  l32  l23  l14   di  u15  u25 ...
     0   0   l33  l24  l15   di  u16 ...
     0   0    0   l34  l25  l16   di ... 
    ....................................

    Хранение элементов в массивах al, au:
    al:
    0    0   0
    l11  0   0
    l12 l21  0
    l13 l22 l31
    ...........

    au:
    0    0   0
    u11  0   0
    u12 u21  0
    u13 u22 u31
    ...........
    
*/

namespace toop_project.src.Matrix
{
    public class BandMatrix: BaseMatrix
    {
        private double[] di; // диагональ
        private double[][] au;// верхняя половина
        private double[][] al;// нижняя половина
        int bandWidth;// полуширина ленты
        int n;// размерность матрицы

        #region Matrix

        public BandMatrix(int bandWidth, double[] di, double[][] al, double[][] au)
        {
            this.n = di.Count();
            this.bandWidth = bandWidth;
            this.di = di;
            this.al = al;
            this.au = au;
        }

        public override Vector Diagonal
        {
            get
            {
                Vector d = new Vector(n);
                for (int i = 0; i < n; i++)
                    d[i] = di[i];
                return d;
            }
        }

        public override int Size
        {
            get
            {
                return n;
            }
        }

        public override Vector LMult(Vector x, bool UseDiagonal)
        {
            if (n == x.Size)
            {
                Vector result = new Vector(n);
                result.Nullify();
                if (UseDiagonal)
                {
                    for (int i = 0; i < n; i++)// обрабатываем i строку
                    {
                        for (int j = i - 1, count = 0; j >= 0 && count < bandWidth; j--, count++)// обработка нижнего треугольника
                            result[i] += al[i][count] * x[j];

                        result[i] += di[i] * x[i];// обработка диагонального элемента
                    }
                }
                else
                {
                    for (int i = 0; i < n; i++)// обрабатываем i строку
                    {
                        for (int j = i - 1, count = 0; j >= 0 && count < bandWidth; j--, count++)// обработка нижнего треугольника
                            result[i] += al[i][count] * x[j];
                    }
                }
                
                return result;
            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора в умножении нижнего треугольника");
        }

        public override Vector LSolve(Vector x, bool UseDiagonal)
        {
            if (n == x.Size)
            {
                //Vector result = new Vector(n);
                // Разобраться с присваиванием, пока обобщенно написано            
                //result = x;
                Vector result = (Vector)x.Clone();
                if (UseDiagonal)
                {
                    for (int i = 0; i < n; i++)// обрабатываем i строку
                    {
                        for (int j = i - 1, count = 0; j >= 0 && count < bandWidth; j--, count++)// обработка нижнего треугольника
                            result[i] -= al[i][count] * result[j];

                        result[i] /= di[i];// обработка диагонального элемента
                    }
                }
                else
                {
                    for (int i = 0; i < n; i++)// обрабатываем i строку
                    {
                        for (int j = i - 1, count = 0; j >= 0 && count < bandWidth; j--, count++)// обработка нижнего треугольника
                            result[i] -= al[i][count] * result[j];
                    }
                }
                
                return result;
            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и ветора при прямом ходе");
        }

        public override Vector LtMult(Vector x, bool UseDiagonal)
        {
            if (n == x.Size)
            {
                Vector result = new Vector(n);
                result.Nullify();
                if (UseDiagonal)
                {
                    for (int i = 0; i < n; i++)// обрабатываем i строку
                    {
                        for (int j = i + 1, count = 0; j < n && count < bandWidth; j++, count++)// обработка нижнего транспонированного треугольника
                            result[i] += al[j - i][count] * x[j];

                        result[i] += di[i] * x[i];// обработка диагонального элемента
                    }
                }
                else
                {
                    for (int i = 0; i < n; i++)// обрабатываем i строку
                    {
                        for (int j = i + 1, count = 0; j < n && count < bandWidth; j++, count++)// обработка нижнего транспонированного треугольника
                            result[i] += al[j - i][count] * x[j];
                    }
                }
                
                return result;
            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и ветора при умножении нижнего(T) треугольника");
        }

        public override Vector LtSolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector UMult(Vector x, bool UseDiagonal)
        {
            if (n == x.Size)
            {
                Vector result = new Vector(n);
                result.Nullify();
                if (UseDiagonal)
                {
                    for (int i = 0; i < n; i++)// обрабатываем i строку
                    {
                        for (int j = i + 1, count = 0; j < n && count < bandWidth; j++, count++)// обработка верхнего треугольника
                            result[i] += au[j - i][count] * x[j];

                        result[i] += di[i] * x[i];// обработка диагонального элемента
                    }
                }
                else
                {
                    for (int i = 0; i < n; i++)// обрабатываем i строку
                    {
                        for (int j = i + 1, count = 0; j < n && count < bandWidth; j++, count++)// обработка верхнего треугольника
                            result[i] += au[j - i][count] * x[j];
                    }
                }
               
                return result;
            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора при умножении верхнего треугольника");
        }

        public override Vector USolve(Vector x, bool UseDiagonal)
        {
            if (n == x.Size)
            {
                //Vector result = new Vector(n);
                // Разобраться с присваиванием, пока обобщенно написано            
                //result =  x;
                Vector result = (Vector) x.Clone();
                if (UseDiagonal)
                {
                    for (int i = n - 1; i >= 0; i--)// обрабатываем i строку
                    {
                        for (int j = i + 1, count = 0; j < n && count < bandWidth; j++, count++)
                            result[i] -= au[j][count] * result[j];
                       
                        result[i] /= di[i] * x[i];// обработка диагонального элемента
                    }
                }
                else
                {
                    for (int i = n - 1; i >= 0; i--)// обрабатываем i строку
                    {
                        for (int j = i + 1, count = 0; j < n && count < bandWidth; j++, count++)
                            result[i] -= au[j][count] * result[j];
                    }
                }

                return result;
               
            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора при обратном ходе");
        }

        public override Vector UtMult(Vector x, bool UseDiagonal)
        {
            if (n == x.Size)
            {
                Vector result = new Vector(n);
                result.Nullify();
                if (UseDiagonal)
                {
                    for (int i = 0; i < n; i++)// обрабатываем i строку
                    {
                        for (int j = i - 1, count = 0; j >= 0 && count < bandWidth; j--, count++)// обработка верхнего транспонирвоанного треугольника
                            result[i] += au[i][count] * x[j];

                        result[i] += di[i] * x[i];// обработка диагонального элемента
                    }
                }
                else
                {
                    for (int i = 0; i < n; i++)// обрабатываем i строку
                    {
                        for (int j = i - 1, count = 0; j >= 0 && count < bandWidth; j--, count++)// обработка верхнего транспонирвоанного треугольника
                            result[i] += au[i][count] * x[j];
                    }
                }
               
                return result;
            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора при умножении верхнего(T) треугольника");
        }

        public override Vector UtSolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector Multiply(Vector x)
        {
            Vector result = new Vector(n);
            result.Nullify();
            if (n == x.Size)
            {
                for (int i = 0; i < n; i++)// обрабатываем i строку
                {
                    for (int j = i - 1, count = 0; j >= 0 && count < bandWidth; j--, count++)// обработка нижнего треугольника
                        result[i] += al[i][count] * x[j];

                    result[i] += di[i] * x[i];// обработка диагонального элемента

                    for (int j = i + 1, count = 0; j < n && count < bandWidth; j++, count++)// обработка верхнего треугольника
                        result[i] += au[j - i][count] * x[j];

                }
                return result;
            }
            throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора при умножении");
        }

        public override Vector TMultiply(Vector x)
        {
            Vector result = new Vector(n);
            result.Nullify();
            if (n == x.Size)
            {
                for (int i = 0; i < n; i++)// обрабатываем i строку
                {
                    for (int j = i - 1, count = 0; j >= 0 && count < bandWidth; j--, count++)// обработка верхнего t треугольника
                        result[i] += au[i][count] * x[j];

                    result[i] += di[i] * x[i];// обработка диагонального элемента

                    for (int j = i + 1, count = 0; j < n && count < bandWidth; j++, count++)// обработка нижнего t треугольника
                        result[i] += al[j - i][count] * x[j];

                }
                return result;
            }
            throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора при умножении(T)");
        }

        #endregion

    }



}

