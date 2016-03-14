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
        private DiagonalPreconditioner() { }
        static public DiagonalPreconditioner Create(BaseMatrix matrix)
        {
            throw new NotImplementedException();
        }
        public BaseMatrix SourceMatrix
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Type Type
        {
            get
            {
                throw new NotImplementedException();
            }
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
