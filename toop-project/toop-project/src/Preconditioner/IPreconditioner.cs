using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toop_project.src.Matrix;
    namespace toop_project.src.Preconditioner
    {
        interface IPreconditioner
        {
        BaseMatrix LU();
        BaseMatrix LLt(); // Только для симметричной матрицы, все элементы хранятся в al
        BaseMatrix LUsq();

        }
    }

