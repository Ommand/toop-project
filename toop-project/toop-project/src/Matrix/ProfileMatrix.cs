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
        private int[] _ig;
        private double[] _al;
        private double[] _au;
        private double[] _di;
        private int _count;

        public ProfileMatrix(int[] ig , double[] al , double[] au, double[] di)
        {
            _ig = ig;
            _al = al;
            _au = au;
            _di = di;
            _count = di.Length;
            if (_ig.Length != _count + 1 || _ig[_count] != al.Length 
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

            Vector vector = new Vector(_count);
     
            for (int row = 0; row < _count; row++)
            {
                int index = _ig[row];
                for (int column = row - (_ig[row + 1] - index); column < row; column++,index++)
                    vector[row] += _al[index] * x[column];
            }
                      
            if (UseDiagonal)
                for (int index = 0; index < _count; index++)
                    vector[index] += _di[index] * x[index];
            return vector;

        }

        public override Vector UMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != _count)
                throw new Exception("Несовпадение длин у операндов UMult");

            Vector vector = new Vector(_count);

            for (int column = 0; column < _count; column++)
            {
                int index = _ig[column];
                for (int row = column - (_ig[column + 1] - index); row < column; row++, index++)
                    vector[row] += _al[index] * x[column];
            }

            if (UseDiagonal)
                for (int index = 0; index < _count; index++)
                    vector[index] += _di[index] * x[index];
            return vector;
        }

        public override Vector LtMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != _count)
                throw new Exception("Несовпадение длин у операндов LtMult");

            Vector vector = new Vector(_count);

            for (int row = 0; row < _count; row++)
            {
                int index = _ig[row];
                for (int column = row - (_ig[row + 1] - index); column < row; column++, index++)
                    vector[column] += _al[index] * x[row];
            }

            if (UseDiagonal)
                for (int index = 0; index < _count; index++)
                    vector[index] += _di[index] * x[index];
            return vector;
        }

        public override Vector UtMult(Vector x, bool UseDiagonal)
        {
            if (x.Size != _count)
                throw new Exception("Несовпадение длин у операндов UtMult");

            Vector vector = new Vector(_count);

            for (int column = 0; column < _count; column++)
            {
                int index = _ig[column];
                for (int row = column - (_ig[column + 1] - index); row < column; row++, index++)
                    vector[column] += _al[index] * x[row];
            }

            if (UseDiagonal)
                for (int index = 0; index < _count; index++)
                    vector[index] += _di[index] * x[index];
            return vector;
        }

        public override Vector LSolve(Vector x, bool UseDiagonal)
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

      

        public override Vector USolve(Vector x, bool UseDiagonal)
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
