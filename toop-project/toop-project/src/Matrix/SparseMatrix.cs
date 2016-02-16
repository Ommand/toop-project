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

        public override Vector Multiply(Vector x)
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
}
