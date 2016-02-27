using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.GUI
{
    public interface IGUI {
        void UpdateLog(String message);
        void UpdateIterationLog(int iter, double residual);
        void FinishSolve();
        void ShowError(String message);
    }
}
