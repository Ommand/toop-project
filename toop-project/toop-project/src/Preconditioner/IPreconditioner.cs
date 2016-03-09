using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Vector_;

    namespace toop_project.src.Preconditioner
    {
        enum Type {
            LU,
            LLT,
            LUsq
        }
        public abstract class IPreconditioner
        {
            public BaseMatrix SourceMatrix;
         //SAQ-общий случай
           public abstract Vector SMultiply(Vector x);
           public abstract Vector QMultiply(Vector x);
           public abstract Vector SSolve(Vector x);
           public abstract Vector QSolve(Vector x);
    }
    }

