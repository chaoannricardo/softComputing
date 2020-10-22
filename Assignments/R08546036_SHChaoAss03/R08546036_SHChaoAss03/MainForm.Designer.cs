namespace R08546036_SHChaoAss03
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnCreateUniverse = new System.Windows.Forms.Button();
            this.theTree = new System.Windows.Forms.TreeView();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.theGrid = new System.Windows.Forms.PropertyGrid();
            this.dropdownFuzzy = new System.Windows.Forms.ComboBox();
            this.btnCreateFuzzySet = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.picBoxFunc = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFunc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateUniverse
            // 
            this.btnCreateUniverse.Location = new System.Drawing.Point(12, 106);
            this.btnCreateUniverse.Name = "btnCreateUniverse";
            this.btnCreateUniverse.Size = new System.Drawing.Size(154, 69);
            this.btnCreateUniverse.TabIndex = 0;
            this.btnCreateUniverse.Text = "Create Universe";
            this.btnCreateUniverse.UseVisualStyleBackColor = true;
            this.btnCreateUniverse.Click += new System.EventHandler(this.btnCreateUniverse_Click);
            // 
            // theTree
            // 
            this.theTree.Location = new System.Drawing.Point(12, 201);
            this.theTree.Name = "theTree";
            this.theTree.Size = new System.Drawing.Size(495, 202);
            this.theTree.TabIndex = 1;
            this.theTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.theTree_AfterSelect);
            // 
            // mainChart
            // 
            this.mainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            legend2.Name = "Legend1";
            this.mainChart.Legends.Add(legend2);
            this.mainChart.Location = new System.Drawing.Point(513, 200);
            this.mainChart.Name = "mainChart";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.mainChart.Series.Add(series2);
            this.mainChart.Size = new System.Drawing.Size(769, 494);
            this.mainChart.TabIndex = 2;
            this.mainChart.Text = "chart1";
            // 
            // theGrid
            // 
            this.theGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.theGrid.Location = new System.Drawing.Point(12, 409);
            this.theGrid.Name = "theGrid";
            this.theGrid.Size = new System.Drawing.Size(495, 285);
            this.theGrid.TabIndex = 3;
            this.theGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.theGrid_PropertyValueChanged);
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
            this.dropdownFuzzy.Location = new System.Drawing.Point(172, 72);
            this.dropdownFuzzy.Name = "dropdownFuzzy";
            this.dropdownFuzzy.Size = new System.Drawing.Size(175, 28);
            this.dropdownFuzzy.TabIndex = 4;
            this.dropdownFuzzy.SelectedIndexChanged += new System.EventHandler(this.dropdownFuzzy_SelectedIndexChanged);
            // 
            // btnCreateFuzzySet
            // 
            this.btnCreateFuzzySet.Location = new System.Drawing.Point(172, 106);
            this.btnCreateFuzzySet.Name = "btnCreateFuzzySet";
            this.btnCreateFuzzySet.Size = new System.Drawing.Size(175, 69);
            this.btnCreateFuzzySet.TabIndex = 5;
            this.btnCreateFuzzySet.Text = "Create Fuzzy Set";
            this.btnCreateFuzzySet.UseVisualStyleBackColor = true;
            this.btnCreateFuzzySet.Click += new System.EventHandler(this.btnCreateFuzzySet_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(353, 106);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(154, 69);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear and Restart";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // picBoxFunc
            // 
            this.picBoxFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxFunc.Location = new System.Drawing.Point(513, 13);
            this.picBoxFunc.Name = "picBoxFunc";
            this.picBoxFunc.Size = new System.Drawing.Size(769, 181);
            this.picBoxFunc.TabIndex = 7;
            this.picBoxFunc.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "1. Create Universe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "2. Select Fuzzy Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Procedure:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1294, 706);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxFunc);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreateFuzzySet);
            this.Controls.Add(this.dropdownFuzzy);
            this.Controls.Add(this.theGrid);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.theTree);
            this.Controls.Add(this.btnCreateUniverse);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = " Fuzzy Set Creator";
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFunc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateUniverse;
        private System.Windows.Forms.TreeView theTree;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.PropertyGrid theGrid;
        private System.Windows.Forms.ComboBox dropdownFuzzy;
        private System.Windows.Forms.Button btnCreateFuzzySet;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox picBoxFunc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

