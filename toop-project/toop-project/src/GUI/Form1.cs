using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace toop_project {
    public partial class Form1 : Form, src.GUI.IGUI {
        Thread solverThread = null;
        src.Slae.SLAE slae;

        const String MatrixFileExtension = "mtx";
        const String VectorFileExtension = "vec";
        const int maxDrawSize = 5;

        String resPath = System.IO.Path.GetFullPath(@"..\..\res\");

        OpenFileDialog ofdMatrix = new OpenFileDialog();
        OpenFileDialog ofdMatrixGeneric = new OpenFileDialog();
        OpenFileDialog ofdRightPart = new OpenFileDialog();
        OpenFileDialog ofdInitial = new OpenFileDialog();
        SaveFileDialog sfdResult = new SaveFileDialog();
        SaveFileDialog sfdGenericMatrix = new SaveFileDialog();

        delegate void UpdateResidualCallback(double residual);
        private void UpdateResidual(double residual) {
            if (this.lblResidual.InvokeRequired)
                this.Invoke(new UpdateResidualCallback(UpdateResidual), new object[] { residual });
            else
                this.lblResidual.Text = "Residual: " + residual.ToString();
        }
        delegate void UpdateIterCallback(int iteration);
        private void UpdateIter(int iteration) {
            if (this.lblIter.InvokeRequired)
                this.Invoke(new UpdateIterCallback(UpdateIter), new object[] { iteration });
            else
                this.lblIter.Text = "Iteration: " + iteration.ToString() + "/" + slae.MaxIter.ToString();
        }
        delegate void UpdateProgressBarCallback(int iteration);
        private void UpdateProgressBar(int iteration) {
            if (this.pbarSolver.InvokeRequired) 
                this.Invoke(new UpdateProgressBarCallback(UpdateProgressBar), new object[] { iteration });
            else 
                this.pbarSolver.Value = iteration;
        }
        delegate void AddTextCallback(string text);
        private void AddLog(string text) {
            if (this.rtbLog.InvokeRequired) 
                this.Invoke(new AddTextCallback(AddLog), new object[] { text });
            else 
                this.rtbLog.Text += text;
        }
        delegate void UpdateDgvResultCallback(src.Vector_.Vector vec);
        private void UpdateDgvResult(src.Vector_.Vector vec) {
            if (this.dgvRightPart.InvokeRequired)
                this.Invoke(new UpdateDgvResultCallback(UpdateDgvResult), new object[] { vec });
            else
                updateDgvResult(vec);
        }
        delegate void UpdateBtnSolveCallback(bool btnSolveActive = true);
        private void UpdateBtnSolve(bool btnSolveActive = true) {
            if (this.btnSolve.InvokeRequired)
                this.Invoke(new UpdateBtnSolveCallback(UpdateBtnSolve), new object[] { btnSolveActive });
            else
            {
                btnSolve.Enabled = btnSolveActive;
                btnCancelSolve.Enabled = !btnSolveActive;
            }
        }

        public void UpdateLog(String message) {
            AddLog(message + Environment.NewLine);
        }

        public void UpdateIterationLog(int num, double residual) {
            UpdateProgressBar(num);
            UpdateIter(num);
            UpdateResidual(residual);
        }

        public void FinishSolve() {
            UpdateProgressBar(slae.MaxIter);
            UpdateDgvResult(slae.Result);
            UpdateBtnSolve(true);
        }

        public Form1() {
            InitializeComponent();
            setFileDialogs();
            setComboboxes();
            setDataBindings();
            src.Logging.Logger.Instance.IGui = this;
        }

        private void btnOpenFile_Click(object sender, EventArgs e) {
            if (ofdMatrix.ShowDialog() == DialogResult.OK) {
                try {
                    if (ofdMatrix.FileName != null) {
                        src.Matrix.BaseMatrix matrix;
                        matrix = toop_project.InputOutput.InputMatrix(ofdMatrix.FileName);
                        updateDgvMatrix(matrix);
                        slae.Matrix = matrix;
                        lblMatixFileName.Text = ofdMatrix.FileName.Substring(ofdMatrix.FileName.LastIndexOf('\\')+1);
                        cmbMatrixFormat.Text = matrix.Type.ToString();

                        if (slae.Initial != null && slae.Matrix.Size != slae.Initial.Size)
                            if (cbxInitial.Checked)
                                cbxInitial.Checked = false;
                            else
                                slae.Initial = null;
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
            pnlParameters.DataBindings.Add(new Binding("Visible", sbtnP, "Sink"));
            pnlGenericFormat.DataBindings.Add(new Binding("Visible", sbtnG, "Sink"));
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
            tabControl1.SelectedIndex = 0;

            dgvMatrix.Rows.Clear();
            dgvMatrix.Columns.Clear();
            
            for(var i=0; i < matrix.Size; i++)
                dgvMatrix.Columns.Add("","");

            if  (matrix.Size > maxDrawSize)
            {
                dgvMatrix.Rows.Add("Matrix is too big to draw");
                return;
            }

            string[][] strs = new string[matrix.Size][];
            for(int i=0;i < matrix.Size;i++)
                strs[i] = new string[matrix.Size];
            matrix.Run((i, j, u) => strs[i][j] = u.ToString());

            for (int i = 0; i < matrix.Size; i++)
                dgvMatrix.Rows.Add(strs[i]);
        }

        private void updateDgvRightPart(src.Vector_.Vector vec) {
            tabControl1.SelectedIndex = 0;
            ClearDgv(dgvRightPart);
            if (vec.Size > maxDrawSize)
            {
                dgvRightPart.Rows.Add("Vector is too big to draw");
                return;
            }
            for (var i = 0; i < vec.Size; i++) {
                String[] strs = new String[1];
                strs[0] = vec[i].ToString();

                dgvRightPart.Rows.Add(strs);
            }
        }

        private void updateDgvInitial(src.Vector_.Vector vec) {
            tabControl1.SelectedIndex = 1;
            ClearDgv(dgvInitial);
            if (vec.Size > maxDrawSize)
            {
                dgvInitial.Rows.Add("Vector is too big to draw");
                return;
            }
            for (var i = 0; i < vec.Size; i++)
                dgvInitial.Rows.Add(vec[i].ToString());
        }

        private void updateDgvResult(src.Vector_.Vector vec) {
            tabControl1.SelectedIndex = 2;
            ClearDgv(dgvResult);
            if (vec.Size > maxDrawSize)
            {
                dgvResult.Rows.Add("Vector is too big to draw");
                return;
            }
            for (var i = 0; i < vec.Size; i++)
                dgvResult.Rows.Add(vec[i].ToString());
        }

        void ClearDgv(DataGridView dgv) {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.Columns.Add("", "");
        }

        private void btnOpenRPFile_Click(object sender, EventArgs e) {
            if (ofdRightPart.ShowDialog() == DialogResult.OK) {
                try {
                    if (ofdRightPart.FileName != null) {
                        src.Vector_.Vector vector;
                        vector = toop_project.InputOutput.InputVector(ofdRightPart.FileName);
                        updateDgvRightPart(vector);
                        slae.Right = vector;
                        lblRPFileName.Text = ofdRightPart.FileName.Substring(ofdRightPart.FileName.LastIndexOf('\\') + 1);
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
            // TODO: need this for thread safe?
            //if (solverThread != null) return;
            pbarSolver.Value = 0;
            pbarSolver.Maximum = slae.MaxIter;

            solverThread = new Thread(slae.Solve);
            solverThread.Start();

            UpdateBtnSolve(false);
        }

        private void cmbSolver_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbSolver.SelectedIndex < 0) { 
                slae.Solver = null;
                return;
            }
            var el = (src.Solver.Type)Enum.ToObject(typeof(src.Solver.Type), cmbSolver.SelectedIndex);
            slae.Solver = src.Solver.ISolver.getSolver(el);
            SetControls();
        }

        private void SetControls() {
            if (slae.Solver == null)
                return;

            switch(slae.Solver.Type) {
                case src.Solver.Type.Jacobi:
                    cmbPrecond.Enabled = false;
                    cmbPrecond.SelectedIndex = 0;
                    nudMGMRES.Enabled = false;
                    nudRelaxation.Enabled = true;
                    break;
                case src.Solver.Type.GaussSeidel:
                    cmbPrecond.Enabled = false;
                    cmbPrecond.SelectedIndex = 0;
                    nudMGMRES.Enabled = false;
                    nudRelaxation.Enabled = true;
                    break;
                case src.Solver.Type.LOS:
                    cmbPrecond.Enabled = true;
                    nudMGMRES.Enabled = false;
                    nudRelaxation.Enabled = false;
                    break;
                case src.Solver.Type.MSG:
                    cmbPrecond.Enabled = true;
                    nudMGMRES.Enabled = false;
                    nudRelaxation.Enabled = false;
                    break;
                case src.Solver.Type.BCGStab:
                    cmbPrecond.Enabled = true;
                    nudMGMRES.Enabled = false;
                    nudRelaxation.Enabled = false;
                    break;
                case src.Solver.Type.GMRES:
                    cmbPrecond.Enabled = true;
                    nudMGMRES.Enabled = true;
                    nudRelaxation.Enabled = false;
                    break;
            }
        }

        private void setFileDialogs() {
            ofdMatrix.InitialDirectory = System.IO.Path.GetDirectoryName(resPath);
            ofdMatrix.Filter = MatrixFileExtension + " files (*." + MatrixFileExtension + ")|*." + MatrixFileExtension + "";
            ofdMatrix.RestoreDirectory = true;
            ofdMatrix.Multiselect = false;

            ofdRightPart.InitialDirectory = System.IO.Path.GetDirectoryName(resPath);
            ofdRightPart.Filter = VectorFileExtension + " files (*." + VectorFileExtension + ")|*." + VectorFileExtension + "";
            ofdRightPart.RestoreDirectory = true;
            ofdRightPart.Multiselect = false;

            ofdInitial.InitialDirectory = System.IO.Path.GetDirectoryName(resPath);
            ofdInitial.Filter = VectorFileExtension + " files (*." + VectorFileExtension + ")|*." + VectorFileExtension + "";
            ofdInitial.RestoreDirectory = true;
            ofdInitial.Multiselect = false;

            sfdResult.InitialDirectory = System.IO.Path.GetDirectoryName(resPath);
            sfdResult.Filter = VectorFileExtension + " files (*." + VectorFileExtension + ")|*." + VectorFileExtension + "";
            sfdResult.RestoreDirectory = true;
        }

        private void Form1_Load(object sender, EventArgs e) {
            slae = new src.Slae.SLAE(this);

            cmbPrecond.SelectedIndex = 0;
            cmbSolver.SelectedIndex = 0;

            tbResidual.Text = slae.MinResidual.ToString();
            nudMaxIter.Value = slae.MaxIter;
            nudMGMRES.Value = slae.MGMRES;
            nudRelaxation.Value = (decimal)slae.Relaxation;
        }

        private void cmbPrecond_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbPrecond.SelectedIndex < 0)
                return;

            slae.PreconditionerType = (src.Preconditioner.Type)Enum.ToObject(typeof(src.Preconditioner.Type), cmbPrecond.SelectedIndex);
        }

        private void mnuInitial_Click(object sender, EventArgs e) {
            if (ofdInitial.ShowDialog() == DialogResult.OK) {
                try {
                    if (ofdInitial.FileName != null) { 
                        src.Vector_.Vector vector;
                        vector = toop_project.InputOutput.InputVector(ofdInitial.FileName);
                        updateDgvInitial(vector);
                        slae.Initial = vector;
                        lblInitialFileName.Text = ofdInitial.FileName.Substring(ofdInitial.FileName.LastIndexOf('\\') + 1);

                        cbxInitial.Checked = true;
                        cbxInitial.Enabled = true;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void cbxInitial_CheckedChanged(object sender, EventArgs e) {
            if (cbxInitial.Checked == false) {
                slae.Initial = null;
                lblInitialFileName.Text = "fileName";
                ClearDgv(dgvInitial);

                cbxInitial.Enabled = false;
            }
        }

        private void tbResidual_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.') && (e.KeyChar != 'e') && (e.KeyChar != 'E')
                && (e.KeyChar != '+') && (e.KeyChar != '-')) {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))  {
                e.Handled = true;
            }
        }

        private void tbResidual_Leave(object sender, EventArgs e) {
            if (!double.TryParse(tbResidual.Text,out slae.MinResidual)) {
                MessageBox.Show("Error: Can't parse residual. Return to default value.");
                slae.MinResidual = slae.DefaultMinResidual;
                tbResidual.Text = slae.MinResidual.ToString();
            }
        }

        private void nudRelaxation_ValueChanged(object sender, EventArgs e)
        {
            slae.Relaxation = (double)nudRelaxation.Value;
        }

        private void nudMaxIter_ValueChanged(object sender, EventArgs e)
        {
            slae.MaxIter = (int)nudMaxIter.Value;
        }

        private void nudMGMRES_ValueChanged(object sender, EventArgs e)
        {
            slae.MGMRES = (int)nudMGMRES.Value;
        }

        private void btnCancelSolve_Click(object sender, EventArgs e)
        {
            solverThread?.Abort();
            UpdateBtnSolve(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtbLog.Text = "";
        }

        private void saveResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (slae.Result == null)
            {
                MessageBox.Show("Nothing to save");
                return;
            }

            if (sfdResult.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (sfdResult.FileName != null)
                    {
                        toop_project.InputOutput.OutputVector(sfdResult.FileName,slae.Result, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file. Original error: " + ex.Message);
                }
            }
        }

        private void saveMatrixInGenericFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (slae.Matrix == null)
            {
                MessageBox.Show("Nothing to save");
                return;
            }

            if (sfdGenericMatrix.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (sfdGenericMatrix.FileName != null)
                    {
                        toop_project.InputOutput.OutputGenericMatrix(sfdGenericMatrix.FileName, slae.Matrix);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not save file. Original error: " + ex.Message);
                }
            }
        }

        private void openMatrixGENERICToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdMatrixGeneric.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (ofdMatrixGeneric.FileName != null)
                    {
                        src.Matrix.BaseMatrix matrix;
                        if (cbxAutoDim.Checked)
                            matrix = toop_project.InputOutput.InputGenericSparseMatrix(ofdMatrixGeneric.FileName,0);
                        else
                            matrix = toop_project.InputOutput.InputGenericSparseMatrix(ofdMatrixGeneric.FileName,(int)nudMatrixDim.Value);

                        updateDgvMatrix(matrix);
                        slae.Matrix = matrix;
                        lblMatixFileName.Text = ofdMatrixGeneric.FileName.Substring(ofdMatrixGeneric.FileName.LastIndexOf('\\') + 1);
                        cmbMatrixFormat.Text = matrix.Type.ToString();

                        if (slae.Initial != null && slae.Matrix.Size != slae.Initial.Size)
                            if (cbxInitial.Checked)
                                cbxInitial.Checked = false;
                            else
                                slae.Initial = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void cbxAutoDim_CheckedChanged(object sender, EventArgs e)
        {
            nudMatrixDim.Enabled = !cbxAutoDim.Checked;
            btnGenericDim.Enabled = !cbxAutoDim.Checked;
        }

        private void btnGenericDim_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (ofd.FileName != null)
                    {
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(ofd.FileName))
                        {
                            nudMatrixDim.Value = int.Parse(reader.ReadLine());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
