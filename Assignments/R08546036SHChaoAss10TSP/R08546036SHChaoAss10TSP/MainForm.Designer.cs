namespace R08546036SHChaoAss10TSP
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnCreateACSSolver = new System.Windows.Forms.Button();
            this.btnOpenTSPProblem = new System.Windows.Forms.Button();
            this.btnRunOneIteration = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCreateASolver = new System.Windows.Forms.Button();
            this.btnOpenTSP = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.SPCThird = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPCThird)).BeginInit();
            this.SPCThird.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1170, 754);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 6;
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
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.btnCreateACSSolver);
            this.splitContainer2.Panel1.Controls.Add(this.btnOpenTSPProblem);
            this.splitContainer2.Panel1.Controls.Add(this.btnRunOneIteration);
            this.splitContainer2.Panel1.Controls.Add(this.btnRun);
            this.splitContainer2.Panel1.Controls.Add(this.btnReset);
            this.splitContainer2.Panel1.Controls.Add(this.btnCreateASolver);
            this.splitContainer2.Panel1.Controls.Add(this.btnOpenTSP);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer2.Size = new System.Drawing.Size(390, 754);
            this.splitContainer2.SplitterDistance = 442;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnCreateACSSolver
            // 
            this.btnCreateACSSolver.Location = new System.Drawing.Point(13, 174);
            this.btnCreateACSSolver.Name = "btnCreateACSSolver";
            this.btnCreateACSSolver.Size = new System.Drawing.Size(236, 39);
            this.btnCreateACSSolver.TabIndex = 12;
            this.btnCreateACSSolver.Text = "Create ACS Solver";
            this.btnCreateACSSolver.UseVisualStyleBackColor = true;
            this.btnCreateACSSolver.Click += new System.EventHandler(this.btnCreateACSSolver_Click);
            // 
            // btnOpenTSPProblem
            // 
            this.btnOpenTSPProblem.Location = new System.Drawing.Point(12, 129);
            this.btnOpenTSPProblem.Name = "btnOpenTSPProblem";
            this.btnOpenTSPProblem.Size = new System.Drawing.Size(237, 39);
            this.btnOpenTSPProblem.TabIndex = 11;
            this.btnOpenTSPProblem.Text = "Open a TSP Problem";
            this.btnOpenTSPProblem.UseVisualStyleBackColor = true;
            this.btnOpenTSPProblem.Click += new System.EventHandler(this.Open_Click);
            // 
            // btnRunOneIteration
            // 
            this.btnRunOneIteration.Location = new System.Drawing.Point(12, 315);
            this.btnRunOneIteration.Name = "btnRunOneIteration";
            this.btnRunOneIteration.Size = new System.Drawing.Size(237, 41);
            this.btnRunOneIteration.TabIndex = 10;
            this.btnRunOneIteration.Text = "Run One Iteration";
            this.btnRunOneIteration.UseVisualStyleBackColor = true;
            this.btnRunOneIteration.Click += new System.EventHandler(this.btnRunOneIteration_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 270);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(237, 39);
            this.btnRun.TabIndex = 9;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 225);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(237, 39);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCreateASolver
            // 
            this.btnCreateASolver.Location = new System.Drawing.Point(103, -69);
            this.btnCreateASolver.Name = "btnCreateASolver";
            this.btnCreateASolver.Size = new System.Drawing.Size(198, 67);
            this.btnCreateASolver.TabIndex = 7;
            this.btnCreateASolver.Text = "Create a Solver";
            this.btnCreateASolver.UseVisualStyleBackColor = true;
            // 
            // btnOpenTSP
            // 
            this.btnOpenTSP.Location = new System.Drawing.Point(-103, -69);
            this.btnOpenTSP.Name = "btnOpenTSP";
            this.btnOpenTSP.Size = new System.Drawing.Size(198, 67);
            this.btnOpenTSP.TabIndex = 6;
            this.btnOpenTSP.Text = "Open TSP";
            this.btnOpenTSP.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(390, 308);
            this.propertyGrid1.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.SPCThird);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer3_Panel2_Paint);
            this.splitContainer3.Size = new System.Drawing.Size(776, 754);
            this.splitContainer3.SplitterDistance = 482;
            this.splitContainer3.TabIndex = 0;
            // 
            // SPCThird
            // 
            this.SPCThird.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPCThird.Location = new System.Drawing.Point(0, 0);
            this.SPCThird.Name = "SPCThird";
            this.SPCThird.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SPCThird.Panel2
            // 
            this.SPCThird.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer4_Panel2_Paint);
            this.SPCThird.Size = new System.Drawing.Size(482, 754);
            this.SPCThird.SplitterDistance = 86;
            this.SPCThird.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 754);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SPCThird)).EndInit();
            this.SPCThird.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnRunOneIteration;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCreateASolver;
        private System.Windows.Forms.Button btnOpenTSP;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnOpenTSPProblem;
        private System.Windows.Forms.Button btnCreateACSSolver;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer SPCThird;
        private System.Windows.Forms.Label label1;
    }
}

