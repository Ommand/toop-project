using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;

namespace toop_project.src.Matrix
{
    public class BandMatrix: BaseMatrix
    {
        private double[] di; // диагональ
        private double[][] au;// верхняя половина
        private double[][] al;// нижняя половина
        int bandWidth;// полуширина ленты
        int n;// размерность матрицы

        public BandMatrix(int n, int bandWidth, double[] di, double[][] al, double[][] au)
        {
            this.n = n;
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
            Vector result = new Vector(n);
            result.Nullify();
            if (n == x.Size)
            {
                for (int i = 0; i < n; i++)// обрабатываем i строку
                {
                    for (int j = i-1, count = 0; j >= 0 && count < bandWidth; j--, count++)// обработка нижнего треугольника
                        result[i] += al[i][count] * x[j];
                    if (UseDiagonal)
                        result[i] += di[i] * x[i];// обработка диагонального элемента
                }
                return result;
            }
            else
                throw new NotImplementedException();
        }

        public override Vector LSolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector LtMult(Vector x, bool UseDiagonal)
        {
            Vector result = new Vector(n);
            result.Nullify();
            if (n == x.Size)
            {
                for (int i = 0; i < n; i++)// обрабатываем i строку
                {
                    for (int j = i + 1, count = 0; j < n && count < bandWidth; j++, count++)// обработка нижнего транспонированного треугольника
                        result[i] += al[j - i][count] * x[j];
                    if (UseDiagonal)
                        result[i] += di[i] * x[i];// обработка диагонального элемента
                }
                return result;
            }
            else
                throw new NotImplementedException();
        }

        public override Vector LtSolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector UMult(Vector x, bool UseDiagonal)
        {
            Vector result = new Vector(n);
            result.Nullify();
            if (n == x.Size)
            {
                for (int i = 0; i < n; i++)// обрабатываем i строку
                {
                    for (int j = i + 1, count = 0; j < n && count < bandWidth; j++, count++)// обработка верхнего треугольника
                        result[i] += au[j-i][count] * x[j];
                    if (UseDiagonal)
                        result[i] += di[i] * x[i];// обработка диагонального элемента
                }
                return result;
            }
            else
                throw new NotImplementedException();
        }

        public override Vector USolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector UtMult(Vector x, bool UseDiagonal)
        {
            Vector result = new Vector(n);
            result.Nullify();
            if (n == x.Size)
            {
                for (int i = 0; i < n; i++)// обрабатываем i строку
                {
                    for (int j = i - 1, count = 0; j >= 0 && count < bandWidth; j--, count++)// обработка верхнего транспонирвоанного треугольника
                        result[i] += au[i][count] * x[j];
                    if (UseDiagonal)
                        result[i] += di[i] * x[i];// обработка диагонального элемента
                }
                return result;
            }
            else
                throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
