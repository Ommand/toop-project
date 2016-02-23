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

        public override void Run(Action<int, int, double> fun)
        {

            for (int row = 0; row < _count; row++)
            {
                int index = _ig[row];
                for (int column = row - (_ig[row + 1] - index); column < row; column++, index++)
                {
                    fun(row, column, _al[index]);
                    fun(column, row, _au[index]);
                }
                fun(row, row, _di[row]);
            }
        }

        #endregion Matrix

        #region Preconditioner
        public BaseMatrix LU()
        {
            int[] igPrecond = new int[_count + 1];
            for (int i = 0; i < _count + 1; i++)
                igPrecond[i] = _ig[i];
            double[] alPrecond = new double[_al.Count()];
            double[] auPrecond = new double[_au.Count()];
            double[] diPrecond = new double[_count];
            for (int i = 0; i < _count; i++)
            {
                double diSum = 0;
                for (int k = _ig[i]; k < _ig[i + 1]; k++)
                {
                    diSum += alPrecond[k] * auPrecond[k];
                }
                diPrecond[i] = _di[i] - diSum;
                diSum = 0;
                for (int j = i + 1; j < _count; j++)
                {
                    int minCount = Math.Min(i - (j - (_ig[j + 1] - _ig[j])), _ig[i + 1] - _ig[i]);
                    if (minCount >= 0)
                    {
                        double sumL = 0;
                        double sumU = 0;
                        for (int k = _ig[j] + (i - (j - (_ig[j + 1] - _ig[j]))) - 1, p = _ig[i + 1] - 1, m = 0; m < minCount; m++, k--, p--)
                        {
                            sumL += alPrecond[k] * auPrecond[p];
                            sumU += alPrecond[p] * auPrecond[k];
                        }
                        int index = _ig[j] + (i - (j - (_ig[j + 1] - _ig[j])));
                        alPrecond[index] = _al[index] - sumL;
                        auPrecond[index] = (_au[index] - sumU) / diPrecond[i];
                    }
                }
            }
            return new ProfileMatrix(igPrecond, alPrecond, auPrecond, diPrecond);
        }
        public BaseMatrix LLt()
        {
            int[] igPrecond = new int[_count + 1];
            for (int i = 0; i < _count + 1; i++)
                igPrecond[i] = _ig[i];
            double[] alPrecond = new double[_al.Count()];
            double[] diPrecond = new double[_count];
            for (int i = 0; i < _count; i++)
            {
                double diSum = 0;
                for (int k = _ig[i]; k < _ig[i + 1]; k++)
                {
                    diSum += alPrecond[k] * alPrecond[k];
                }
                diPrecond[i] = Math.Sqrt(_di[i] - diSum);
                diSum = 0;
                for (int j = i + 1; j < _count; j++)
                {
                    int minCount = Math.Min(i - (j - (_ig[j + 1] - _ig[j])), _ig[i + 1] - _ig[i]);
                    if (minCount >= 0)
                    {
                        double sumL = 0;
                        for (int k = _ig[j] + (i - (j - (_ig[j + 1] - _ig[j]))) - 1, p = _ig[i + 1] - 1, m = 0; m < minCount; m++, k--, p--)
                        {
                            sumL += alPrecond[k] * alPrecond[p];
                        }
                        int index = _ig[j] + (i - (j - (_ig[j + 1] - _ig[j])));
                        alPrecond[index] = (_al[index] - sumL) / diPrecond[i];
                    }
                }
            }
            return new ProfileMatrix(igPrecond, alPrecond, alPrecond, diPrecond);
        }
        public BaseMatrix LUsq()
        {
            int[] igPrecond = new int[_count + 1];
            for (int i = 0; i < _count + 1; i++)
                igPrecond[i] = _ig[i];
            double[] alPrecond = new double[_al.Count()];
            double[] auPrecond = new double[_au.Count()];
            double[] diPrecond = new double[_count];
            for (int i = 0; i < _count; i++)
            {
                double diSum = 0;
                for (int k = _ig[i]; k < _ig[i + 1]; k++)
                {
                    diSum += alPrecond[k] * auPrecond[k];
                }
                diPrecond[i] = Math.Sqrt(_di[i] - diSum);
                diSum = 0;
                for (int j = i + 1; j < _count; j++)
                {
                    int minCount = Math.Min(i - (j - (_ig[j + 1] - _ig[j])), _ig[i + 1] - _ig[i]);
                    if (minCount >= 0)
                    {
                        double sumL = 0;
                        double sumU = 0;
                        for (int k = _ig[j] + (i - (j - (_ig[j + 1] - _ig[j]))) - 1, p = _ig[i + 1] - 1, m = 0; m < minCount; m++, k--, p--)
                        {
                            sumL += alPrecond[k] * auPrecond[p];
                            sumU += alPrecond[p] * auPrecond[k];
                        }
                        int index = _ig[j] + (i - (j - (_ig[j + 1] - _ig[j])));
                        alPrecond[index] = (_al[index] - sumL) / diPrecond[i];
                        auPrecond[index] = (_au[index] - sumU) / diPrecond[i];
                    }
                }
            }
            return new ProfileMatrix(igPrecond, alPrecond, auPrecond, diPrecond);
        }
        #endregion Preconditioner
    }
}
