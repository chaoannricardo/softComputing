namespace JobAssignmentProblemGASolver
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridGA = new System.Windows.Forms.PropertyGrid();
            this.btnCreateGASolver = new System.Windows.Forms.Button();
            this.btnRunOneIteration = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.rtbPopulation = new System.Windows.Forms.RichTextBox();
            this.rtbBestObj = new System.Windows.Forms.RichTextBox();
            this.rtbBestSolution = new System.Windows.Forms.RichTextBox();
            this.lbJobs = new System.Windows.Forms.Label();
            this.lbMinimum = new System.Windows.Forms.Label();
            this.lbMaximum = new System.Windows.Forms.Label();
            this.tbJobs = new System.Windows.Forms.TextBox();
            this.tbMinimum = new System.Windows.Forms.TextBox();
            this.tbMaximum = new System.Windows.Forms.TextBox();
            this.dgJobsAndMachines = new System.Windows.Forms.DataGridView();
            this.cbGAType = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbTimeStamp = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbIteration = new System.Windows.Forms.Label();
            this.tbIteration = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgJobsAndMachines)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1074, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // gridGA
            // 
            this.gridGA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridGA.Location = new System.Drawing.Point(12, 366);
            this.gridGA.Name = "gridGA";
            this.gridGA.Size = new System.Drawing.Size(390, 276);
            this.gridGA.TabIndex = 1;
            // 
            // btnCreateGASolver
            // 
            this.btnCreateGASolver.BackColor = System.Drawing.Color.Tomato;
            this.btnCreateGASolver.Location = new System.Drawing.Point(255, 242);
            this.btnCreateGASolver.Name = "btnCreateGASolver";
            this.btnCreateGASolver.Size = new System.Drawing.Size(147, 31);
            this.btnCreateGASolver.TabIndex = 2;
            this.btnCreateGASolver.Text = "Create GA";
            this.btnCreateGASolver.UseVisualStyleBackColor = false;
            this.btnCreateGASolver.Click += new System.EventHandler(this.btnCreateGASolver_Click);
            // 
            // btnRunOneIteration
            // 
            this.btnRunOneIteration.Location = new System.Drawing.Point(255, 316);
            this.btnRunOneIteration.Name = "btnRunOneIteration";
            this.btnRunOneIteration.Size = new System.Drawing.Size(147, 31);
            this.btnRunOneIteration.TabIndex = 7;
            this.btnRunOneIteration.Text = "Run One Iteration";
            this.btnRunOneIteration.UseVisualStyleBackColor = true;
            this.btnRunOneIteration.Click += new System.EventHandler(this.btnRunOneIteration_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(255, 353);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(147, 31);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(255, 279);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(147, 31);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // rtbPopulation
            // 
            this.rtbPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPopulation.Location = new System.Drawing.Point(441, 366);
            this.rtbPopulation.Name = "rtbPopulation";
            this.rtbPopulation.Size = new System.Drawing.Size(621, 276);
            this.rtbPopulation.TabIndex = 11;
            this.rtbPopulation.Text = "";
            // 
            // rtbBestObj
            // 
            this.rtbBestObj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbBestObj.Location = new System.Drawing.Point(441, 32);
            this.rtbBestObj.Name = "rtbBestObj";
            this.rtbBestObj.Size = new System.Drawing.Size(621, 40);
            this.rtbBestObj.TabIndex = 12;
            this.rtbBestObj.Text = "";
            // 
            // rtbBestSolution
            // 
            this.rtbBestSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbBestSolution.Location = new System.Drawing.Point(441, 78);
            this.rtbBestSolution.Name = "rtbBestSolution";
            this.rtbBestSolution.Size = new System.Drawing.Size(621, 40);
            this.rtbBestSolution.TabIndex = 13;
            this.rtbBestSolution.Text = "";
            // 
            // lbJobs
            // 
            this.lbJobs.AutoSize = true;
            this.lbJobs.Location = new System.Drawing.Point(12, 37);
            this.lbJobs.Name = "lbJobs";
            this.lbJobs.Size = new System.Drawing.Size(172, 17);
            this.lbJobs.TabIndex = 14;
            this.lbJobs.Text = "Number of Jobs/Machines";
            // 
            // lbMinimum
            // 
            this.lbMinimum.AutoSize = true;
            this.lbMinimum.Location = new System.Drawing.Point(12, 58);
            this.lbMinimum.Name = "lbMinimum";
            this.lbMinimum.Size = new System.Drawing.Size(63, 17);
            this.lbMinimum.TabIndex = 15;
            this.lbMinimum.Text = "Minimum";
            // 
            // lbMaximum
            // 
            this.lbMaximum.AutoSize = true;
            this.lbMaximum.Location = new System.Drawing.Point(12, 81);
            this.lbMaximum.Name = "lbMaximum";
            this.lbMaximum.Size = new System.Drawing.Size(66, 17);
            this.lbMaximum.TabIndex = 16;
            this.lbMaximum.Text = "Maximum";
            // 
            // tbJobs
            // 
            this.tbJobs.Location = new System.Drawing.Point(302, 34);
            this.tbJobs.Name = "tbJobs";
            this.tbJobs.Size = new System.Drawing.Size(100, 22);
            this.tbJobs.TabIndex = 17;
            this.tbJobs.Text = "5";
            this.tbJobs.TextChanged += new System.EventHandler(this.tbJobs_TextChanged);
            // 
            // tbMinimum
            // 
            this.tbMinimum.Location = new System.Drawing.Point(302, 58);
            this.tbMinimum.Name = "tbMinimum";
            this.tbMinimum.Size = new System.Drawing.Size(100, 22);
            this.tbMinimum.TabIndex = 18;
            this.tbMinimum.Text = "0";
            this.tbMinimum.TextChanged += new System.EventHandler(this.tbJobs_TextChanged);
            // 
            // tbMaximum
            // 
            this.tbMaximum.Location = new System.Drawing.Point(302, 81);
            this.tbMaximum.Name = "tbMaximum";
            this.tbMaximum.Size = new System.Drawing.Size(100, 22);
            this.tbMaximum.TabIndex = 19;
            this.tbMaximum.Text = "5";
            this.tbMaximum.TextChanged += new System.EventHandler(this.tbJobs_TextChanged);
            // 
            // dgJobsAndMachines
            // 
            this.dgJobsAndMachines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgJobsAndMachines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJobsAndMachines.Location = new System.Drawing.Point(441, 125);
            this.dgJobsAndMachines.Name = "dgJobsAndMachines";
            this.dgJobsAndMachines.RowHeadersWidth = 51;
            this.dgJobsAndMachines.RowTemplate.Height = 24;
            this.dgJobsAndMachines.Size = new System.Drawing.Size(621, 235);
            this.dgJobsAndMachines.TabIndex = 20;
            // 
            // cbGAType
            // 
            this.cbGAType.FormattingEnabled = true;
            this.cbGAType.Items.AddRange(new object[] {
            "Binary GA Encoding",
            "Permutation GA Encoding"});
            this.cbGAType.Location = new System.Drawing.Point(12, 129);
            this.cbGAType.Name = "cbGAType";
            this.cbGAType.Size = new System.Drawing.Size(390, 24);
            this.cbGAType.TabIndex = 21;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbTimeStamp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 641);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1074, 26);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbTimeStamp
            // 
            this.lbTimeStamp.Name = "lbTimeStamp";
            this.lbTimeStamp.Size = new System.Drawing.Size(151, 20);
            this.lbTimeStamp.Text = "toolStripStatusLabel1";
            // 
            // lbIteration
            // 
            this.lbIteration.AutoSize = true;
            this.lbIteration.Location = new System.Drawing.Point(12, 101);
            this.lbIteration.Name = "lbIteration";
            this.lbIteration.Size = new System.Drawing.Size(59, 17);
            this.lbIteration.TabIndex = 23;
            this.lbIteration.Text = "Iteration";
            // 
            // tbIteration
            // 
            this.tbIteration.Location = new System.Drawing.Point(302, 101);
            this.tbIteration.Name = "tbIteration";
            this.tbIteration.Size = new System.Drawing.Size(100, 22);
            this.tbIteration.TabIndex = 24;
            this.tbIteration.Text = "100";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 667);
            this.Controls.Add(this.tbIteration);
            this.Controls.Add(this.lbIteration);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbGAType);
            this.Controls.Add(this.dgJobsAndMachines);
            this.Controls.Add(this.tbMaximum);
            this.Controls.Add(this.tbMinimum);
            this.Controls.Add(this.tbJobs);
            this.Controls.Add(this.lbMaximum);
            this.Controls.Add(this.lbMinimum);
            this.Controls.Add(this.lbJobs);
            this.Controls.Add(this.rtbBestSolution);
            this.Controls.Add(this.rtbBestObj);
            this.Controls.Add(this.rtbPopulation);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnRunOneIteration);
            this.Controls.Add(this.btnCreateGASolver);
            this.Controls.Add(this.gridGA);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgJobsAndMachines)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid gridGA;
        private System.Windows.Forms.Button btnCreateGASolver;
        private System.Windows.Forms.Button btnRunOneIteration;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RichTextBox rtbPopulation;
        private System.Windows.Forms.RichTextBox rtbBestObj;
        private System.Windows.Forms.RichTextBox rtbBestSolution;
        private System.Windows.Forms.Label lbJobs;
        private System.Windows.Forms.Label lbMinimum;
        private System.Windows.Forms.Label lbMaximum;
        private System.Windows.Forms.TextBox tbJobs;
        private System.Windows.Forms.TextBox tbMinimum;
        private System.Windows.Forms.TextBox tbMaximum;
        private System.Windows.Forms.DataGridView dgJobsAndMachines;
        private System.Windows.Forms.ComboBox cbGAType;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbTimeStamp;
        private System.Windows.Forms.Label lbIteration;
        private System.Windows.Forms.TextBox tbIteration;
    }
}

