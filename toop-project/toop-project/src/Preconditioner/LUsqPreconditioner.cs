using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;
using toop_project.src.Matrix;

namespace toop_project.src.Preconditioner
{
    class LUsqPreconditioner : IPreconditioner
    {
        BaseMatrix lUsqMatrix;
        BaseMatrix sourceMatrix;

        public BaseMatrix LUsqMatrix
        {
            get
            {
                return lUsqMatrix;
            }

            private set
            {
                lUsqMatrix = value;
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
                return Type.LUsq;
            }
        }

        private LUsqPreconditioner() { }

        public static LUsqPreconditioner Create(BaseMatrix source)
        {
            return new LUsqPreconditioner()
            {
                sourceMatrix = source,
                LUsqMatrix = source.LUsq()
            };
        }

        public Vector QMultiply(Vector x)
        {
            return lUsqMatrix.UMult(x, true);
            //throw new NotImplementedException();
        }

        public Vector QSolve(Vector x)
        {
            return lUsqMatrix.USolve(x, true);
        }

        public Vector SMultiply(Vector x)
        {
            return lUsqMatrix.LMult(x, true);
            throw new NotImplementedException();
        }

        public Vector SSolve(Vector x)
        {
            return lUsqMatrix.LSolve(x, true);
        }
    }
}
