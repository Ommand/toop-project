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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBot = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
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
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRPFileName = new System.Windows.Forms.Label();
            this.lblMatixFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.sbtnS = new toop_project.src.GUI.SinkButton();
            this.sbtnF = new toop_project.src.GUI.SinkButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvMatrix = new System.Windows.Forms.DataGridView();
            this.dgvRightPart = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.mnuRightPart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlSolver.SuspendLayout();
            this.pnlFile.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRightPart)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.viewToolStripMenuItem,
            this.mnuHelp});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mnu.Size = new System.Drawing.Size(643, 24);
            this.mnu.TabIndex = 0;
            this.mnu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuRightPart,
            this.toolStripSeparator1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(164, 22);
            this.mnuFileOpen.Text = "Open matrix...";
            this.mnuFileOpen.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(164, 22);
            this.mnuFileExit.Text = "Exit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
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
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 430);
            this.pnlBot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(643, 24);
            this.pnlBot.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlLeft.Controls.Add(this.pnlSolver);
            this.pnlLeft.Controls.Add(this.panel11);
            this.pnlLeft.Controls.Add(this.pnlFile);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 54);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeft.Size = new System.Drawing.Size(228, 376);
            this.pnlLeft.TabIndex = 2;
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
            this.pnlSolver.Location = new System.Drawing.Point(3, 97);
            this.pnlSolver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSolver.Name = "pnlSolver";
            this.pnlSolver.Padding = new System.Windows.Forms.Padding(2);
            this.pnlSolver.Size = new System.Drawing.Size(222, 136);
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
            this.btnSolve.Location = new System.Drawing.Point(135, 106);
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
            this.cmbSolver.Size = new System.Drawing.Size(101, 24);
            this.cmbSolver.TabIndex = 4;
            this.cmbSolver.SelectedIndexChanged += new System.EventHandler(this.cmbSolver_SelectedIndexChanged);
            // 
            // cmbPrecond
            // 
            this.cmbPrecond.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrecond.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrecond.Enabled = false;
            this.cmbPrecond.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbPrecond.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbPrecond.FormattingEnabled = true;
            this.cmbPrecond.Location = new System.Drawing.Point(116, 54);
            this.cmbPrecond.Name = "cmbPrecond";
            this.cmbPrecond.Size = new System.Drawing.Size(101, 24);
            this.cmbPrecond.TabIndex = 3;
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
            this.cmbMatrixFormat.Size = new System.Drawing.Size(101, 24);
            this.cmbMatrixFormat.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Solver";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(3, 93);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(222, 4);
            this.panel11.TabIndex = 7;
            // 
            // pnlFile
            // 
            this.pnlFile.BackColor = System.Drawing.SystemColors.Control;
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
            this.pnlFile.Size = new System.Drawing.Size(222, 89);
            this.pnlFile.TabIndex = 0;
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
            this.lblRPFileName.Location = new System.Drawing.Point(68, 55);
            this.lblRPFileName.Name = "lblRPFileName";
            this.lblRPFileName.Size = new System.Drawing.Size(149, 22);
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
            this.lblMatixFileName.Location = new System.Drawing.Point(68, 29);
            this.lblMatixFileName.Name = "lblMatixFileName";
            this.lblMatixFileName.Size = new System.Drawing.Size(149, 22);
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
            this.label1.Size = new System.Drawing.Size(218, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlTop.Controls.Add(this.sbtnS);
            this.pnlTop.Controls.Add(this.sbtnF);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTop.Size = new System.Drawing.Size(643, 30);
            this.pnlTop.TabIndex = 4;
            // 
            // sbtnS
            // 
            this.sbtnS.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sbtnS.Location = new System.Drawing.Point(29, 2);
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
            this.sbtnF.Location = new System.Drawing.Point(2, 2);
            this.sbtnF.Name = "sbtnF";
            this.sbtnF.Sink = true;
            this.sbtnF.Size = new System.Drawing.Size(26, 26);
            this.sbtnF.TabIndex = 0;
            this.sbtnF.Text = "F";
            this.sbtnF.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(228, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(415, 376);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvMatrix);
            this.tabPage1.Controls.Add(this.dgvRightPart);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(407, 345);
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
            this.dgvMatrix.Size = new System.Drawing.Size(333, 339);
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
            this.dgvRightPart.Location = new System.Drawing.Point(336, 3);
            this.dgvRightPart.Name = "dgvRightPart";
            this.dgvRightPart.ReadOnly = true;
            this.dgvRightPart.RowHeadersVisible = false;
            this.dgvRightPart.Size = new System.Drawing.Size(68, 339);
            this.dgvRightPart.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(407, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SLAE Analysis";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rtbLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(407, 345);
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
            this.rtbLog.Size = new System.Drawing.Size(399, 337);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // mnuRightPart
            // 
            this.mnuRightPart.Name = "mnuRightPart";
            this.mnuRightPart.Size = new System.Drawing.Size(164, 22);
            this.mnuRightPart.Text = "Open right part...";
            this.mnuRightPart.Click += new System.EventHandler(this.btnOpenRPFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 454);
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
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlSolver.ResumeLayout(false);
            this.pnlSolver.PerformLayout();
            this.pnlFile.ResumeLayout(false);
            this.pnlFile.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRightPart)).EndInit();
            this.tabPage3.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private src.GUI.SinkButton sbtnF;
        private src.GUI.SinkButton sbtnS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
    }
}

