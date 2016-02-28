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

        public DiagonalMatrix(double[] di, double[][] al, double[][] au, int[] shift_l, int[] shift_u)
        {
            this.di = di;
            this.al = al;
            this.au = au;
            this.shift_l = shift_l;
            this.shift_u = shift_u;
        }

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

                if (UseDiagonal)
                {
                    result[0] /= di[0];
                    int i;
                    // Спускаемся, пока не дойдем до последней диагонали
                    for (i = 1; i < shift_l[0]; i++)
                        result[i] /= di[i];
                    for (int k = 0; k < shift_l.Length; k++)
                    {
                        for (; i < shift_l[k + 1]; i++)
                        {
                            for (int j = k; j >= 0; j--)
                                result[i] -= al[i][j] * result[i - shift_l[j]];
                            result[i] /= di[i];
                        }
                    }
                    //Спустились до последней диагонали, обрабатываем все вместе
                    for (; i < di.Length; i++)
                    {
                        for (int j = 0; j < shift_l.Length; j++)
                            result[i] -= al[i][j] * result[i-shift_l[j]];
                        result[i] /= di[i];
                    }
                }
                else
                {
                    int i = 1;
                    // Спускаемся, пока не дойдем до последней диагонали
                    
                    for (int k = 0; k < shift_l.Length; k++)
                        for (; i < shift_l[k + 1]; i++)
                            for (int j = k; j >= 0; j--)
                                result[i] -= al[i][j] * result[i - shift_l[j]];

                    //Спустились до последней диагонали, обрабатываем все вместе
                    for (; i < di.Length; i++)
                        for (int j = 0; j < shift_l.Length; j++)
                            result[i] -= al[i][j] * result[i - shift_l[j]];
                }

                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в прямом ходе");
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
            if (di.Length == x.Size)
            {
                Vector result = (Vector)x.Clone();

                if (UseDiagonal)
                {
                    int n = di.Length - shift_l[shift_l.Length - 1];

                    result[di.Length - 1] /= di[di.Length - 1];
                    for (int i = di.Length - 2; i >= n; i--)
                    {
                        for (int j = 0; j < shift_l.Length; j++)
                            result[i - shift_u[j]] -= al[i + 1][shift_u[j]] * result[i + 1];
                        result[i] /= di[i];
                    }
                }
                else
                {
                    int n = di.Length - shift_l[shift_l.Length - 1];

                    for (int i = di.Length - 2; i >= n; i--)
                        for (int j = 0; j < shift_l.Length; j++)
                            result[i - shift_l[j]] -= au[i + 1][shift_l[j]] * result[i + 1];
                }
                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в прямом (T) ходе");
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
            if (di.Length == x.Size)
            {
                Vector result = (Vector)x.Clone();

                if (UseDiagonal)
                {
                    int n = di.Length - shift_u[shift_u.Length - 1];

                    result[di.Length - 1] /= di[di.Length - 1];
                    for (int i = di.Length - 2; i >= n; i--)
                    {
                        for (int j = 0; j < shift_u.Length; j++)
                            result[i-shift_u[j]] -= au[i+1][shift_u[j]] * result[i + 1];
                        result[i] /= di[i];
                    }
                }
                else
                {
                    int n = di.Length - shift_u[shift_u.Length - 1];

                    for (int i = di.Length - 2; i >= n; i--)                    
                        for (int j = 0; j < shift_u.Length; j++)
                            result[i - shift_u[j]] -= au[i + 1][shift_u[j]] * result[i + 1];
                }
                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в обратном ходе");
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
            if (di.Length == x.Size)
            {
                Vector result = (Vector)x.Clone();

                if (UseDiagonal)
                {
                    result[0] /= di[0];
                    int i;
                    // Спускаемся, пока не дойдем до последней диагонали
                    for (i = 1; i < shift_u[0]; i++)
                        result[i] /= di[i];
                    for (int k = 0; k < shift_u.Length; k++)
                    {
                        for (; i < shift_u[k + 1]; i++)
                        {
                            for (int j = k; j >= 0; j--)
                                result[i] -= au[i][j] * result[i - shift_u[j]];
                            result[i] /= di[i];
                        }
                    }
                    //Спустились до последней диагонали, обрабатываем все вместе
                    for (; i < di.Length; i++)
                    {
                        for (int j = 0; j < shift_u.Length; j++)
                            result[i] -= au[i][j] * result[i - shift_u[j]];
                        result[i] /= di[i];
                    }
                }
                else
                {
                    int i = 1;
                    // Спускаемся, пока не дойдем до последней диагонали

                    for (int k = 0; k < shift_u.Length; k++)
                        for (; i < shift_u[k + 1]; i++)
                            for (int j = k; j >= 0; j--)
                                result[i] -= au[i][j] * result[i - shift_u[j]];

                    //Спустились до последней диагонали, обрабатываем все вместе
                    for (; i < di.Length; i++)
                        for (int j = 0; j < shift_u.Length; j++)
                            result[i] -= au[i][j] * result[i - shift_u[j]];
                }

                return result;
            }
            else
                throw new Exception("Диагональный формат: Несовпадение размерностей матрицы и вектора в прямом ходе");
        }

        public override void Run(Action<int, int, double> fun)
        {
            // Нижний треугольник
            for (int j = 0; j < shift_l.Length; j++)
                for (int i = shift_l[j]; i < di.Length; i++)
                    fun(i - shift_l[j], i, al[j][i]);

            // Диагональ
            for (int i = 0; i < di.Length; i++)
                fun(i, i, di[i]);

            //Верхний треугольник
            for (int j = 0; j < shift_u.Length; j++)
                for (int i = shift_u[j]; i < di.Length; i++)
                    fun(i - shift_u[j], i, au[j][i]);
        }

        #endregion

        #region Preconditioner

        // !
        // Есть очень простые формулы для LU-разложения
        // для случия, если shift_l = {1} и shift_u = {1}
        // введу для них частный случай, в котором сложность n
        // см. "Методы решения СЛАУ большой размерности" М.Ю.Баландин Э.П.Шурина 1 августа 2000 г.

        // Подробные комментарии только для LU разложения
        public BaseMatrix LU()
        {
            var matrPrec = new DiagonalMatrix(di.Clone() as double[], al.Clone() as double[][], au, shift_l, shift_u);
            if (shift_l.Length == 1 && shift_u.Length == 1 && shift_l[0] == shift_u[0]) // частный случай LU разложения для 3-диагоналей
            {
                for (int i = 1; i < di.Length; i++)
                {
                    matrPrec.al[i][shift_l[0]] /= matrPrec.di[i - 1];
                    matrPrec.di[i] -= matrPrec.au[i][shift_l[0]] * matrPrec.al[i][shift_l[0]];
                }
            }
                 // Общий случай
            else // Неполное LU разложение
            {
                // Деление всего нижнего треугольника на элементы главной диагонали, причём
                // элементы j-го столбца деляться на di[j] 
                for (int l_diags = 0; l_diags < shift_l.Length; l_diags++)
                    for (int j = 0, indl = shift_l[l_diags]; indl < al[l_diags].Length; j++, indl++)
                        matrPrec.al[l_diags][indl] /= matrPrec.di[j];

                // Для расчёта новых di, необходимы произведения симметричных элементов
                // для этого нахожим одинаковые смещения
                var shift_max = shift_l;
                var shift_min = shift_u;
                if (shift_l.Length < shift_u.Length)
                {
                    shift_max = shift_u;
                    shift_min = shift_l;
                }
                List<int> shift = new List<int>(shift_min); // одинаковые смещения
                foreach (int i in shift_max)
                    if (!shift.Contains(i))
                        shift.Remove(i);
                
                for (int i = 1; i < di.Length; i++)
                {
                    double sum = 0;
                    foreach (int k in shift)
                        sum += matrPrec.al[i][k] * matrPrec.au[i][k];
                    matrPrec.di[i] -= sum;
                }
            }
            return matrPrec;
        }

        public BaseMatrix LLt()
        {
            var newal = al.Clone() as double[][];
            var matrPrec = new DiagonalMatrix(di.Clone() as double[], newal, newal, shift_l, shift_u);
            if (shift_l.Length == 1 && shift_u.Length == 1 && shift_l[0] == shift_u[0])
            {
                di[0] = Math.Sqrt(di[0]);
                for (int i = 1; i < di.Length; i++)
                {
                    matrPrec.al[i][0] /= matrPrec.di[i - 1];
                    double newdi = matrPrec.di[i] - matrPrec.al[i][0] * matrPrec.al[i][0];
                    if (newdi < 0)
                        throw new Exception(String.Concat("Предобусловливание LLt : на диагонали матрицы элемент №", i, " равен 0 (деление на 0)"));
                    matrPrec.di[i] = Math.Sqrt(newdi);
                }
              }
            else // Неполное разложение
            {
                for (int l_diags = 0; l_diags < shift_l.Length; l_diags++)
                    for (int inddi = 0, indl = shift_l[l_diags]; indl < al[l_diags].Length; inddi++, indl++)
                        matrPrec.al[l_diags][indl] /= matrPrec.di[inddi];
                for (int i = 1; i < di.Length; i++)
                {
                    double sum = 0;
                    foreach (int k in shift_l)
                        sum += matrPrec.al[i][k] * matrPrec.al[i][k];
                    double newdi = matrPrec.di[i] - sum;
                    if (newdi < 0)
                        throw new Exception("Предобусловливание LLt : sqrt(отрицательно число)");
                    matrPrec.di[i] = Math.Sqrt(newdi);
                }
            }
            return matrPrec;
        }

        public BaseMatrix LUsq()
        {
            var matrPrec = new DiagonalMatrix(di.Clone() as double[], al.Clone() as double[][], au.Clone() as double[][], shift_l, shift_u);
            if (shift_l.Length == 1 && shift_u.Length == 1 && shift_l[0] == shift_u[0])
            {
                if (di[0] < 0)
                    throw new Exception("Предобусловливание LU :  на диагонали матрицы элемент №0 отрицательный (sqrt(-1))");
                matrPrec.di[0] = Math.Sqrt(matrPrec.di[0]);
                for (int i = 1; i < di.Length; i++)
                {
                    if (di[i - 1] < 0)
                        throw new Exception(String.Concat("Предобусловливание LUsq : на диагонали матрицы элемент №", i - 1, "отрицательный (sqrt(-1))"));
                    matrPrec.au[i][0] /= matrPrec.di[i - 1];
                    matrPrec.al[i][0] /= matrPrec.di[i - 1];
                    double newdi = matrPrec.di[i] - matrPrec.au[i][0] * matrPrec.al[i][0];
                    if (newdi < 0)
                        throw new Exception(String.Concat("Предобусловливание LUsq : на диагонали матрицы элемент №", i, " равен 0 (деление на 0)"));
                    matrPrec.di[i] = Math.Sqrt(newdi);
                }
                
            }
            else // Неполное LUsq разложение
            {
                // Здесь нужно разделить и верхний и нижные треугольники
                for (int l_diags = 0; l_diags < shift_l.Length; l_diags++)
                    for (int inddi = 0, indl = shift_l[l_diags]; indl < al[l_diags].Length; inddi++, indl++)
                        matrPrec.al[l_diags][indl] /= matrPrec.di[inddi];

                for (int u_diags = 0; u_diags < shift_u.Length; u_diags++)
                    for (int inddi = 0, indu = shift_u[u_diags]; indu < au[u_diags].Length; inddi++, indu++)
                        matrPrec.au[u_diags][indu] /= matrPrec.di[inddi];

                var shift_max = shift_l;
                var shift_min = shift_u;
                if (shift_l.Length < shift_u.Length)
                {
                    shift_max = shift_u;
                    shift_min = shift_l;
                }
                List<int> shift = new List<int>(shift_min); // одинаковые смещения
                foreach (int i in shift_max)
                    if (!shift.Contains(i))
                        shift.Remove(i);
                for (int i = 1; i < di.Length; i++)
                {
                    double sum = 0;
                    foreach (int k in shift)
                        sum += matrPrec.al[i][k] * matrPrec.au[i][k];

                    double newdi = matrPrec.di[i] - sum;
                    if (newdi < 0)
                        throw new Exception("Предобусловливание LLsq : sqrt(отрицательно число)");
                    matrPrec.di[i] = Math.Sqrt(newdi);
                }
            }
            return matrPrec;
        }
        #endregion
    }
}
