using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;
using toop_project.src.Matrix;

namespace toop_project.src.Preconditioner
{
    public class LUPreconditioner : IPreconditioner
    {
        BaseMatrix lUmatrix;
        BaseMatrix sourceMatrix;

        public BaseMatrix LUmatrix
        {
            get
            {
                return lUmatrix;
            }

            private set
            {
                lUmatrix = value;
            }
        }
        public BaseMatrix SourceMatrix
        {
            get
            {
                return sourceMatrix;
            }
        }
        public Type Type
        {
            get
            {
                return Type.LU;
            }
        }

        private LUPreconditioner() { }

        public static LUPreconditioner Create(BaseMatrix source)
        {
            return new LUPreconditioner()
            {
                sourceMatrix = source,
                LUmatrix = source.LU()
            };
        }

        public Vector QMultiply(Vector x)
        {
            throw new NotImplementedException();
        }

        public Vector QSolve(Vector x)
        {
            throw new NotImplementedException();
        }

        public Vector SMultiply(Vector x)
        {
            throw new NotImplementedException();
        }

        public Vector SSolve(Vector x)
        {
            throw new NotImplementedException();
        }
    }
}
