namespace toop_project
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRightPart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitial = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.lblResidual = new System.Windows.Forms.Label();
            this.lblIter = new System.Windows.Forms.Label();
            this.pbarSolver = new System.Windows.Forms.ProgressBar();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlSolver = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSolve = new System.Windows.Forms.Button();
            this.cmbSolver = new System.Windows.Forms.ComboBox();
            this.cmbPrecond = new System.Windows.Forms.ComboBox();
            this.cmbMatrixFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pnlFile = new System.Windows.Forms.Panel();
            this.cbxInitial = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblInitialFileName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRPFileName = new System.Windows.Forms.Label();
            this.lblMatixFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvMatrix = new System.Windows.Forms.DataGridView();
            this.dgvRightPart = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvInitial = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tbResidual = new System.Windows.Forms.TextBox();
            this.sbtnP = new toop_project.src.GUI.SinkButton();
            this.sbtnS = new toop_project.src.GUI.SinkButton();
            this.sbtnF = new toop_project.src.GUI.SinkButton();
            this.label13 = new System.Windows.Forms.Label();
            this.nudRelaxation = new System.Windows.Forms.NumericUpDown();
            this.nudMaxIter = new System.Windows.Forms.NumericUpDown();
            this.nudMGMRES = new System.Windows.Forms.NumericUpDown();
            this.mnu.SuspendLayout();
            this.pnlBot.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlParameters.SuspendLayout();
            this.pnlSolver.SuspendLayout();
            this.pnlFile.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRightPart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInitial)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRelaxation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxIter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMGMRES)).BeginInit();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mnu.Size = new System.Drawing.Size(745, 24);
            this.mnu.TabIndex = 0;
            this.mnu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuRightPart,
            this.mnuInitial,
            this.toolStripSeparator1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(190, 22);
            this.mnuFileOpen.Text = "Open matrix...";
            this.mnuFileOpen.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // mnuRightPart
            // 
            this.mnuRightPart.Name = "mnuRightPart";
            this.mnuRightPart.Size = new System.Drawing.Size(190, 22);
            this.mnuRightPart.Text = "Open right part...";
            this.mnuRightPart.Click += new System.EventHandler(this.btnOpenRPFile_Click);
            // 
            // mnuInitial
            // 
            this.mnuInitial.Name = "mnuInitial";
            this.mnuInitial.Size = new System.Drawing.Size(190, 22);
            this.mnuInitial.Text = "Open initial solution...";
            this.mnuInitial.Click += new System.EventHandler(this.mnuInitial_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(190, 22);
            this.mnuFileExit.Text = "Exit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuHelpAbout.Text = "About";
            // 
            // pnlBot
            // 
            this.pnlBot.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlBot.Controls.Add(this.lblResidual);
            this.pnlBot.Controls.Add(this.lblIter);
            this.pnlBot.Controls.Add(this.pbarSolver);
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 509);
            this.pnlBot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Padding = new System.Windows.Forms.Padding(2);
            this.pnlBot.Size = new System.Drawing.Size(745, 24);
            this.pnlBot.TabIndex = 1;
            // 
            // lblResidual
            // 
            this.lblResidual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResidual.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblResidual.Location = new System.Drawing.Point(292, 2);
            this.lblResidual.Name = "lblResidual";
            this.lblResidual.Size = new System.Drawing.Size(184, 20);
            this.lblResidual.TabIndex = 2;
            this.lblResidual.Text = "Residual:";
            this.lblResidual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIter
            // 
            this.lblIter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIter.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblIter.Location = new System.Drawing.Point(476, 2);
            this.lblIter.Name = "lblIter";
            this.lblIter.Size = new System.Drawing.Size(123, 20);
            this.lblIter.TabIndex = 1;
            this.lblIter.Text = "Iteration:";
            this.lblIter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbarSolver
            // 
            this.pbarSolver.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbarSolver.Location = new System.Drawing.Point(599, 2);
            this.pbarSolver.Name = "pbarSolver";
            this.pbarSolver.Size = new System.Drawing.Size(144, 20);
            this.pbarSolver.Step = 1;
            this.pbarSolver.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbarSolver.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlLeft.Controls.Add(this.pnlParameters);
            this.pnlLeft.Controls.Add(this.pnlSolver);
            this.pnlLeft.Controls.Add(this.panel11);
            this.pnlLeft.Controls.Add(this.pnlFile);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 54);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeft.Size = new System.Drawing.Size(292, 455);
            this.pnlLeft.TabIndex = 2;
            // 
            // pnlParameters
            // 
            this.pnlParameters.BackColor = System.Drawing.SystemColors.Control;
            this.pnlParameters.Controls.Add(this.nudMGMRES);
            this.pnlParameters.Controls.Add(this.nudMaxIter);
            this.pnlParameters.Controls.Add(this.nudRelaxation);
            this.pnlParameters.Controls.Add(this.label13);
            this.pnlParameters.Controls.Add(this.tbResidual);
            this.pnlParameters.Controls.Add(this.label9);
            this.pnlParameters.Controls.Add(this.label10);
            this.pnlParameters.Controls.Add(this.label11);
            this.pnlParameters.Controls.Add(this.label12);
            this.pnlParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlParameters.Location = new System.Drawing.Point(3, 251);
            this.pnlParameters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Padding = new System.Windows.Forms.Padding(2);
            this.pnlParameters.Size = new System.Drawing.Size(286, 136);
            this.pnlParameters.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "Max iterations:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 18);
            this.label10.TabIndex = 6;
            this.label10.Text = "Relaxation par:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 18);
            this.label11.TabIndex = 6;
            this.label11.Text = "Min residual:";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(2, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(282, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "Parameters";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSolver
            // 
            this.pnlSolver.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSolver.Controls.Add(this.label6);
            this.pnlSolver.Controls.Add(this.label4);
            this.pnlSolver.Controls.Add(this.label3);
            this.pnlSolver.Controls.Add(this.btnSolve);
            this.pnlSolver.Controls.Add(this.cmbSolver);
            this.pnlSolver.Controls.Add(this.cmbPrecond);
            this.pnlSolver.Controls.Add(this.cmbMatrixFormat);
            this.pnlSolver.Controls.Add(this.label2);
            this.pnlSolver.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSolver.Location = new System.Drawing.Point(3, 115);
            this.pnlSolver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSolver.Name = "pnlSolver";
            this.pnlSolver.Padding = new System.Windows.Forms.Padding(2);
            this.pnlSolver.Size = new System.Drawing.Size(286, 136);
            this.pnlSolver.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Solver:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Preconditioner:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Matrix format:";
            // 
            // btnSolve
            // 
            this.btnSolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolve.Location = new System.Drawing.Point(199, 106);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(84, 27);
            this.btnSolve.TabIndex = 5;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // cmbSolver
            // 
            this.cmbSolver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSolver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSolver.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSolver.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbSolver.FormattingEnabled = true;
            this.cmbSolver.Location = new System.Drawing.Point(116, 79);
            this.cmbSolver.Name = "cmbSolver";
            this.cmbSolver.Size = new System.Drawing.Size(165, 24);
            this.cmbSolver.TabIndex = 4;
            this.cmbSolver.SelectedIndexChanged += new System.EventHandler(this.cmbSolver_SelectedIndexChanged);
            // 
            // cmbPrecond
            // 
            this.cmbPrecond.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrecond.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbPrecond.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbPrecond.FormattingEnabled = true;
            this.cmbPrecond.Location = new System.Drawing.Point(116, 54);
            this.cmbPrecond.Name = "cmbPrecond";
            this.cmbPrecond.Size = new System.Drawing.Size(165, 24);
            this.cmbPrecond.TabIndex = 3;
            this.cmbPrecond.SelectedIndexChanged += new System.EventHandler(this.cmbPrecond_SelectedIndexChanged);
            // 
            // cmbMatrixFormat
            // 
            this.cmbMatrixFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMatrixFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMatrixFormat.Enabled = false;
            this.cmbMatrixFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMatrixFormat.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbMatrixFormat.FormattingEnabled = true;
            this.cmbMatrixFormat.Location = new System.Drawing.Point(116, 29);
            this.cmbMatrixFormat.Name = "cmbMatrixFormat";
            this.cmbMatrixFormat.Size = new System.Drawing.Size(165, 24);
            this.cmbMatrixFormat.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Solver";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(3, 111);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(286, 4);
            this.panel11.TabIndex = 7;
            // 
            // pnlFile
            // 
            this.pnlFile.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFile.Controls.Add(this.cbxInitial);
            this.pnlFile.Controls.Add(this.label7);
            this.pnlFile.Controls.Add(this.lblInitialFileName);
            this.pnlFile.Controls.Add(this.label8);
            this.pnlFile.Controls.Add(this.label5);
            this.pnlFile.Controls.Add(this.lblRPFileName);
            this.pnlFile.Controls.Add(this.lblMatixFileName);
            this.pnlFile.Controls.Add(this.label1);
            this.pnlFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFile.Location = new System.Drawing.Point(3, 4);
            this.pnlFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Padding = new System.Windows.Forms.Padding(2);
            this.pnlFile.Size = new System.Drawing.Size(286, 107);
            this.pnlFile.TabIndex = 0;
            // 
            // cbxInitial
            // 
            this.cbxInitial.AutoSize = true;
            this.cbxInitial.Enabled = false;
            this.cbxInitial.Location = new System.Drawing.Point(266, 83);
            this.cbxInitial.Name = "cbxInitial";
            this.cbxInitial.Size = new System.Drawing.Size(15, 14);
            this.cbxInitial.TabIndex = 10;
            this.cbxInitial.UseVisualStyleBackColor = true;
            this.cbxInitial.CheckedChanged += new System.EventHandler(this.cbxInitial_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Initial solution:";
            // 
            // lblInitialFileName
            // 
            this.lblInitialFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInitialFileName.AutoEllipsis = true;
            this.lblInitialFileName.Location = new System.Drawing.Point(94, 81);
            this.lblInitialFileName.Name = "lblInitialFileName";
            this.lblInitialFileName.Size = new System.Drawing.Size(171, 22);
            this.lblInitialFileName.TabIndex = 8;
            this.lblInitialFileName.Text = "fileName";
            this.lblInitialFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInitialFileName.DoubleClick += new System.EventHandler(this.mnuInitial_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Right part:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Matrix:";
            // 
            // lblRPFileName
            // 
            this.lblRPFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRPFileName.AutoEllipsis = true;
            this.lblRPFileName.Location = new System.Drawing.Point(94, 55);
            this.lblRPFileName.Name = "lblRPFileName";
            this.lblRPFileName.Size = new System.Drawing.Size(171, 22);
            this.lblRPFileName.TabIndex = 1;
            this.lblRPFileName.Text = "fileName";
            this.lblRPFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRPFileName.DoubleClick += new System.EventHandler(this.btnOpenRPFile_Click);
            // 
            // lblMatixFileName
            // 
            this.lblMatixFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMatixFileName.AutoEllipsis = true;
            this.lblMatixFileName.Location = new System.Drawing.Point(94, 29);
            this.lblMatixFileName.Name = "lblMatixFileName";
            this.lblMatixFileName.Size = new System.Drawing.Size(171, 22);
            this.lblMatixFileName.TabIndex = 1;
            this.lblMatixFileName.Text = "fileName";
            this.lblMatixFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMatixFileName.DoubleClick += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlTop.Controls.Add(this.sbtnP);
            this.pnlTop.Controls.Add(this.sbtnS);
            this.pnlTop.Controls.Add(this.sbtnF);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTop.Size = new System.Drawing.Size(745, 30);
            this.pnlTop.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(292, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(453, 455);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvMatrix);
            this.tabPage1.Controls.Add(this.dgvRightPart);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(445, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Matrix";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvMatrix
            // 
            this.dgvMatrix.AllowUserToAddRows = false;
            this.dgvMatrix.AllowUserToDeleteRows = false;
            this.dgvMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrix.ColumnHeadersVisible = false;
            this.dgvMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatrix.Location = new System.Drawing.Point(3, 3);
            this.dgvMatrix.Name = "dgvMatrix";
            this.dgvMatrix.ReadOnly = true;
            this.dgvMatrix.RowHeadersVisible = false;
            this.dgvMatrix.Size = new System.Drawing.Size(407, 418);
            this.dgvMatrix.TabIndex = 0;
            // 
            // dgvRightPart
            // 
            this.dgvRightPart.AllowUserToAddRows = false;
            this.dgvRightPart.AllowUserToDeleteRows = false;
            this.dgvRightPart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvRightPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRightPart.ColumnHeadersVisible = false;
            this.dgvRightPart.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvRightPart.Location = new System.Drawing.Point(410, 3);
            this.dgvRightPart.Name = "dgvRightPart";
            this.dgvRightPart.ReadOnly = true;
            this.dgvRightPart.RowHeadersVisible = false;
            this.dgvRightPart.Size = new System.Drawing.Size(32, 418);
            this.dgvRightPart.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvInitial);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(445, 424);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Initial";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvInitial
            // 
            this.dgvInitial.AllowUserToAddRows = false;
            this.dgvInitial.AllowUserToDeleteRows = false;
            this.dgvInitial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvInitial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInitial.ColumnHeadersVisible = false;
            this.dgvInitial.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvInitial.Location = new System.Drawing.Point(3, 3);
            this.dgvInitial.Name = "dgvInitial";
            this.dgvInitial.ReadOnly = true;
            this.dgvInitial.RowHeadersVisible = false;
            this.dgvInitial.Size = new System.Drawing.Size(132, 418);
            this.dgvInitial.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvResult);
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(445, 424);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Result";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.ColumnHeadersVisible = false;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvResult.Location = new System.Drawing.Point(3, 3);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.Size = new System.Drawing.Size(132, 418);
            this.dgvResult.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rtbLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(445, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(4, 4);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(437, 416);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // tbResidual
            // 
            this.tbResidual.Location = new System.Drawing.Point(116, 31);
            this.tbResidual.Name = "tbResidual";
            this.tbResidual.Size = new System.Drawing.Size(165, 21);
            this.tbResidual.TabIndex = 7;
            this.tbResidual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbResidual_KeyPress);
            this.tbResidual.Leave += new System.EventHandler(this.tbResidual_Leave);
            // 
            // sbtnP
            // 
            this.sbtnP.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sbtnP.Dock = System.Windows.Forms.DockStyle.Left;
            this.sbtnP.Location = new System.Drawing.Point(54, 2);
            this.sbtnP.Name = "sbtnP";
            this.sbtnP.Sink = true;
            this.sbtnP.Size = new System.Drawing.Size(26, 26);
            this.sbtnP.TabIndex = 2;
            this.sbtnP.Text = "P";
            this.sbtnP.UseVisualStyleBackColor = false;
            // 
            // sbtnS
            // 
            this.sbtnS.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sbtnS.Dock = System.Windows.Forms.DockStyle.Left;
            this.sbtnS.Location = new System.Drawing.Point(28, 2);
            this.sbtnS.Name = "sbtnS";
            this.sbtnS.Sink = true;
            this.sbtnS.Size = new System.Drawing.Size(26, 26);
            this.sbtnS.TabIndex = 1;
            this.sbtnS.Text = "S";
            this.sbtnS.UseVisualStyleBackColor = false;
            // 
            // sbtnF
            // 
            this.sbtnF.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sbtnF.Dock = System.Windows.Forms.DockStyle.Left;
            this.sbtnF.Location = new System.Drawing.Point(2, 2);
            this.sbtnF.Name = "sbtnF";
            this.sbtnF.Sink = true;
            this.sbtnF.Size = new System.Drawing.Size(26, 26);
            this.sbtnF.TabIndex = 0;
            this.sbtnF.Text = "F";
            this.sbtnF.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(47, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 18);
            this.label13.TabIndex = 8;
            this.label13.Text = "KSSD (m):";
            // 
            // nudRelaxation
            // 
            this.nudRelaxation.DecimalPlaces = 2;
            this.nudRelaxation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRelaxation.Location = new System.Drawing.Point(116, 54);
            this.nudRelaxation.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRelaxation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRelaxation.Name = "nudRelaxation";
            this.nudRelaxation.Size = new System.Drawing.Size(165, 21);
            this.nudRelaxation.TabIndex = 9;
            this.nudRelaxation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRelaxation.ValueChanged += new System.EventHandler(this.nudRelaxation_ValueChanged);
            // 
            // nudMaxIter
            // 
            this.nudMaxIter.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMaxIter.Location = new System.Drawing.Point(116, 75);
            this.nudMaxIter.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMaxIter.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMaxIter.Name = "nudMaxIter";
            this.nudMaxIter.Size = new System.Drawing.Size(165, 21);
            this.nudMaxIter.TabIndex = 10;
            this.nudMaxIter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudMaxIter.ValueChanged += new System.EventHandler(this.nudMaxIter_ValueChanged);
            // 
            // nudMGMRES
            // 
            this.nudMGMRES.Location = new System.Drawing.Point(116, 96);
            this.nudMGMRES.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMGMRES.Name = "nudMGMRES";
            this.nudMGMRES.Size = new System.Drawing.Size(165, 21);
            this.nudMGMRES.TabIndex = 11;
            this.nudMGMRES.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMGMRES.ValueChanged += new System.EventHandler(this.nudMGMRES_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 533);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.mnu);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.mnu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "=== Project Sun ===";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.pnlBot.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlParameters.ResumeLayout(false);
            this.pnlParameters.PerformLayout();
            this.pnlSolver.ResumeLayout(false);
            this.pnlSolver.PerformLayout();
            this.pnlFile.ResumeLayout(false);
            this.pnlFile.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRightPart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInitial)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRelaxation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxIter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMGMRES)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlFile;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTop;
        private src.GUI.SinkButton sbtnF;
        private src.GUI.SinkButton sbtnS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lblMatixFileName;
        private System.Windows.Forms.Panel pnlSolver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMatrixFormat;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.ComboBox cmbSolver;
        private System.Windows.Forms.ComboBox cmbPrecond;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvMatrix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRPFileName;
        private System.Windows.Forms.DataGridView dgvRightPart;
        private System.Windows.Forms.ToolStripMenuItem mnuRightPart;
        private System.Windows.Forms.ProgressBar pbarSolver;
        private System.Windows.Forms.Label lblIter;
        private System.Windows.Forms.Label lblResidual;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvInitial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblInitialFileName;
        private System.Windows.Forms.ToolStripMenuItem mnuInitial;
        private System.Windows.Forms.CheckBox cbxInitial;
        private src.GUI.SinkButton sbtnP;
        private System.Windows.Forms.Panel pnlParameters;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbResidual;
        private System.Windows.Forms.NumericUpDown nudMGMRES;
        private System.Windows.Forms.NumericUpDown nudMaxIter;
        private System.Windows.Forms.NumericUpDown nudRelaxation;
        private System.Windows.Forms.Label label13;
    }
}

