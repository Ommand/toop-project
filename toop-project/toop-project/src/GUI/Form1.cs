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
    const String RightPartFileExtension = "rtx";
    String resPath = System.IO.Path.GetFullPath(@"..\..\res\");

    OpenFileDialog ofdMatrix = new OpenFileDialog();
    OpenFileDialog ofdRightPart = new OpenFileDialog();

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
        this.lblIter.Text = "Iteration: " + iteration.ToString() + "/" + slae.Solver.Parameters.MaxIterations.ToString();
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
    delegate void ShowErrorMBCallback(string text);
    private void ShowErrorMB(string text) {
      if (this.InvokeRequired)
        this.Invoke(new ShowErrorMBCallback(ShowErrorMB), new object[] { text });
      else
        MessageBox.Show(text);
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
      UpdateProgressBar(slae.Solver.Parameters.MaxIterations);
      String result = "Result:" + Environment.NewLine;
      for (int i = 0; i < slae.Result.Size; i++)
        result += slae.Result[i].ToString() + Environment.NewLine;
      AddLog(result);
    }

    public void ShowError(String message) {
      ShowErrorMB(message);
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
            lblMatixFileName.Text = ofdMatrix.FileName.Substring(ofdMatrix.FileName.LastIndexOf('\\') + 1);
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

      for (var i = 0; i < matrix.Size; i++)
        dgvMatrix.Columns.Add("", "");
      // TODO: update matrix by run
      for (var i = 0; i < matrix.Size; i++) {
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
            vector = toop_project.InputOutput.InputRightPart(ofdRightPart.FileName);
            updateDgvRightPart(vector);
            slae.Right = vector;
            lblRPFileName.Text = ofdRightPart.FileName.Substring(ofdMatrix.FileName.LastIndexOf('\\') + 1);
          }
        }
        catch (Exception ex) {
          MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
        }
      }
    }

    private void btnSolve_Click(object sender, EventArgs e) {
      if (!slae.CanBeComputed()) {
        MessageBox.Show("Can't compute this slae", "Error");
        return;
      }
      // TODO: need this for thread safe?
      //if (solverThread != null) return;
      pbarSolver.Value = 0;
      pbarSolver.Maximum = slae.Solver.Parameters.MaxIterations;

      solverThread = new Thread(slae.Solve);
      solverThread.Start();
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

    private void Form1_Load(object sender, EventArgs e) {
      slae = new src.Slae.SLAE(this);
      test1();
    }

    private void test1() {
      src.Matrix.BaseMatrix matrix;
      matrix = toop_project.InputOutput.InputMatrix(resPath + "testFile.mtx");
      updateDgvMatrix(matrix);
      slae.Matrix = matrix;
      lblMatixFileName.Text = "testFile.mtx";

      src.Vector_.Vector vector;
      vector = toop_project.InputOutput.InputRightPart(resPath + "testRP.rtx");
      updateDgvRightPart(vector);
      slae.Right = vector;
      lblRPFileName.Text = "testRP.rtx";

      cmbSolver.SelectedIndex = 0;

      btnSolve_Click(null, null);
    }
  }
}
