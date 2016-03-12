using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Vector_;

namespace toop_project.src.Preconditioner
{
    public class EmptyPreconditioner : IPreconditioner
    {
        BaseMatrix sourceMatrix;
        private EmptyPreconditioner() { }

        public static EmptyPreconditioner Create(BaseMatrix source)
        {
            return new EmptyPreconditioner()
            {
                sourceMatrix = source
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
                return Type.NoPrecond;
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
            return x.Clone() as Vector;
        }

        public Vector SSolve(Vector x)
        {
            return x.Clone() as Vector;
        }
    }
}
