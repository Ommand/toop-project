using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Vector_
{
    public class Vector
    {
        private IList<double> _vector;

        public Vector()
        {
            _vector = new List<double>();
        }

        public Vector(int capacity)
        {
            _vector = new List<double>(capacity);
        }

        public void Add(double value)
        {
            _vector.Add(value);
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
                return _vector.Count;
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
            for (int index = 0; index < _vector.Count; index++)
            {
                _vector[index] = 0;
            }
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
                throw new Exception("Не совпадение длин у операндов при скалярном умножении");// Разобраться с типом исключения
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
                throw new Exception("Не совпадение длин у операндов при сложении");
        }

        public static Vector operator =(Vector v1, Vector v2)
        {
            if (v1.Size == v2.Size)
            {
                for (int i = 0; i < v1.Size; i++)
                    v1[i] = v2[i];
                return v1;
            }
            else
                throw new Exception("Не совпадение длин у операндов при присваивании");
        }
        #endregion Vector
    }
}