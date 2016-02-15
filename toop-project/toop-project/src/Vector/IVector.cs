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
}
