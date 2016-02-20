using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;

namespace toop_project.src.Matrix
{
    class DenseMatrix : BaseMatrix
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
            throw new NotImplementedException();
        }

        public override Vector LtMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != n)
                throw new Exception("Несовпадение длин у операндов LMult");
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
            throw new NotImplementedException();
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
                throw new Exception("Несовпадение длин у операндов LMult");
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
            throw new NotImplementedException();
        }

        public override Vector UtMult(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector UtSolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }
        #endregion Matrix
    }
}
