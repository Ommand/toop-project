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
        Vector diagsqrt;
        BaseMatrix sourceMatrix;
        private DiagonalPreconditioner() { }
        static public DiagonalPreconditioner Create(BaseMatrix matrix)
        {

            return new DiagonalPreconditioner()
            {
                sourceMatrix = matrix,
                diagsqrt = Sqrt(matrix)
            };
        }

        private static Vector Sqrt(BaseMatrix matrix)
        {
            var vec = matrix.Diagonal.Clone() as Vector;
            for (int i = 0; i < vec.Size; i++)
            {
                vec[i] = Math.Sqrt(vec[i]);
                if (!(vec[i] == vec[i]))
                    throw new Exception(String.Concat("Предобусловливание Diagonal : извлечение корня из отричательного числа, элемент диагонали №", i));
            }
            return vec;
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
            return Vector.Mult(x, diagsqrt);
        }

        public Vector QSolve(Vector x)
        {
            return Vector.Mult(x, Vector.Inverse(diagsqrt));
        }

        public Vector SMultiply(Vector x)
        {
            return Vector.Mult(x, diagsqrt);
        }

        public Vector SSolve(Vector x)
        {
            return Vector.Mult(x, Vector.Inverse(diagsqrt));
        }
    }
}
