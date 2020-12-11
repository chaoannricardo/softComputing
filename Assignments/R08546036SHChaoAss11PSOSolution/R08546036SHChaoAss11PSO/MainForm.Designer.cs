namespace R08546036SHChaoAss11PSO
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.spcSecond = new System.Windows.Forms.SplitContainer();
            this.chartSolution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gridTheSolver = new System.Windows.Forms.PropertyGrid();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNewProb = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnRunOneIteration = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.dataInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcSecond)).BeginInit();
            this.spcSecond.Panel1.SuspendLayout();
            this.spcSecond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.Location = new System.Drawing.Point(13, 95);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.spcMain.Panel2.Controls.Add(this.splitContainer1);
            this.spcMain.Size = new System.Drawing.Size(1178, 489);
            this.spcMain.SplitterDistance = 392;
            this.spcMain.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.spcSecond);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(782, 489);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 0;
            // 
            // spcSecond
            // 
            this.spcSecond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcSecond.Location = new System.Drawing.Point(0, 0);
            this.spcSecond.Name = "spcSecond";
            this.spcSecond.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcSecond.Panel1
            // 
            this.spcSecond.Panel1.Controls.Add(this.chartSolution);
            this.spcSecond.Size = new System.Drawing.Size(390, 489);
            this.spcSecond.SplitterDistance = 130;
            this.spcSecond.TabIndex = 5;
            // 
            // chartSolution
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSolution.ChartAreas.Add(chartArea1);
            this.chartSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartSolution.Legends.Add(legend1);
            this.chartSolution.Location = new System.Drawing.Point(0, 0);
            this.chartSolution.Name = "chartSolution";
            this.chartSolution.Size = new System.Drawing.Size(390, 130);
            this.chartSolution.TabIndex = 0;
            this.chartSolution.Text = "chart1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataInfo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridTheSolver);
            this.splitContainer2.Size = new System.Drawing.Size(388, 489);
            this.splitContainer2.SplitterDistance = 134;
            this.splitContainer2.TabIndex = 0;
            // 
            // gridTheSolver
            // 
            this.gridTheSolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTheSolver.Location = new System.Drawing.Point(0, 0);
            this.gridTheSolver.Name = "gridTheSolver";
            this.gridTheSolver.Size = new System.Drawing.Size(388, 351);
            this.gridTheSolver.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(13, 54);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(110, 35);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnNewProb
            // 
            this.btnNewProb.Location = new System.Drawing.Point(13, 12);
            this.btnNewProb.Name = "btnNewProb";
            this.btnNewProb.Size = new System.Drawing.Size(110, 35);
            this.btnNewProb.TabIndex = 2;
            this.btnNewProb.Text = "New Problem";
            this.btnNewProb.UseVisualStyleBackColor = true;
            this.btnNewProb.Click += new System.EventHandler(this.btnNewProb_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(129, 54);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(202, 35);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create PSO Solver";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnRunOneIteration
            // 
            this.btnRunOneIteration.Location = new System.Drawing.Point(753, 54);
            this.btnRunOneIteration.Name = "btnRunOneIteration";
            this.btnRunOneIteration.Size = new System.Drawing.Size(202, 35);
            this.btnRunOneIteration.TabIndex = 4;
            this.btnRunOneIteration.Text = "Run One Iteration";
            this.btnRunOneIteration.UseVisualStyleBackColor = true;
            this.btnRunOneIteration.Click += new System.EventHandler(this.btnRunOneIteration_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(337, 54);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(202, 35);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(545, 54);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(202, 35);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run to End";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dataInfo
            // 
            this.dataInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataInfo.Location = new System.Drawing.Point(0, 0);
            this.dataInfo.Name = "dataInfo";
            this.dataInfo.RowHeadersWidth = 51;
            this.dataInfo.RowTemplate.Height = 24;
            this.dataInfo.Size = new System.Drawing.Size(388, 134);
            this.dataInfo.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 610);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRunOneIteration);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnNewProb);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.spcMain);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.spcSecond.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcSecond)).EndInit();
            this.spcSecond.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSolution)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnNewProb;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer spcSecond;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PropertyGrid gridTheSolver;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSolution;
        private System.Windows.Forms.Button btnRunOneIteration;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataGridView dataInfo;
    }
}

