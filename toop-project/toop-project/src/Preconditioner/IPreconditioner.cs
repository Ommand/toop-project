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
        public interface IPreconditioner
        {
        Vector Mult(Vector v);
        }
        public class LUPreconditioner:IPreconditioner
    {
        BaseMatrix SourceMatrix;
        BaseMatrix LUmatrix;

        public static LUPreconditioner Create(BaseMatrix source)
        {
            return new LUPreconditioner()
            {
                SourceMatrix = source,
                LUmatrix = source.CreateLU()
            } ;
        }
        public Vector Mult(Vector v)
        {
            var newvec = LUmatrix.USolve(v,true);
            var newvec2 = SourceMatrix.Multiply(newvec);
            return LUmatrix.LSolve(newvec2, false);
        }
    }
    public class LUIlinPreconditioner : IPreconditioner
    {
        BaseMatrix SourceMatrix;

        public static LUIlinPreconditioner Create(BaseMatrix source)
        {
            return new LUIlinPreconditioner()
            {
                SourceMatrix = source
            };
        }
        public Vector Mult(Vector v)
        {
            var newvec = SourceMatrix.USolve(v, true);
            var newvec2 = SourceMatrix.Multiply(newvec);
            return SourceMatrix.LSolve(newvec2, false);
        }
    }

}

