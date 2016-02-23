using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toop_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            pnlFile.DataBindings.Add(new Binding("Visible", sbtnF, "Sink"));
            pnlMatrixFormat.DataBindings.Add(new Binding("Visible", sbtnMF, "Sink"));
            pnlSolver.DataBindings.Add(new Binding("Visible", sbtnS, "Sink"));
            pnlPrecond.DataBindings.Add(new Binding("Visible", sbtnP, "Sink"));
        }

        private void panel12_Paint(object sender, PaintEventArgs e) {

        }
    }
}
