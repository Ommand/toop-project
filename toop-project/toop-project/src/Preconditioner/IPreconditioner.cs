using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
using toop_project.src.Vector_;

    namespace toop_project.src.Preconditioner
    {
        public enum Type {
            LU,
            LLT,
            LUsq
        }
         public interface IPreconditioner
        {
       
           BaseMatrix SourceMatrix { get; }
           Type Type { get; }
        //SAQ-общий случай
        Vector SMultiply(Vector x);
           Vector QMultiply(Vector x);
           Vector SSolve(Vector x);
           Vector QSolve(Vector x);
         }
    }

