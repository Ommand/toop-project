using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Vector_;

namespace toop_project.src.Preconditioner
{
    class DiagonalPreconditioner : IPreconditioner
    {
        Vector diag;
        BaseMatrix sourceMatrix;
        private DiagonalPreconditioner() { }
        static public DiagonalPreconditioner Create(BaseMatrix matrix)
        {
            return new DiagonalPreconditioner()
            {
                sourceMatrix = matrix,
                diag = matrix.Diagonal
            };
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
                return Type.Diagonal;
            }
        }

        public Vector QMultiply(Vector x)
        {
            return x.Clone() as Vector;
        }

        public Vector QSolve(Vector x)
        {
            return x.Clone() as Vector;
        }

        public Vector SMultiply(Vector x)
        {
            return Vector.Mult(x, diag);
        }

        public Vector SSolve(Vector x)
        {
            return Vector.Mult(x, Vector.Inverse(diag));
        }
    }
}
