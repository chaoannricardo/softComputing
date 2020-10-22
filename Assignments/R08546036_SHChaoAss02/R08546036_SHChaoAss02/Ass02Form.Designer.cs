namespace R08546036_SHChaoAss02
{
    partial class Ass02Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.lsbSelection = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearGraph = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.theChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.nudPar0 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.labPar0 = new System.Windows.Forms.Label();
            this.labPar1 = new System.Windows.Forms.Label();
            this.nudPar1 = new System.Windows.Forms.NumericUpDown();
            this.nudPar2 = new System.Windows.Forms.NumericUpDown();
            this.labPar2 = new System.Windows.Forms.Label();
            this.labPar3 = new System.Windows.Forms.Label();
            this.nudPar3 = new System.Windows.Forms.NumericUpDown();
            this.picBoxFunc = new System.Windows.Forms.PictureBox();
            this.labPar4 = new System.Windows.Forms.Label();
            this.nudPar4 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPar0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFunc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPar4)).BeginInit();
            this.SuspendLayout();
            // 
            // lsbSelection
            // 
            this.lsbSelection.BackColor = System.Drawing.SystemColors.Info;
            this.lsbSelection.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbSelection.FormattingEnabled = true;
            this.lsbSelection.ItemHeight = 27;
            this.lsbSelection.Items.AddRange(new object[] {
            "Triangular Function",
            "Bell Function",
            "Gaussian Function",
            "Sigmoidal Function"});
            this.lsbSelection.Location = new System.Drawing.Point(295, 71);
            this.lsbSelection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lsbSelection.Name = "lsbSelection";
            this.lsbSelection.Size = new System.Drawing.Size(245, 220);
            this.lsbSelection.TabIndex = 0;
            this.lsbSelection.SelectedIndexChanged += new System.EventHandler(this.lsbSelection_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnClearGraph);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(295, 311);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 235);
            this.panel1.TabIndex = 1;
            // 
            // btnClearGraph
            // 
            this.btnClearGraph.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearGraph.Location = new System.Drawing.Point(39, 136);
            this.btnClearGraph.Name = "btnClearGraph";
            this.btnClearGraph.Size = new System.Drawing.Size(165, 49);
            this.btnClearGraph.TabIndex = 2;
            this.btnClearGraph.Text = "Clear Panel";
            this.btnClearGraph.UseVisualStyleBackColor = true;
            this.btnClearGraph.Click += new System.EventHandler(this.btnClearGraph_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(39, 62);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(165, 49);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create Graph";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tasks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F);
            this.label2.Location = new System.Drawing.Point(306, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Available Function";
            // 
            // theChart
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.Name = "ChartArea1";
            this.theChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.theChart.Legends.Add(legend1);
            this.theChart.Location = new System.Drawing.Point(560, 19);
            this.theChart.Name = "theChart";
            this.theChart.Size = new System.Drawing.Size(785, 527);
            this.theChart.TabIndex = 3;
            this.theChart.Text = "chart1";
            // 
            // nudPar0
            // 
            this.nudPar0.DecimalPlaces = 3;
            this.nudPar0.Location = new System.Drawing.Point(156, 111);
            this.nudPar0.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPar0.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudPar0.Name = "nudPar0";
            this.nudPar0.Size = new System.Drawing.Size(120, 25);
            this.nudPar0.TabIndex = 4;
            this.nudPar0.Value = new decimal(new int[] {
            314,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F);
            this.label3.Location = new System.Drawing.Point(57, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Parameters";
            // 
            // labPar0
            // 
            this.labPar0.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labPar0.AutoSize = true;
            this.labPar0.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labPar0.Location = new System.Drawing.Point(12, 119);
            this.labPar0.Name = "labPar0";
            this.labPar0.Size = new System.Drawing.Size(39, 17);
            this.labPar0.TabIndex = 6;
            this.labPar0.Text = "Text";
            this.labPar0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labPar1
            // 
            this.labPar1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labPar1.AutoSize = true;
            this.labPar1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labPar1.Location = new System.Drawing.Point(12, 154);
            this.labPar1.Name = "labPar1";
            this.labPar1.Size = new System.Drawing.Size(39, 17);
            this.labPar1.TabIndex = 8;
            this.labPar1.Text = "Text";
            this.labPar1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nudPar1
            // 
            this.nudPar1.DecimalPlaces = 3;
            this.nudPar1.Location = new System.Drawing.Point(156, 146);
            this.nudPar1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPar1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudPar1.Name = "nudPar1";
            this.nudPar1.Size = new System.Drawing.Size(120, 25);
            this.nudPar1.TabIndex = 7;
            this.nudPar1.Value = new decimal(new int[] {
            314,
            0,
            0,
            131072});
            // 
            // nudPar2
            // 
            this.nudPar2.DecimalPlaces = 3;
            this.nudPar2.Location = new System.Drawing.Point(156, 179);
            this.nudPar2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPar2.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudPar2.Name = "nudPar2";
            this.nudPar2.Size = new System.Drawing.Size(120, 25);
            this.nudPar2.TabIndex = 9;
            this.nudPar2.Value = new decimal(new int[] {
            314,
            0,
            0,
            131072});
            // 
            // labPar2
            // 
            this.labPar2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labPar2.AutoSize = true;
            this.labPar2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labPar2.Location = new System.Drawing.Point(12, 187);
            this.labPar2.Name = "labPar2";
            this.labPar2.Size = new System.Drawing.Size(39, 17);
            this.labPar2.TabIndex = 10;
            this.labPar2.Text = "Text";
            this.labPar2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labPar3
            // 
            this.labPar3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labPar3.AutoSize = true;
            this.labPar3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labPar3.Location = new System.Drawing.Point(12, 221);
            this.labPar3.Name = "labPar3";
            this.labPar3.Size = new System.Drawing.Size(39, 17);
            this.labPar3.TabIndex = 11;
            this.labPar3.Text = "Text";
            this.labPar3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nudPar3
            // 
            this.nudPar3.DecimalPlaces = 3;
            this.nudPar3.Location = new System.Drawing.Point(156, 219);
            this.nudPar3.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPar3.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudPar3.Name = "nudPar3";
            this.nudPar3.Size = new System.Drawing.Size(120, 25);
            this.nudPar3.TabIndex = 12;
            this.nudPar3.Value = new decimal(new int[] {
            314,
            0,
            0,
            131072});
            // 
            // picBoxFunc
            // 
            this.picBoxFunc.Location = new System.Drawing.Point(15, 311);
            this.picBoxFunc.Name = "picBoxFunc";
            this.picBoxFunc.Size = new System.Drawing.Size(261, 235);
            this.picBoxFunc.TabIndex = 13;
            this.picBoxFunc.TabStop = false;
            // 
            // labPar4
            // 
            this.labPar4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labPar4.AutoSize = true;
            this.labPar4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labPar4.Location = new System.Drawing.Point(12, 79);
            this.labPar4.Name = "labPar4";
            this.labPar4.Size = new System.Drawing.Size(39, 17);
            this.labPar4.TabIndex = 15;
            this.labPar4.Text = "Text";
            this.labPar4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nudPar4
            // 
            this.nudPar4.DecimalPlaces = 3;
            this.nudPar4.Location = new System.Drawing.Point(156, 71);
            this.nudPar4.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPar4.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudPar4.Name = "nudPar4";
            this.nudPar4.Size = new System.Drawing.Size(120, 25);
            this.nudPar4.TabIndex = 14;
            this.nudPar4.Value = new decimal(new int[] {
            314,
            0,
            0,
            131072});
            // 
            // Ass02Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 598);
            this.Controls.Add(this.labPar4);
            this.Controls.Add(this.nudPar4);
            this.Controls.Add(this.picBoxFunc);
            this.Controls.Add(this.nudPar3);
            this.Controls.Add(this.labPar3);
            this.Controls.Add(this.labPar2);
            this.Controls.Add(this.nudPar2);
            this.Controls.Add(this.labPar1);
            this.Controls.Add(this.nudPar1);
            this.Controls.Add(this.labPar0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudPar0);
            this.Controls.Add(this.theChart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lsbSelection);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Ass02Form";
            this.Text = "Ass02 Form";
            this.Load += new System.EventHandler(this.Ass02Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPar0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFunc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPar4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbSelection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataVisualization.Charting.Chart theChart;
        private System.Windows.Forms.NumericUpDown nudPar0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labPar0;
        private System.Windows.Forms.Label labPar1;
        private System.Windows.Forms.NumericUpDown nudPar1;
        private System.Windows.Forms.NumericUpDown nudPar2;
        private System.Windows.Forms.Label labPar2;
        private System.Windows.Forms.Button btnClearGraph;
        private System.Windows.Forms.Label labPar3;
        private System.Windows.Forms.NumericUpDown nudPar3;
        private System.Windows.Forms.PictureBox picBoxFunc;
        private System.Windows.Forms.Label labPar4;
        private System.Windows.Forms.NumericUpDown nudPar4;
    }
}

