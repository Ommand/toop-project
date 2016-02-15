using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Vector
{
    interface IVector
    {
        double this[int i] { get; set; }
        double Norm();// Вычисление нормы
        double ScalarMult(IVector vec);// Скалярное умножение векторов
        IVector SumVectors(IVector vec);// Сложение векторов
        IVector ConstMult(double x);// Умножение вектора на число
        void Nullify();// Занулить вектор
        int Size { get; }
    }

    
    
        class Vector : IVector
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

            #region IVector

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

            public IVector ConstMult(double multiple)
            {
                Vector vector = new Vector();
                foreach (var value in _vector)
                {
                    vector.Add(multiple * value);
                }
                return vector;
            }

            public double Norm()
            {
                return Math.Sqrt(_vector.Select(value => value * value).Sum());
            }

            public void Nullify()
            {
                _vector.Clear();
            }

            public double ScalarMult(IVector vec)
            {
                double sum = 0;
                for (int index = 0; index < vec.Size; index++)
                {
                    sum += _vector[index] * vec[index];
                }
                return sum;
            }

            public IVector SumVectors(IVector vec)
            {
                Vector vector = new Vector();
                for (int index = 0; index < vec.Size; index++)
                {
                    vector[index] = _vector[index] + vec[index];
                }
                return vector;
            }

            #endregion IVector
        }
    }
