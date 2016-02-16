using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    namespace toop_project.src.Preconditioner
    {
        interface IPreconditioner
        {
            void LU(toop_project.src.Matrix.BaseMatrix matrix, out toop_project.src.Matrix.BaseMatrix matrixPrecond);
            // void LLT (IMatrix matrix, out IMatrix matrixPrecond);
        }
    }

