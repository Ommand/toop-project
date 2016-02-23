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
    public partial class Form1 : Form {
        src.Slae.SLAE slae = new src.Slae.SLAE();

        const String MatrixFileExtension = "mtx";
        const String RightPartFileExtension = "rtx";
        String resPath = System.IO.Path.GetFullPath(@"..\..\res\");

        OpenFileDialog ofdMatrix = new OpenFileDialog();
        OpenFileDialog ofdRightPart = new OpenFileDialog();

        public Form1() {
            InitializeComponent();
            setFileDialogs();
            setComboboxes();
            setDataBindings();
        }

        private void btnOpenFile_Click(object sender, EventArgs e) {
            if (ofdMatrix.ShowDialog() == DialogResult.OK) {
                try {
                    if (ofdMatrix.FileName != null) {
                        src.Matrix.BaseMatrix matrix;
                        List<String> log;
                        toop_project.InputOutput.InputMatrix(ofdMatrix.FileName, out matrix, out log);
                        updateDgvMatrix(matrix);
                        slae.Matrix = matrix;
                        lblMatixFileName.Text = ofdMatrix.FileName;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e) {
            // TODO: safe close thread?
            Close();
        }

        private void setDataBindings() {
            pnlFile.DataBindings.Add(new Binding("Visible", sbtnF, "Sink"));
            pnlSolver.DataBindings.Add(new Binding("Visible", sbtnS, "Sink"));
        }

        private void setComboboxes() {
            foreach (var type in Enum.GetValues(typeof(src.Matrix.Type))) 
                cmbMatrixFormat.Items.Add(type);
            foreach (var type in Enum.GetValues(typeof(src.Preconditioner.Type)))
                cmbPrecond.Items.Add(type);
            foreach (var type in Enum.GetValues(typeof(src.Solver.Type)))
                cmbSolver.Items.Add(type);
        }

        private void updateDgvMatrix(src.Matrix.BaseMatrix matrix) {
            dgvMatrix.Rows.Clear();
            dgvMatrix.Columns.Clear();
            
            for(var i=0; i < matrix.Size; i++)
                dgvMatrix.Columns.Add("","");

            for(var i=0; i < matrix.Size; i++){
                //for (var j = 0; j < matrix.Size; j++) {
                String[] strs = new String[matrix.Size];
                strs[i] = matrix.Diagonal[i].ToString();

                dgvMatrix.Rows.Add(strs);
                //}
             }
        }

        private void updateDgvRightPart(src.Vector_.Vector vec) {
            dgvRightPart.Rows.Clear();
            dgvRightPart.Columns.Clear();
            dgvRightPart.Columns.Add("", "");

            for (var i = 0; i < vec.Size; i++) {
                String[] strs = new String[1];
                strs[0] = vec[i].ToString();

                dgvRightPart.Rows.Add(strs);
            }
        }

        private void btnOpenRPFile_Click(object sender, EventArgs e) {
            if (ofdRightPart.ShowDialog() == DialogResult.OK) {
                try {
                    if (ofdRightPart.FileName != null) {
                        src.Vector_.Vector vector;
                        List<String> log;
                        toop_project.InputOutput.InputRightPart(ofdRightPart.FileName, out vector, out log);
                        updateDgvRightPart(vector);
                        slae.Right = vector;
                        lblRPFileName.Text = ofdRightPart.FileName;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnSolve_Click(object sender, EventArgs e) {
            if (!slae.CanBeComputed()) {
                MessageBox.Show("Can't compute this slae","Error");
                return;
            }
            slae.Solve();
        }

        private void cmbSolver_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbSolver.SelectedIndex < 0) { 
                slae.Solver = null;
                return;
            }
            var el = (src.Solver.Type)Enum.ToObject(typeof(src.Solver.Type), cmbSolver.SelectedIndex);
            slae.Solver = src.Solver.ISolver.getSolver(el);
        }

        private void setFileDialogs() {
            ofdMatrix.InitialDirectory = System.IO.Path.GetDirectoryName(resPath);
            ofdMatrix.Filter = MatrixFileExtension + " files (*." + MatrixFileExtension + ")|*." + MatrixFileExtension + "";
            ofdMatrix.RestoreDirectory = true;
            ofdMatrix.Multiselect = false;

            ofdRightPart.InitialDirectory = System.IO.Path.GetDirectoryName(resPath);
            ofdRightPart.Filter = RightPartFileExtension + " files (*." + RightPartFileExtension + ")|*." + RightPartFileExtension + "";
            ofdRightPart.RestoreDirectory = true;
            ofdRightPart.Multiselect = false;
        }
    }
}
