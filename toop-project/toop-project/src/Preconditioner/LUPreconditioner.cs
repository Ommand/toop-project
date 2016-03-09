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
         BaseMatrix LUmatrix;

        public static LUPreconditioner Create(BaseMatrix source)
         {
             return new LUPreconditioner()
             {
                 SourceMatrix = source,
                 LUmatrix = source.LU()
             };
         }

        public override Vector QMultiply(Vector x)
        {
            throw new NotImplementedException();
        }

        public override Vector QSolve(Vector x)
        {
            throw new NotImplementedException();
        }

        public override Vector SMultiply(Vector x)
        {
            throw new NotImplementedException();
        }

        public override Vector SSolve(Vector x)
        {
            throw new NotImplementedException();
        }
    }
}
