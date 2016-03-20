using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;
namespace toop_project.src.Matrix
{
    public class SparseMatrix : BaseMatrix 
    {
        private int[] ia;
        private int[] ja;
        private double[] al;
        private double[] au;
        private double[] di;
        private int n;

        #region Matrix
        public SparseMatrix(int[] ia, int[] ja, double[] al, double[] au, double[] di)
        {
            this.ia = ia;
            this.ja = ja;
            this.al = al;
            this.au = au;
            this.di = di;
            n = di.Count();
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
                return Type.Sparse;
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
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            v[i] += al[j] * x[ja[j]];
                    }
                    return v;
                }
                else// если без диагонали
                {
                    for (i = 0; i < n; i++)
                        for (j = ia[i]; j < ia[i + 1]; j++)
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
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            v[ja[j]] += al[j] * x[i];
                    }
                    return v;
                }
                else// если без диагонали
                {
                    for (i = 0; i < n; i++)
                        for (j = ia[i]; j < ia[i + 1]; j++)
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
                    for (j = ia[i]; j < ia[i + 1]; j++)
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
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            v[ja[j]] += au[j] * x[i];
                    }
                    return v;
                }
                else// если без диагонали
                {
                    for (i = 0; i < n; i++)
                        for (j = ia[i]; j < ia[i + 1]; j++)
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
                        for (j = ia[i]; j < ia[i + 1]; j++)
                            v[i] += au[j] * x[ja[j]];
                    }
                    return v;
                }
                else// если без диагонали
                {
                    for (i = 0; i < n; i++)
                        for (j = ia[i]; j < ia[i + 1]; j++)
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
                    for (j = ia[i]; j < ia[i + 1]; j++)
                    {
                        v[i] += al[j] * x[ja[j]];
                        v[ja[j]] += au[j] * x[i];
                    }
                }
                return v;
            }
        }

        public override void Run(Action<int, int, double> fun)
        {
            for (int i = 0; i < n; i++)
            {
                fun(i, i, di[i]);
                for (int j = ia[i]; j < ia[i + 1]; j++)
                {
                    fun(i, ja[j], al[j]);
                    fun(ja[j], i, au[j]);
                }
            }
        }

        #endregion Matrix

        #region Preconditioner
        public override BaseMatrix LU()
        {
            var matrixILU = new SparseMatrix (ia, ja, al.Clone() as double[], au.Clone() as double[], di.Clone() as double[]);
            for (int i = 0; i < matrixILU.Size; i++)
            {
                int i0 = matrixILU.ia[i];
                int i1 = matrixILU.ia[i + 1];
                double S = 0;
                for (int k = i0; k < i1; k++)
                {
                    double Sl = 0, Su = 0;
                    int iind = i0;
                    int j = matrixILU.ja[k];
                    int j0 = matrixILU.ia[j];
                    int j1 = matrixILU.ia[j + 1];
                    if (j1 - j0 != 0)
                    {
                        int jind = j0;
                        while (iind < k)
                        {
                            if (matrixILU.ja[jind] > matrixILU.ja[iind])
                                iind++;
                            else
                                if (matrixILU.ja[jind] < matrixILU.ja[iind])
                                jind++;
                            else
                            {
                                Sl += matrixILU.al[iind] * matrixILU.au[jind];
                                Su += matrixILU.au[iind] * matrixILU.al[jind];
                                iind++;
                                jind++;
                            }
                        }
                    }
                    matrixILU.au[k] = (matrixILU.au[k] - Su);
                    matrixILU.al[k] = (matrixILU.al[k] - Sl) / matrixILU.di[j];
                    if (double.IsInfinity(matrixILU.al[k]))
                        throw new Exception(String.Concat("Предобусловливание LU : на диагонали матрицы элемент №", j, " равен 0 (деление на 0)"));
                    S += matrixILU.au[k] * matrixILU.al[k]; // диагональ в U!!!!!
                }
                matrixILU.di[i] = matrixILU.di[i] - S;
            }
            return matrixILU;
        }
        public override BaseMatrix LUsq()
        {
            var matrixILU = new SparseMatrix(ia, ja, al.Clone() as double[], au.Clone() as double[], di.Clone() as double[]);
            for (int i = 0; i < matrixILU.Size; i++)
            {
                int i0 = matrixILU.ia[i];
                int i1 = matrixILU.ia[i + 1];
                int k;
                double S = 0;
                for (k = i0; k < i1; k++)
                {
                    double Sl = 0, Su = 0;
                    int iind = i0;
                    int j = matrixILU.ja[k];
                    int j0 = matrixILU.ia[j];
                    int j1 = matrixILU.ia[j + 1];
                    if (j1 - j0 != 0)
                    {
                        int jind = j0;
                        while (iind < k)
                        {
                            if (matrixILU.ja[jind] > matrixILU.ja[iind])
                                iind++;
                            else
                                if (matrixILU.ja[jind] < matrixILU.ja[iind])
                                jind++;
                            else
                            {
                                Sl += matrixILU.al[iind] * matrixILU.au[jind];
                                Su += matrixILU.au[iind] * matrixILU.al[jind];
                                iind++;
                                jind++;
                            }
                        }
                    }
                    matrixILU.au[k] = (matrixILU.au[k] - Su) / matrixILU.di[j];
                    if (double.IsInfinity(matrixILU.au[k]))
                        throw new Exception(String.Concat("Предобусловливание LUsq : на диагонали матрицы элемент №", j, " равен 0 (деление на 0)"));
                    matrixILU.al[k] = (matrixILU.al[k] - Sl) / matrixILU.di[j];
                    if (double.IsInfinity(matrixILU.al[k]))
                        throw new Exception(String.Concat("Предобусловливание LUsq : на диагонали матрицы элемент №", j, " равен 0 (деление на 0)"));
                    S += matrixILU.au[k] * matrixILU.al[k]; // диагональ в U!!!!!
                }
                matrixILU.di[i] = Math.Sqrt(matrixILU.di[i] - S);
                if (!(matrixILU.di[i] == matrixILU.di[i]))
                    throw new Exception(String.Concat("Предобусловливание LUsq : NaN для элемента диагонали №", i));
            }
            return matrixILU;
        }
        public override BaseMatrix LLt()
        {
            var new_al = al.Clone() as double[];
            var matrixLLt = new SparseMatrix(ia, ja, new_al, new_al, di.Clone() as double[]);
            for (int i = 0; i < matrixLLt.Size; i++)
            {
                int i0 = matrixLLt.ia[i];
                int i1 = matrixLLt.ia[i + 1];
                int k;
                double S = 0;
                for (k = i0; k < i1; k++)
                {
                    double Sl = 0;
                    int iind = i0;
                    int j = matrixLLt.ja[k];
                    int j0 = matrixLLt.ia[j];
                    int j1 = matrixLLt.ia[j + 1];
                    if (j1 - j0 != 0)
                    {
                        int jind = j0;
                        while (iind < k)
                        {
                            if (matrixLLt.ja[jind] > matrixLLt.ja[iind])
                                iind++;
                            else
                                if (matrixLLt.ja[jind] < matrixLLt.ja[iind])
                                jind++;
                            else
                            {
                                Sl += matrixLLt.al[iind] * matrixLLt.al[jind];
                                iind++;
                                jind++;
                            }
                        }
                    }
                    matrixLLt.al[k] = (matrixLLt.al[k] - Sl) / matrixLLt.di[j];
                    if (double.IsInfinity(matrixLLt.al[k]))
                        throw new Exception(String.Concat("Предобусловливание LLt : на диагонали матрицы элемент №", j, " равен 0 (деление на 0)"));
                    S += matrixLLt.al[k] * matrixLLt.al[k];
                }
                matrixLLt.di[i] = Math.Sqrt(matrixLLt.di[i] - S);
                if (!(matrixLLt.di[i] == matrixLLt.di[i]))
                    throw new Exception(String.Concat("Предобусловливание LLt : NaN для элемента диагонали №", i));
            }
            return matrixLLt;
        }

        #endregion Preconditioner
    }
}
