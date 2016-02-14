using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project
{
    interface IVector
    {
        double this[int i] { get; set; }
        double Norm();
        void Nullify();
        int Size { get; }
    }
}
