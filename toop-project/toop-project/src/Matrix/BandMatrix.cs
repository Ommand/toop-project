﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;

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
     0  0    0    
     0  0   l11  
     0  l21 l12   
    l3  l22 1l13  
    ...........

    au:
     0  0    0    
     0  0   u11  
     0  u21 u12   
    u3  u22 u13  
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
            this.n = di.Length;
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

        public override Type Type
        {
            get
            {
                return Type.Band;
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
                    result[0] = di[0] * x[0];
                    // Обработка части al, где есть 0
                    for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                    {
                        for (int j = bandWidth - i; j < bandWidth; j++)
                            result[i] += al[i][j] * x[j + i - bandWidth];
                        result[i] += di[i] * x[i];
                    }
                    //Обработка без 0
                    for (int i = bandWidth; i < n; i++)
                    {
                        for (int j = i - bandWidth; j < i; j++)
                            result[i] += al[i][j - i + bandWidth] * x[j];
                        result[i] += di[i] * x[i];
                    }
                }
                else
                {
                    // Обработка части al, где есть 0
                    for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                        for (int j = bandWidth - i; j < bandWidth; j++)
                            result[i] += al[i][j] * x[j + i - bandWidth];
                    //Обработка без 0
                    for (int i = bandWidth; i < n; i++)
                        for (int j = i - bandWidth; j < i; j++)
                            result[i] += al[i][j - i + bandWidth] * x[j];
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
                Vector result = (Vector)x.Clone();
                if (UseDiagonal)
                {
                    result[0] /= di[0];
                    // Обработка части al, где есть 0
                    for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                    {
                        for (int j = bandWidth - i; j < bandWidth; j++)
                            result[i] -= al[i][j] * result[j + i - bandWidth];
                        result[i] /= di[i];
                    }
                    //Обработка без 0
                    for (int i = bandWidth; i < n; i++)
                    {
                        for (int j = i - bandWidth; j < i; j++)
                            result[i] -= al[i][j - i + bandWidth] * result[j];
                        result[i] /= di[i];
                    }
                }
                else
                {
                    // Обработка части al, где есть 0
                    for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                        for (int j = bandWidth - i; j < bandWidth; j++)
                            result[i] -= al[i][j] * result[j + i - bandWidth];
                    //Обработка без 0
                    for (int i = bandWidth; i < n; i++)
                        for (int j = i - bandWidth; j < i; j++)
                            result[i] -= al[i][j - i + bandWidth] * result[j];
                }
                
                return result;
            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора при прямом ходе");
        }

        public override Vector LtMult(Vector x, bool UseDiagonal)
        {
            if (n == x.Size)
            {
                Vector result = new Vector(n);
                result.Nullify();
                
                for (int j = 0; j < bandWidth; j++)
                {
                    for (int i = bandWidth - j; i < n; i++)
                        result[i - bandWidth + j] += al[i][j] * x[i];
                }

                if (UseDiagonal)
                {
                    for (int i = 0; i < n; i++)
                        result[i] += di[i] * x[i];
                }

                return result;
            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и ветора при умножении нижнего(T) треугольника");
        }

        public override Vector LtSolve(Vector x, bool UseDiagonal)
        {
            if (n == x.Size)
            {
                //Vector result = new Vector(n);
                // Разобраться с присваиванием, пока обобщенно написано            
                //result =  x;
                Vector result = (Vector)x.Clone();
                if (UseDiagonal)
                {
                    result[n - 1] /= di[n - 1];
                    // без 0
                    for (int i = n - 1; i >= bandWidth; i--)
                    {
                        for (int j = bandWidth - 1; j >= 0; j--)
                            result[i + j - bandWidth] -= al[i][j] * result[i];
                        result[i - 1] /= di[i - 1];
                    }
                    // с 0 
                    for (int i = bandWidth - 1; i > 0; i--)
                    {
                        for (int j = bandWidth - 1; j >= bandWidth - i; j--)
                            result[i + j - bandWidth] -= al[i][j] * result[i];
                        result[i - 1] /= di[i - 1];
                    }

                }
                else
                {
                    // без 0
                    for (int i = n - 1; i >= bandWidth; i--)
                        for (int j = bandWidth - 1; j >= 0; j--)
                            result[i + j - bandWidth] -= al[i][j] * result[i];
                    // с 0 
                    for (int i = bandWidth - 1; i > 0; i--)
                        for (int j = bandWidth - 1; j >= bandWidth - i; j--)
                            result[i + j - bandWidth] -= al[i][j] * result[i];

                }

                return result;

            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора при прямом (T) ходе");
        }

        public override Vector UMult(Vector x, bool UseDiagonal)
        {
            if (n == x.Size)
            {
                Vector result = new Vector(n);
                result.Nullify();
                for (int j = 0; j < bandWidth; j++)
                {
                    for (int i = bandWidth - j; i < n; i++)
                        result[i - bandWidth + j] += au[i][j] * x[i];
                }

                if (UseDiagonal)
                {
                    for (int i = 0; i < n; i++)
                        result[i] += di[i] * x[i];
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
                    result[n - 1] /= di[n - 1];
                    // без 0
                    for (int i = n - 1; i >= bandWidth; i--)
                    {
                        for (int j = bandWidth - 1; j >= 0; j--)
                            result[i + j - bandWidth] -= au[i][j] * result[i];
                        result[i - 1] /= di[i - 1];
                    }
                    // с 0 
                    for (int i = bandWidth - 1; i > 0; i--)
                    {
                        for (int j = bandWidth - 1; j >= bandWidth - i; j--)
                            result[i + j - bandWidth] -= au[i][j] * result[i];
                        result[i - 1] /= di[i - 1];
                    }

                }
                else
                {
                    // без 0
                    for (int i = n - 1; i >= bandWidth; i--)
                        for (int j = bandWidth - 1; j >= 0; j--)
                            result[i + j - bandWidth] -= au[i][j] * result[i];
                    // с 0 
                    for (int i = bandWidth - 1; i > 0; i--)
                        for (int j = bandWidth - 1; j >= bandWidth - i; j--)
                            result[i + j - bandWidth] -= au[i][j] * result[i];
                        
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
                    result[0] = di[0] * x[0];
                    // Обработка части al, где есть 0
                    for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                    {
                        for (int j = bandWidth - i; j < bandWidth; j++)
                            result[i] += au[i][j] * x[j + i - bandWidth];
                        result[i] += di[i] * x[i];
                    }
                    //Обработка без 0
                    for (int i = bandWidth; i < n; i++)
                    {
                        for (int j = i - bandWidth; j < i; j++)
                            result[i] += au[i][j - i + bandWidth] * x[j];
                        result[i] += di[i] * x[i];
                    }
                }
                else
                {
                    // Обработка части al, где есть 0
                    for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                        for (int j = bandWidth - i; j < bandWidth; j++)
                            result[i] += au[i][j] * x[j + i - bandWidth];
                    //Обработка без 0
                    for (int i = bandWidth; i < n; i++)
                        for (int j = i - bandWidth; j < i; j++)
                            result[i] += au[i][j - i + bandWidth] * x[j];
                }

                return result;
            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора при умножении верхнего(T) треугольника");
        }

        public override Vector UtSolve(Vector x, bool UseDiagonal)
        {
            if (n == x.Size)
            {

                Vector result = (Vector)x.Clone();
                if (UseDiagonal)
                {
                    result[0] /= di[0];
                    // Обработка части al, где есть 0
                    for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                    {
                        for (int j = bandWidth - i; j < bandWidth; j++)
                            result[i] -= au[i][j] * result[j + i - bandWidth];
                        result[i] /= di[i];
                    }
                    //Обработка без 0
                    for (int i = bandWidth; i < n; i++)
                    {
                        for (int j = i - bandWidth; j < i; j++)
                            result[i] -= au[i][j - i + bandWidth] * result[j];
                        result[i] /= di[i];
                    }
                }
                else
                {
                    // Обработка части al, где есть 0
                    for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                        for (int j = bandWidth - i; j < bandWidth; j++)
                            result[i] -= au[i][j] * result[j + i - bandWidth];
                    //Обработка без 0
                    for (int i = bandWidth; i < n; i++)
                        for (int j = i - bandWidth; j < i; j++)
                            result[i] -= au[i][j - i + bandWidth] * result[j];
                }

                return result;
            }
            else
                throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора при обратном (T) ходе");
        }

        public override Vector Multiply(Vector x)
        {
            Vector result = new Vector(n);
            result.Nullify();
            if (n == x.Size)
            {
                // Нижний треугольник
                // Обработка части al, где есть 0
                for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                    for (int j = bandWidth - i; j < bandWidth; j++)
                        result[i] += al[i][j] * x[j + i - bandWidth];
                //Обработка без 0
                for (int i = bandWidth; i < n; i++)
                    for (int j = i - bandWidth; j < i; j++)
                        result[i] += al[i][j - i + bandWidth] * x[j];

                //Диагональ
                for (int i = 0; i < n; i++)
                    result[i] += di[i] * x[i];

                //Верхний треугольник
                for (int j = 0; j < bandWidth; j++)
                {
                    for (int i = bandWidth - j; i < n; i++)
                        result[i - bandWidth + j] += au[i][j] * x[i];
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
                // Верхний треугольник
                // Обработка части au, где есть 0
                for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                    for (int j = bandWidth - i; j < bandWidth; j++)
                        result[i] += au[i][j] * x[j + i - bandWidth];
                //Обработка без 0
                for (int i = bandWidth; i < n; i++)
                    for (int j = i - bandWidth; j < i; j++)
                        result[i] += au[i][j - i + bandWidth] * x[j];

                //Диагональ
                for (int i = 0; i < n; i++)
                    result[i] += di[i] * x[i];

                //Нижний треугольник
                for (int j = 0; j < bandWidth; j++)
                {
                    for (int i = bandWidth - j; i < n; i++)
                        result[i - bandWidth + j] += al[i][j] * x[i];
                }

                return result;
            }
            throw new Exception("Ленточный формат: Несовпадение размерностей матрицы и вектора при умножении(T)");
        }

        public override void Run(Action<int, int, double> fun)
        {
            // Нижний треугольник
            // Обработка части al, где есть 0
            for (int i = 1; i < bandWidth; i++)// обрабатываем i строку
                for (int j = bandWidth - i; j < bandWidth; j++)
                    fun(i, j + i - bandWidth, al[i][j]);

            //Обработка без 0
            for (int i = bandWidth; i < n; i++)
                for (int j = i - bandWidth; j < i; j++)
                    fun(i, j, al[i][j - i + bandWidth]);

            //Диагональ
            for (int i = 0; i < n; i++)
                fun(i, i, di[i]);

            //Верхний треугольник
            for (int j = 0; j < bandWidth; j++)
                for (int i = bandWidth - j; i < n; i++)
                    fun(i - bandWidth + j, i, au[i][j]);
        }

        #endregion

        #region Preconditioner
        public override BaseMatrix LU()
        {
            double[] diPrecond = new double[n];
            double[][] alPrecond = new double[n][];
            double[][] auPrecond = new double[n][];
            for (int i = 0; i < n; i++)
            {
                alPrecond[i] = new double[bandWidth];
                auPrecond[i] = new double[bandWidth];
            }
            for (int i = 0; i < n; i++)
            {
                double diSum = 0;
                for (int k = 0; k < bandWidth; k++)
                {
                    diSum += alPrecond[i][k] * auPrecond[i][k];
                }
                diPrecond[i] = di[i] - diSum;
                diSum = 0;
                int countRow = Math.Min(i + bandWidth + 1, n);
                for (int j = i + 1; j < countRow; j++)
                {
                    double sumL = 0;
                    double sumU = 0;
                    for (int k = i - (j - bandWidth) - 1, p = bandWidth - 1; k >= 0; k--, p--)
                    {
                        sumL += alPrecond[j][k] * auPrecond[i][p];
                        sumU += alPrecond[i][p] * auPrecond[j][k];
                    }
                    alPrecond[j][i - (j - bandWidth)] = al[j][i - (j - bandWidth)] - sumL;
                    auPrecond[j][i - (j - bandWidth)] = (au[j][i - (j - bandWidth)] - sumU) / diPrecond[i];
                }
            }
            return new BandMatrix(bandWidth, diPrecond, alPrecond, auPrecond);
        }
        public override BaseMatrix LUsq()
        {
            double[] diPrecond = new double[n];
            double[][] alPrecond = new double[n][];
            double[][] auPrecond = new double[n][];
            for (int i = 0; i < n; i++)
            {
                alPrecond[i] = new double[bandWidth];
                auPrecond[i] = new double[bandWidth];
            }
            for (int i = 0; i < n; i++)
            {
                double diSum = 0;
                for (int k = 0; k < bandWidth; k++)
                {
                    diSum += alPrecond[i][k] * auPrecond[i][k];
                }
                diPrecond[i] = Math.Sqrt(di[i] - diSum);
                diSum = 0;
                int countRow = Math.Min(i + bandWidth + 1, n);
                for (int j = i + 1; j < countRow; j++)
                {
                    double sumL = 0;
                    double sumU = 0;
                    for (int k = i - (j - bandWidth) - 1, p = bandWidth - 1; k >= 0; k--, p--)
                    {
                        sumL += alPrecond[j][k] * auPrecond[i][p];
                        sumU += alPrecond[i][p] * auPrecond[j][k];
                    }
                    alPrecond[j][i - (j - bandWidth)] = (al[j][i - (j - bandWidth)] - sumL) / diPrecond[i];
                    auPrecond[j][i - (j - bandWidth)] = (au[j][i - (j - bandWidth)] - sumU) / diPrecond[i];
                }
            }
            return new BandMatrix(bandWidth, diPrecond, alPrecond, auPrecond);
        }
        public override BaseMatrix LLt()
        {
            double[] diPrecond = new double[n];
            double[][] alPrecond = new double[n][];
            for (int i = 0; i < n; i++)
            {
                alPrecond[i] = new double[bandWidth];
            }
            for (int i = 0; i < n; i++)
            {
                double diSum = 0;
                for (int k = 0; k < bandWidth; k++)
                {
                    diSum += alPrecond[i][k] * alPrecond[i][k];
                }
                diPrecond[i] = Math.Sqrt(di[i] - diSum);
                diSum = 0;
                int countRow = Math.Min(i + bandWidth + 1, n);
                for (int j = i + 1; j < countRow; j++)
                {
                    double sumL = 0;
                    for (int k = i - (j - bandWidth) - 1, p = bandWidth - 1; k >= 0; k--, p--)
                    {
                        sumL += alPrecond[j][k] * alPrecond[i][p];
                    }
                    alPrecond[j][i - (j - bandWidth)] = (al[j][i - (j - bandWidth)] - sumL) / diPrecond[i];
                }
            }
            return new BandMatrix(bandWidth, diPrecond, alPrecond, alPrecond);
        }
        #endregion Preconditioner
    }
}

