using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Vector_;
using toop_project.src.Matrix;

namespace toop_project.src.Preconditioner
{
    class LLTPreconditioner : IPreconditioner
    {
        BaseMatrix lLTmatrix;
        BaseMatrix sourceMatrix;

        public BaseMatrix LLTmatrix
        {
            get
            {
                return lLTmatrix;
            }

            private set
            {
                lLTmatrix = value;
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
                return Type.LLT;
            }
        }

        private LLTPreconditioner() { }

        public static LLTPreconditioner Create(BaseMatrix source)
        {
            return new LLTPreconditioner()
            {
                sourceMatrix = source,
                LLTmatrix = source.LLt()
            };
        }

        public Vector QMultiply(Vector x)
        {
            return lLTmatrix.UMult(x, true);
        }

        public Vector QSolve(Vector x)
        {
            return lLTmatrix.USolve(x, true);
        }

        public Vector SMultiply(Vector x)
        {
            return lLTmatrix.LMult(x, true);
        }

        public Vector SSolve(Vector x)
        {
            return lLTmatrix.LSolve(x, true);
        }
    }
}
