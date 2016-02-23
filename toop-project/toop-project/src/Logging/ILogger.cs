using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toop_project.src.Logging
{
    public interface ILogger
    {
        void SetFile(string filename);
        void Info(string message);
        void Debug(string message);
        void Error(string message);

    }
}
