using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;
using toop_project.src.Preconditioner;

namespace toop_project.src.Matrix
{
    class DenseMatrix : BaseMatrix,IPreconditioner
    {
        private double[][] a;
        private int n;
        public DenseMatrix(double[][] a)
        {
            this.a = a;
            n = a.GetUpperBound(0) + 1;// размер матрицы = индекс последнего элемента 0 измерения + 1 
        }

        #region Matrix
        public override Vector Diagonal
        {
            get
            {
                Vector v = new Vector(n);
                for (int i = 0; i < n; i++)
                    v[i] = a[i][i];
                return v;
            }
        }

        public override int Size
        {
            get
            {
                return n; ;
            }
        }

        public override Vector LMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов LMult");
            else
            {
                if(UseDiagonal == true)
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j <= i; j++)
                            v[i] += a[i][j] * x[j];
                    return v;
                }
                else
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < i; j++)
                            v[i] += a[i][j] * x[j];
                    return v;
                }
                
            }
        }

        public override Vector LSolve(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов LSolve");
            else
            {
                double result;
                if (UseDiagonal == true)
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                    {
                        result = 0;
                        for (int j = 0; j < i; j++)
                            result += a[i][j] * v[j];
                        v[i] = (x[i] - result) / a[i][i];
                    }                        
                    return v;
                }
                else
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                    {
                        result = 0;
                        for (int j = 0; j < i; j++)
                            result += a[i][j] * v[j];
                        v[i] = (x[i] - result);
                    }
                    return v;
                }
            }
        }

        public override Vector LtMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов LtMult");
            else
            {
                if (UseDiagonal == true)
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j <= i; j++)
                            v[j] += a[i][j] * x[i];
                    return v;
                }
                else
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < i; j++)
                            v[j] += a[i][j] * x[i];
                    return v;
                }

            }
        }

        public override Vector LtSolve(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов LtSolve");
            else
            {
                if (UseDiagonal == true)
                {
                    Vector v;
                    v = (Vector)x.Clone();// в смысле копирование элементов
                    for (int i = n - 1; i >= 0; i--)
                    {
                       
                        for (int j = i + 1; j < n; j++)
                            v[i] -= a[j][i] * v[j];
                        v[i] /= a[i][i];
                    }
                    return v;
                }
                else
                {
                    Vector v;
                    v = (Vector)x.Clone();// в смысле копирование элементов
                    for (int i = n - 1; i >= 0; i--)
                        for (int j = i + 1; j < n; j++)
                            v[i] -= a[j][i] * v[j];
                    return v;
                }
            }
        }

        public override Vector Multiply(Vector x)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов Multiply");
            else
            {
                Vector v = new Vector(n);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        v[i] += a[i][j] *x[j];
                return v;
            }           
        }

        public override Vector TMultiply(Vector x)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов TMultiply");
            else
            {
                Vector v = new Vector(n);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        v[j] += a[i][j] * x[i];
                return v;
            }
        }

        public override Vector UMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов UMult");
            else
            {
                if (UseDiagonal == true)
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                        for (int j = i; j < n; j++)
                            v[i] += a[i][j] * x[j];
                    return v;
                }
                else
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                        for (int j = i + 1; j < n; j++)
                            v[i] += a[i][j] * x[j];
                    return v;
                }
            }
        }

        public override Vector USolve(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов USolve");
            else
            {
                if (UseDiagonal == true)
                {
                    Vector v;
                    v = (Vector)x.Clone();// в смысле копирование элементов
                    for (int i = n - 1; i >= 0; i--)
                    {
                        
                        for (int j = i + 1; j < n; j++)
                            v[i] -= a[i][j] * v[j];
                        v[i] /= a[i][i];
                    }                        
                    return v;
                }
                else
                {
                    Vector v;
                    v = (Vector)x.Clone();// в смысле копирование элементов
                    for (int i = n - 1; i >= 0; i--)                                          
                        for (int j = i + 1; j < n; j++)
                            v[i] -= a[i][j] * v[j];
                    return v;
                }
            }
        }

        public override Vector UtMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов UMult");
            else
            {
                if (UseDiagonal == true)
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                        for (int j = i; j < n; j++)
                            v[i] += a[i][j] * x[j];
                    return v;
                }
                else
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                        for (int j = i + 1; j < n; j++)
                            v[i] += a[i][j] * x[j];
                    return v;
                }

            }
        }

        public override Vector UtSolve(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов UtSolve");
            else
            {
                double result;
                if (UseDiagonal == true)
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                    {
                        result = 0;
                        for (int j = 0; j < i; j++)
                            result += a[j][i] * v[j];
                        v[i] = (x[i] - result) / a[i][i];
                    }
                    return v;
                }
                else
                {
                    Vector v = new Vector(n);
                    for (int i = 0; i < n; i++)
                    {
                        result = 0;
                        for (int j = 0; j < i; j++)
                            result += a[j][i] * v[j];
                        v[i] = (x[i] - result);
                    }
                    return v;
                }
            }
        }
        #endregion Matrix
            #region Preconditioner 
        public BaseMatrix LU()
        {
            double[][] aPrecond = new double[n][];
            for (int i = 0; i < n; i++)
            {
                aPrecond[i] = new double[n];
            }
            for (int i = 0; i < n; i++)
            {
                double sumdi = 0;
                for (int k = 0; k < i; k++)
                {
                    sumdi += aPrecond[i][k] * aPrecond[k][i];
                }
                aPrecond[i][i] = a[i][i] - sumdi;
                sumdi = 0;
                for (int j = i + 1; j < n; j++)
                {
                    double sumL = 0;
                    double sumU = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sumL += aPrecond[j][k] * aPrecond[k][i];
                        sumU += aPrecond[i][k] * aPrecond[k][j];
                    }
                    aPrecond[j][i] = a[j][i] - sumL;
                    aPrecond[i][j] = (a[i][j] - sumU) / aPrecond[i][i];
                }
            }
            return new DenseMatrix(aPrecond);
        }
        public BaseMatrix LUsq()
        {
            double[][] aPrecond = new double[n][];
            for (int i = 0; i < n; i++)
            {
                aPrecond[i] = new double[n];
            }
            for (int i = 0; i < n; i++)
            {
                double sumdi = 0;
                for (int k = 0; k < i; k++)
                {
                    sumdi += aPrecond[i][k] * aPrecond[k][i];
                }
                aPrecond[i][i] = Math.Sqrt(a[i][i] - sumdi);
                sumdi = 0;
                for (int j = i + 1; j < n; j++)
                {
                    double sumL = 0;
                    double sumU = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sumL += aPrecond[j][k] * aPrecond[k][i];
                        sumU += aPrecond[i][k] * aPrecond[k][j];
                    }
                    aPrecond[j][i] = (a[j][i] - sumL) / aPrecond[i][i];
                    aPrecond[i][j] = (a[i][j] - sumU) / aPrecond[i][i];
                }
            }
            return new DenseMatrix(aPrecond);
        }
        public BaseMatrix LLt() 
        {
            double[][] aPrecond = new double[n][];
            for (int i = 0; i < n; i++)
            {
                aPrecond[i] = new double[n];
            }
            for (int i = 0; i < n; i++)
            {
                double sumdi = 0;
                for (int k = 0; k < i; k++)
                {
                    sumdi += aPrecond[i][k] * aPrecond[i][k];
                }
                aPrecond[i][i] = Math.Sqrt(a[i][i] - sumdi);
                sumdi = 0;
                for (int j = i + 1; j < n; j++)
                {
                    double sumL = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sumL += aPrecond[j][k] * aPrecond[k][i];
                    }
                    aPrecond[j][i] = aPrecond[i][j] = (a[j][i] - sumL) / aPrecond[i][i];
                }
            }
            return new DenseMatrix(aPrecond);
        }

#endregion Preconditioner
    }
}
