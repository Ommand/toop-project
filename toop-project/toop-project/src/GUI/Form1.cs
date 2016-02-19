using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using toop_project.src.Matrix;

namespace toop_project
{
    public partial class Form1 : Form
    {
		private BaseMatrix matrix;
        public Form1()
        {
            InitializeComponent();
			InputOutput.InputMatrix("D:\\Git\\toop-project\\toop-project\\toop-project\\band.txt", out matrix);
        }
    }
}
