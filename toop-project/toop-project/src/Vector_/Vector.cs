using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Vector_
{
    public class Vector: ICloneable
    {
        private double[] _vector;

        private Vector(double[] v) { _vector = v;}
		
        public Vector(int capacity)
        {
            _vector = new double[capacity];
        }

        public object Clone()
        {
            var vec = _vector.Clone() as double[];
			
			Vector newvec = new Vector(vec);
			return newvec;
        }

        #region Vector

        public double this[int i]
        {
            get
            {
                return _vector[i];
            }

            set
            {
                _vector[i] = value;
            }
        }

        public int Size
        {
            get
            {
                return _vector.Length;
            }
        }

        public static Vector operator *(Vector v, double multiple)
        {
            Vector vector = new Vector(v.Size);
            for (int index = 0; index < v.Size; index++)
            {
                vector[index] = multiple * v[index];
            }
            return vector;
        }

        public double Norm()
        {
            return Math.Sqrt(_vector.Select(value => value * value).Sum());
        }

        public void Nullify()
        {
            for (int index = 0; index < _vector.Length; index++)
            {
                _vector[index] = 0;
            }
        }
        public Vector Mult(Vector v1, Vector v2)
        {
            if (v1.Size == v2.Size)
            {
                Vector vector = new Vector(v1.Size);
                for (int index = 0; index < v1.Size; index++)
                {
                    vector[index] = v1[index] * v2[index];
                }
                return vector;
            }
            else
                throw new Exception("Несовпадение длин у операндов при умножении векторов");
        }

        public Vector Division(Vector v1, Vector v2)
        {
            if (v1.Size == v2.Size)
            {
                Vector vector = new Vector(v1.Size);
                for (int index = 0; index < v1.Size; index++)
                {
                    vector[index] = v1[index] / v2[index];
                }
                return vector;
            }
            else
                throw new Exception("Несовпадение длин у операндов при делении векторов");
        }

        public static double operator *(Vector v1, Vector v2)
        {
            double sum = 0;
            if (v1.Size == v2.Size)
            {
                for (int index = 0; index < v1.Size; index++)
                {
                    sum += v1[index] * v2[index];
                }
                return sum;
            }
            else
                throw new Exception("Несовпадение длин у операндов при скалярном умножении");// Разобраться с типом исключения
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.Size == v2.Size)
            {
                Vector vector = new Vector(v1.Size);
                for (int index = 0; index < v1.Size; index++)
                {
                    vector[index] = v1[index] + v2[index];
                }
                return vector;
            }
            else
                throw new Exception("Несовпадение длин у операндов при сложении");
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            if (v1.Size == v2.Size)
            {
                Vector vector = new Vector(v1.Size);
                for (int index = 0; index < v1.Size; index++)
                {
                    vector[index] = v1[index] - v2[index];
                }
                return vector;
            }
            else
                throw new Exception("Несовпадение длин у операндов при вычитании");
        }

        #endregion Vector
    }
}