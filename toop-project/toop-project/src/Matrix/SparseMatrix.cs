using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Preconditioner;
using toop_project.src.Vector_;
namespace toop_project.src.Matrix
{
    public class SparseMatrix : BaseMatrix , IPreconditioner 
    {
        private int[] ia;
        private int[] ja;
        private double[] al;
        private double[] au;
        private double[] di;
        private int n;
        public SparseMatrix(int[] ia, int[] ja, double[] al, double[] au, double[] di)
        {
            this.ia = ia;
            this.ja = ja;
            this.al = al;
            this.au = au;
            this.di = di;
            n = di.Count();
        }
        #region Matrix

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
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов LMult");
            else
            {
                int i, j;
                Vector v = new Vector(n);
                if (UseDiagonal == true)//  если умножение с диагональю 
                {
                    for (i = 0; i < n; i++)
                    {
                        v[i] = di[i] * x[i];
                        for (j = ia[i]; j < ja[i + 1]; j++)
                            v[i] += al[j] * x[ja[j]];
                    }
                    return v;
                }
                else// если без диагонали
                {
                    for (i = 0; i < n; i++)
                        for (j = ia[i]; j < ja[i + 1]; j++)
                            v[i] += al[j] * x[ja[j]];

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
                int i, j;
                double result;
                Vector v = new Vector(n);
                if (UseDiagonal == true)// Деление на динагональ
                {
                    for (i = 0; i < n; i++)
                    {
                        result = 0;
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            result += al[j] * v[ja[j]];
                        v[i] = (x[i] - result) / di[i];
                    }
                    return v;
                }
                else// Без деления на диагональ
                {
                    for (i = 0; i < n; i++)
                    {
                        result = 0;
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            result += al[j] * v[ja[j]];
                        v[i] = (x[i] - result);
                    }
                    return v;
                }
            }
        }

        public override Vector LtMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов при LtMult");
            else
            {
                int i, j;
                Vector v = new Vector(n);
                if (UseDiagonal == true)//  если умножение с диагональю 
                {
                    for (i = 0; i < n; i++)
                    {
                        v[i] = di[i] * x[i];
                        for (j = ia[i]; j < ja[i + 1]; j++)
                            v[ja[j]] += al[j] * x[i];
                    }
                    return v;
                }
                else// если без диагонали
                {
                    for (i = 0; i < n; i++)
                        for (j = ia[i]; j < ja[i + 1]; j++)
                            v[ja[j]] += al[j] * x[i];

                    return v;
                }
            }
        }

        public override Vector LtSolve(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов при LtSolve");
            else
            {
                int i, j;
                Vector v;
                if (UseDiagonal == true)// Деление на динагональ
                {
                    v = (Vector)x.Clone();// в смысле копирование элементов
                    for (i = n - 1; i >= 0; i--)
                    {
                        v[i] /= di[i];
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            v[ja[j]] -= al[j] * v[i];
                    }
                    return v;
                }
                else// Без деления на диагональ
                {
                    v = (Vector)x.Clone();// в смысле копирование элементов
                    for (i = n - 1; i >= 0; i--)
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            v[ja[j]] -= al[j] * v[i];
                    return v;
                }
            }
        }

        public override Vector TMultiply(Vector x)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов при TMultiply");
            else
            {
                int i, j;
                Vector v = new Vector(n);
                for (i = 0; i < n; i++)
                {
                    v[i] = di[i] * x[i];
                    for (j = ia[i]; j < ja[i + 1]; j++)
                    {
                        v[i] += au[j] * x[ja[j]];
                        v[ja[j]] += al[j] * x[i];
                    }
                }
                return v;
            }
        }

        public override Vector UMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов при UMult");
            else
            {
                int i, j;
                Vector v = new Vector(n);
                if (UseDiagonal == true)//  если умножение с диагональю 
                {
                    for (i = 0; i < n; i++)
                    {
                        v[i] = di[i] * x[i];
                        for (j = ia[i]; j < ja[i + 1]; j++)
                            v[ja[j]] += au[j] * x[i];
                    }
                    return v;
                }
                else// если без диагонали
                {
                    for (i = 0; i < n; i++)
                        for (j = ia[i]; j < ja[i + 1]; j++)
                            v[ja[j]] += au[j] * x[i];

                    return v;
                }
            }
        }

        public override Vector USolve(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов при USolve");
            else
            {
                int i, j;
                Vector v;
                if (UseDiagonal == true)// Деление на динагональ
                {
                    v = (Vector)x.Clone();// в смысле копирование элементов
                    for (i = n - 1; i >= 0; i--)
                    {
                        v[i] /= di[i];
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            v[ja[j]] -= au[j] * v[i];
                    }
                    return v;
                }
                else// Без деления на диагональ
                {
                    v = (Vector)x.Clone();// в смысле копирование элементов
                    for (i = n - 1; i >= 0; i--)
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            v[ja[j]] -= au[j] * v[i];
                    return v;
                }
            }
        }

        public override Vector UtMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов при UtMult");
            else
            {
                int i, j;
                Vector v = new Vector(n);
                if (UseDiagonal == true)//  если умножение с диагональю 
                {
                    for (i = 0; i < n; i++)
                    {
                        v[i] = di[i] * x[i];
                        for (j = ia[i]; j < ja[i + 1]; j++)
                            v[i] += au[j] * x[ja[j]];
                    }
                    return v;
                }
                else// если без диагонали
                {
                    for (i = 0; i < n; i++)
                        for (j = ia[i]; j < ja[i + 1]; j++)
                            v[i] += au[j] * x[ja[j]];

                    return v;
                }
            }
        }

        public override Vector UtSolve(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов при UtSolve");
            else
            {
                int i, j;
                double result;
                Vector v = new Vector(n);
                if (UseDiagonal == true)// Деление на динагональ
                {
                    for (i = 0; i < n; i++)
                    {
                        result = 0;
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            result += au[j] * v[ja[j]];
                        v[i] = (x[i] - result) / di[i];
                    }
                    return v;
                }
                else// Без деления на диагональ
                {
                    for (i = 0; i < n; i++)
                    {
                        result = 0;
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            result += au[j] * v[ja[j]];
                        v[i] = (x[i] - result);
                    }
                    return v;
                }
            }
        }

        public override Vector Multiply(Vector x)
        {

            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов при Multiply");
            else
            {
                int i, j;
                Vector v = new Vector(n);
                for (i = 0; i < n; i++)
                {
                    v[i] = di[i] * x[i];
                    for (j = ia[i]; j < ja[i + 1]; j++)
                    {
                        v[i] += al[j] * x[ja[j]];
                        v[ja[j]] += au[j] * x[i];
                    }
                }
                return v;
            }
        }
        #endregion Matrix

        #region Preconditioner
        public BaseMatrix LU()
        {
            return this;
        }
        public BaseMatrix LUsq()
        {
            return this;
        }
        public BaseMatrix LLt()
        {
            return this;
        }
        #endregion Preconditioner
    }
}
