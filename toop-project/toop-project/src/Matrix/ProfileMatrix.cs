using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Preconditioner;
using toop_project.src.Vector_;

namespace toop_project.src.Matrix
{
    class ProfileMatrix : BaseMatrix, IPreconditioner
    {
        private int[] _ia;
        private double[] _al;
        private double[] _au;
        private double[] _di;
        private int _count;

        public ProfileMatrix(int[] ia , double[] al , double[] au, double[] di)
        {
            _ia = ia;
            _al = al;
            _au = au;
            _di = di;
            _count = di.Length;
            if (_ia.Length != _count + 1 || _ia[_count] != al.Length 
                 || al.Length != au.Length)
                throw new Exception("Некорректная матрица");
        }

        #region Matrix
        public override Vector Diagonal
        {
            get
            {
                Vector vector = new Vector(_count);
                for (int index = 0; index < _count; index++)
                    vector[index] = _di[index];
                return vector;
            }
        }

        public override int Size
        {
            get
            {
               return _count;
            }
        }

       

        public override Vector LMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != _count)
                throw new Exception("Несовпадение длин у операндов LMult");


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

        #region Preconditioner

        public BaseMatrix LU()
        {
            throw new NotImplementedException();
        }

        public BaseMatrix LUsq()
        {
            throw new NotImplementedException();
        }

        public BaseMatrix LLt()
        {
            throw new NotImplementedException();
        }

        #endregion Preconditioner
    }
}
