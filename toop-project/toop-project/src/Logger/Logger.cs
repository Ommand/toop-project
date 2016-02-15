using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toop_project.src.Logger
{
    class Logger
    {
        private enum MessageType
        {
            ERROR,
            DEBUG,
            INFO
        };

        private string defaultLogFile = "log/log.txt";
        private System.IO.StreamWriter fileStream;
        private List<string> log = new List<string>(); 
        private static Logger instance = new Logger();
        private Logger()
        {
            try
            {
                fileStream = new System.IO.StreamWriter(defaultLogFile, true);
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("Logger open file exception: {0}", e));
            }

        }
        private void AddLine(MessageType type,string line)
        {
            string message = String.Format("[{0}][{1}] {2}", type, DateTime.Now, line);
            log.Add(message);
            fileStream.WriteLine(message);
        }
        public static Logger Instance()
        {
            return instance;
        }

        public void SetFile(string filename)
        {
            fileStream.Close();
            fileStream = new System.IO.StreamWriter(filename);
        }

        public void Info(string message)
        {
            AddLine(MessageType.INFO, message);
        }

        public void Debug(string message)
        {
            AddLine(MessageType.DEBUG, message);
        }

        public void Error(string message)
        {
            AddLine(MessageType.ERROR, message);
        }

        public List<string> Log
        {
            get { return log; }
        }

    }
}
