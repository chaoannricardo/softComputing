namespace R08546036_SHChaoAss04
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxUnaryOperator = new System.Windows.Forms.ComboBox();
            this.btnCreateUnaryFuzzySet = new System.Windows.Forms.Button();
            this.picBoxFunc = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.dropdownFuzzy = new System.Windows.Forms.ComboBox();
            this.btnCreateFuzzySet = new System.Windows.Forms.Button();
            this.btnCreateUniverse = new System.Windows.Forms.Button();
            this.theTree = new System.Windows.Forms.TreeView();
            this.theGrid = new System.Windows.Forms.PropertyGrid();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labLeftFS = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFunc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1355, 33);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(369, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "2. Select Fuzzy Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(209, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Procedure:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "1. Create Universe";
            // 
            // cbxUnaryOperator
            // 
            this.cbxUnaryOperator.FormattingEnabled = true;
            this.cbxUnaryOperator.Items.AddRange(new object[] {
            "Negate",
            "ValueCut"});
            this.cbxUnaryOperator.Location = new System.Drawing.Point(713, 87);
            this.cbxUnaryOperator.Name = "cbxUnaryOperator";
            this.cbxUnaryOperator.Size = new System.Drawing.Size(175, 28);
            this.cbxUnaryOperator.TabIndex = 14;
            // 
            // btnCreateUnaryFuzzySet
            // 
            this.btnCreateUnaryFuzzySet.Location = new System.Drawing.Point(713, 121);
            this.btnCreateUnaryFuzzySet.Name = "btnCreateUnaryFuzzySet";
            this.btnCreateUnaryFuzzySet.Size = new System.Drawing.Size(175, 69);
            this.btnCreateUnaryFuzzySet.TabIndex = 15;
            this.btnCreateUnaryFuzzySet.Text = "Create Unary Fuzzy Set";
            this.btnCreateUnaryFuzzySet.UseVisualStyleBackColor = true;
            this.btnCreateUnaryFuzzySet.Click += new System.EventHandler(this.btnCreateUnaryFuzzySet_Click);
            // 
            // picBoxFunc
            // 
            this.picBoxFunc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxFunc.Location = new System.Drawing.Point(974, 36);
            this.picBoxFunc.Name = "picBoxFunc";
            this.picBoxFunc.Size = new System.Drawing.Size(381, 158);
            this.picBoxFunc.TabIndex = 7;
            this.picBoxFunc.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(550, 121);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(154, 69);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear and Restart";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dropdownFuzzy
            // 
            this.dropdownFuzzy.FormattingEnabled = true;
            this.dropdownFuzzy.Items.AddRange(new object[] {
            "Triangular",
            "Bell",
            "Gaussian",
            "Sigmoidal",
            "Trapezoidal",
            "LeftRight"});
            this.dropdownFuzzy.Location = new System.Drawing.Point(369, 87);
            this.dropdownFuzzy.Name = "dropdownFuzzy";
            this.dropdownFuzzy.Size = new System.Drawing.Size(175, 28);
            this.dropdownFuzzy.TabIndex = 4;
            this.dropdownFuzzy.SelectedIndexChanged += new System.EventHandler(this.dropdownFuzzy_SelectedIndexChanged);
            // 
            // btnCreateFuzzySet
            // 
            this.btnCreateFuzzySet.Location = new System.Drawing.Point(369, 121);
            this.btnCreateFuzzySet.Name = "btnCreateFuzzySet";
            this.btnCreateFuzzySet.Size = new System.Drawing.Size(175, 69);
            this.btnCreateFuzzySet.TabIndex = 5;
            this.btnCreateFuzzySet.Text = "Create Fuzzy Set";
            this.btnCreateFuzzySet.UseVisualStyleBackColor = true;
            this.btnCreateFuzzySet.Click += new System.EventHandler(this.btnCreateFuzzySet_Click);
            // 
            // btnCreateUniverse
            // 
            this.btnCreateUniverse.Location = new System.Drawing.Point(213, 121);
            this.btnCreateUniverse.Name = "btnCreateUniverse";
            this.btnCreateUniverse.Size = new System.Drawing.Size(154, 69);
            this.btnCreateUniverse.TabIndex = 0;
            this.btnCreateUniverse.Text = "Create Universe";
            this.btnCreateUniverse.UseVisualStyleBackColor = true;
            this.btnCreateUniverse.Click += new System.EventHandler(this.btnCreateUniverse_Click);
            // 
            // theTree
            // 
            this.theTree.Location = new System.Drawing.Point(213, 196);
            this.theTree.Name = "theTree";
            this.theTree.Size = new System.Drawing.Size(295, 202);
            this.theTree.TabIndex = 17;
            // 
            // theGrid
            // 
            this.theGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.theGrid.Location = new System.Drawing.Point(209, 409);
            this.theGrid.Name = "theGrid";
            this.theGrid.Size = new System.Drawing.Size(298, 255);
            this.theGrid.TabIndex = 3;
            this.theGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.theGrid_PropertyValueChanged);
            // 
            // mainChart
            // 
            this.mainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(513, 200);
            this.mainChart.Name = "mainChart";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.mainChart.Series.Add(series1);
            this.mainChart.Size = new System.Drawing.Size(842, 464);
            this.mainChart.TabIndex = 2;
            this.mainChart.Text = "chart1";
            // 
            // labLeftFS
            // 
            this.labLeftFS.AutoSize = true;
            this.labLeftFS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labLeftFS.Location = new System.Drawing.Point(12, 200);
            this.labLeftFS.Name = "labLeftFS";
            this.labLeftFS.Size = new System.Drawing.Size(51, 20);
            this.labLeftFS.TabIndex = 18;
            this.labLeftFS.Text = "label4";
            this.labLeftFS.Click += new System.EventHandler(this.labLeftFS_Click_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1355, 689);
            this.Controls.Add(this.labLeftFS);
            this.Controls.Add(this.btnCreateUnaryFuzzySet);
            this.Controls.Add(this.cbxUnaryOperator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxFunc);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreateFuzzySet);
            this.Controls.Add(this.dropdownFuzzy);
            this.Controls.Add(this.theGrid);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.btnCreateUniverse);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.theTree);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = " Fuzzy Set Creator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFunc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxUnaryOperator;
        private System.Windows.Forms.Button btnCreateUnaryFuzzySet;
        private System.Windows.Forms.PictureBox picBoxFunc;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox dropdownFuzzy;
        private System.Windows.Forms.Button btnCreateFuzzySet;
        private System.Windows.Forms.Button btnCreateUniverse;
        private System.Windows.Forms.TreeView theTree;
        private System.Windows.Forms.PropertyGrid theGrid;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.Label labLeftFS;
    }
}

