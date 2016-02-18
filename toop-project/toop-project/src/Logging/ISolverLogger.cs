using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Logging
{
    interface ISolverLogger
    {
        void AddIterationInfo(int num,double residual);

        void SetFile(string filename);
    }
}
