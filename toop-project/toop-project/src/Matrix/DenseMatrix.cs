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

        public override Vector LMult(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector LSolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector LtMult(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector LtSolve(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
        }

        public override Vector Multiply(Vector x)
        {
            throw new NotImplementedException();
        }

        public override Vector TMultiply(Vector x)
        {
            throw new NotImplementedException();
        }

        public override Vector UMult(Vector x, bool UseDiagonal)
        {
            throw new NotImplementedException();
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
