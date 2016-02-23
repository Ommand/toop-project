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
            this.panel11 = new System.Windows.Forms.Panel();
            this.pnlPrecond = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pnlMatrixFormat = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pnlSolver = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlFile = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.sbtnP = new toop_project.src.GUI.SinkButton();
            this.sbtnMF = new toop_project.src.GUI.SinkButton();
            this.sbtnS = new toop_project.src.GUI.SinkButton();
            this.sbtnF = new toop_project.src.GUI.SinkButton();
            this.mnu.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlPrecond.SuspendLayout();
            this.pnlMatrixFormat.SuspendLayout();
            this.pnlSolver.SuspendLayout();
            this.pnlFile.SuspendLayout();
            this.pnlTop.SuspendLayout();
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
            this.mnu.Size = new System.Drawing.Size(658, 24);
            this.mnu.TabIndex = 0;
            this.mnu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.toolStripSeparator1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(148, 22);
            this.mnuFileOpen.Text = "Open matrix...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(148, 22);
            this.mnuFileExit.Text = "Exit";
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
            this.pnlBot.Location = new System.Drawing.Point(0, 595);
            this.pnlBot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(658, 24);
            this.pnlBot.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlLeft.Controls.Add(this.panel11);
            this.pnlLeft.Controls.Add(this.pnlPrecond);
            this.pnlLeft.Controls.Add(this.panel9);
            this.pnlLeft.Controls.Add(this.pnlMatrixFormat);
            this.pnlLeft.Controls.Add(this.panel7);
            this.pnlLeft.Controls.Add(this.pnlSolver);
            this.pnlLeft.Controls.Add(this.panel5);
            this.pnlLeft.Controls.Add(this.pnlFile);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 54);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeft.Size = new System.Drawing.Size(190, 541);
            this.pnlLeft.TabIndex = 2;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(3, 406);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(184, 4);
            this.panel11.TabIndex = 7;
            // 
            // pnlPrecond
            // 
            this.pnlPrecond.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPrecond.Controls.Add(this.label4);
            this.pnlPrecond.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrecond.Location = new System.Drawing.Point(3, 302);
            this.pnlPrecond.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPrecond.Name = "pnlPrecond";
            this.pnlPrecond.Padding = new System.Windows.Forms.Padding(2);
            this.pnlPrecond.Size = new System.Drawing.Size(184, 104);
            this.pnlPrecond.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(2, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Preconditioner";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 298);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(184, 4);
            this.panel9.TabIndex = 5;
            // 
            // pnlMatrixFormat
            // 
            this.pnlMatrixFormat.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMatrixFormat.Controls.Add(this.label3);
            this.pnlMatrixFormat.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMatrixFormat.Location = new System.Drawing.Point(3, 194);
            this.pnlMatrixFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMatrixFormat.Name = "pnlMatrixFormat";
            this.pnlMatrixFormat.Padding = new System.Windows.Forms.Padding(2);
            this.pnlMatrixFormat.Size = new System.Drawing.Size(184, 104);
            this.pnlMatrixFormat.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(2, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Matrix format";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 190);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(184, 4);
            this.panel7.TabIndex = 3;
            // 
            // pnlSolver
            // 
            this.pnlSolver.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSolver.Controls.Add(this.label2);
            this.pnlSolver.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSolver.Location = new System.Drawing.Point(3, 86);
            this.pnlSolver.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSolver.Name = "pnlSolver";
            this.pnlSolver.Padding = new System.Windows.Forms.Padding(2);
            this.pnlSolver.Size = new System.Drawing.Size(184, 104);
            this.pnlSolver.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Solver";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 82);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(184, 4);
            this.panel5.TabIndex = 1;
            // 
            // pnlFile
            // 
            this.pnlFile.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFile.Controls.Add(this.label5);
            this.pnlFile.Controls.Add(this.label1);
            this.pnlFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFile.Location = new System.Drawing.Point(3, 4);
            this.pnlFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Padding = new System.Windows.Forms.Padding(2);
            this.pnlFile.Size = new System.Drawing.Size(184, 78);
            this.pnlFile.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(2, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "...";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(190, 54);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(468, 541);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlTop.Controls.Add(this.sbtnP);
            this.pnlTop.Controls.Add(this.sbtnMF);
            this.pnlTop.Controls.Add(this.sbtnS);
            this.pnlTop.Controls.Add(this.sbtnF);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTop.Size = new System.Drawing.Size(658, 30);
            this.pnlTop.TabIndex = 4;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panel12_Paint);
            // 
            // sbtnP
            // 
            this.sbtnP.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sbtnP.Location = new System.Drawing.Point(83, 2);
            this.sbtnP.Name = "sbtnP";
            this.sbtnP.Sink = true;
            this.sbtnP.Size = new System.Drawing.Size(26, 26);
            this.sbtnP.TabIndex = 3;
            this.sbtnP.Text = "P";
            this.sbtnP.UseVisualStyleBackColor = false;
            // 
            // sbtnMF
            // 
            this.sbtnMF.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.sbtnMF.Location = new System.Drawing.Point(56, 2);
            this.sbtnMF.Name = "sbtnMF";
            this.sbtnMF.Sink = true;
            this.sbtnMF.Size = new System.Drawing.Size(26, 26);
            this.sbtnMF.TabIndex = 2;
            this.sbtnMF.Text = "MF";
            this.sbtnMF.UseVisualStyleBackColor = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 619);
            this.Controls.Add(this.pnlMain);
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
            this.pnlLeft.ResumeLayout(false);
            this.pnlPrecond.ResumeLayout(false);
            this.pnlMatrixFormat.ResumeLayout(false);
            this.pnlSolver.ResumeLayout(false);
            this.pnlFile.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnlFile;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel pnlPrecond;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel pnlMatrixFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel pnlSolver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private src.GUI.SinkButton sbtnF;
        private src.GUI.SinkButton sbtnP;
        private src.GUI.SinkButton sbtnMF;
        private src.GUI.SinkButton sbtnS;
    }
}

