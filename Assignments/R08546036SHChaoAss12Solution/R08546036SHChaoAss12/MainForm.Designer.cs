
namespace R08546036SHChaoAss12
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openFromFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printNNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.lbNeurons = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nUpDownNeuronNumbers = new System.Windows.Forms.NumericUpDown();
            this.nUpDownHiddenLayers = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneralizedData = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.btnReset = new System.Windows.Forms.Button();
            this.gridSolver = new System.Windows.Forms.PropertyGrid();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTrainToEnd = new System.Windows.Forms.Button();
            this.btnTrainAnEpoch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClassificationTest = new System.Windows.Forms.Button();
            this.tabPSO = new System.Windows.Forms.TabPage();
            this.tabGA = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pDocNN = new System.Drawing.Printing.PrintDocument();
            this.dlgPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownNeuronNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownHiddenLayers)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneralizedData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "dlgOpen";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFromFilesToolStripMenuItem,
            this.printNNToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1332, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openFromFilesToolStripMenuItem
            // 
            this.openFromFilesToolStripMenuItem.Name = "openFromFilesToolStripMenuItem";
            this.openFromFilesToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.openFromFilesToolStripMenuItem.Text = "Open From Files";
            this.openFromFilesToolStripMenuItem.Click += new System.EventHandler(this.openFromFilesToolStripMenuItem_Click);
            // 
            // printNNToolStripMenuItem
            // 
            this.printNNToolStripMenuItem.Name = "printNNToolStripMenuItem";
            this.printNNToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.printNNToolStripMenuItem.Text = "PrintNN";
            this.printNNToolStripMenuItem.Click += new System.EventHandler(this.printNNToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1332, 649);
            this.splitContainer1.SplitterDistance = 618;
            this.splitContainer1.TabIndex = 1;
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer7);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(618, 649);
            this.splitContainer2.SplitterDistance = 233;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.label5);
            this.splitContainer7.Panel1.Controls.Add(this.lbNeurons);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.label4);
            this.splitContainer7.Panel2.Controls.Add(this.label3);
            this.splitContainer7.Panel2.Controls.Add(this.nUpDownNeuronNumbers);
            this.splitContainer7.Panel2.Controls.Add(this.nUpDownHiddenLayers);
            this.splitContainer7.Size = new System.Drawing.Size(618, 233);
            this.splitContainer7.SplitterDistance = 125;
            this.splitContainer7.TabIndex = 0;
            // 
            // lbNeurons
            // 
            this.lbNeurons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNeurons.FormattingEnabled = true;
            this.lbNeurons.ItemHeight = 16;
            this.lbNeurons.Items.AddRange(new object[] {
            "4"});
            this.lbNeurons.Location = new System.Drawing.Point(12, 39);
            this.lbNeurons.Name = "lbNeurons";
            this.lbNeurons.Size = new System.Drawing.Size(95, 180);
            this.lbNeurons.TabIndex = 0;
            this.lbNeurons.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1178, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Graph Demo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Neuron Numbers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hidden Layers";
            // 
            // nUpDownNeuronNumbers
            // 
            this.nUpDownNeuronNumbers.Location = new System.Drawing.Point(253, 49);
            this.nUpDownNeuronNumbers.Name = "nUpDownNeuronNumbers";
            this.nUpDownNeuronNumbers.Size = new System.Drawing.Size(201, 22);
            this.nUpDownNeuronNumbers.TabIndex = 3;
            this.nUpDownNeuronNumbers.ValueChanged += new System.EventHandler(this.nUpDownNeuronNumbers_ValueChanged);
            // 
            // nUpDownHiddenLayers
            // 
            this.nUpDownHiddenLayers.Location = new System.Drawing.Point(253, 20);
            this.nUpDownHiddenLayers.Name = "nUpDownHiddenLayers";
            this.nUpDownHiddenLayers.Size = new System.Drawing.Size(201, 22);
            this.nUpDownHiddenLayers.TabIndex = 2;
            this.nUpDownHiddenLayers.ValueChanged += new System.EventHandler(this.nUpDownHiddenLayers_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneralizedData);
            this.tabControl1.Controls.Add(this.tabPSO);
            this.tabControl1.Controls.Add(this.tabGA);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(618, 412);
            this.tabControl1.TabIndex = 0;
            // 
            // tabGeneralizedData
            // 
            this.tabGeneralizedData.Controls.Add(this.splitContainer4);
            this.tabGeneralizedData.Location = new System.Drawing.Point(4, 25);
            this.tabGeneralizedData.Name = "tabGeneralizedData";
            this.tabGeneralizedData.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneralizedData.Size = new System.Drawing.Size(610, 383);
            this.tabGeneralizedData.TabIndex = 0;
            this.tabGeneralizedData.Text = "Generalized Delta";
            this.tabGeneralizedData.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer4.Size = new System.Drawing.Size(604, 377);
            this.splitContainer4.SplitterDistance = 238;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.btnReset);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.gridSolver);
            this.splitContainer5.Size = new System.Drawing.Size(238, 377);
            this.splitContainer5.SplitterDistance = 130;
            this.splitContainer5.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(16, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(206, 40);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // gridSolver
            // 
            this.gridSolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSolver.Location = new System.Drawing.Point(0, 0);
            this.gridSolver.Name = "gridSolver";
            this.gridSolver.Size = new System.Drawing.Size(238, 243);
            this.gridSolver.TabIndex = 2;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.label1);
            this.splitContainer6.Panel1.Controls.Add(this.btnTrainToEnd);
            this.splitContainer6.Panel1.Controls.Add(this.btnTrainAnEpoch);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.label2);
            this.splitContainer6.Panel2.Controls.Add(this.btnClassificationTest);
            this.splitContainer6.Size = new System.Drawing.Size(362, 377);
            this.splitContainer6.SplitterDistance = 138;
            this.splitContainer6.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // btnTrainToEnd
            // 
            this.btnTrainToEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrainToEnd.Location = new System.Drawing.Point(16, 48);
            this.btnTrainToEnd.Name = "btnTrainToEnd";
            this.btnTrainToEnd.Size = new System.Drawing.Size(330, 34);
            this.btnTrainToEnd.TabIndex = 8;
            this.btnTrainToEnd.Text = "Train To End";
            this.btnTrainToEnd.UseVisualStyleBackColor = true;
            this.btnTrainToEnd.Click += new System.EventHandler(this.btnTrainToEnd_Click);
            // 
            // btnTrainAnEpoch
            // 
            this.btnTrainAnEpoch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrainAnEpoch.Location = new System.Drawing.Point(16, 8);
            this.btnTrainAnEpoch.Name = "btnTrainAnEpoch";
            this.btnTrainAnEpoch.Size = new System.Drawing.Size(330, 34);
            this.btnTrainAnEpoch.TabIndex = 7;
            this.btnTrainAnEpoch.Text = "Train An Epoch";
            this.btnTrainAnEpoch.UseVisualStyleBackColor = true;
            this.btnTrainAnEpoch.Click += new System.EventHandler(this.btnTrainAnEpoch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // btnClassificationTest
            // 
            this.btnClassificationTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClassificationTest.Location = new System.Drawing.Point(16, 19);
            this.btnClassificationTest.Name = "btnClassificationTest";
            this.btnClassificationTest.Size = new System.Drawing.Size(330, 34);
            this.btnClassificationTest.TabIndex = 7;
            this.btnClassificationTest.Text = "Classification Test";
            this.btnClassificationTest.UseVisualStyleBackColor = true;
            // 
            // tabPSO
            // 
            this.tabPSO.Location = new System.Drawing.Point(4, 25);
            this.tabPSO.Name = "tabPSO";
            this.tabPSO.Padding = new System.Windows.Forms.Padding(3);
            this.tabPSO.Size = new System.Drawing.Size(610, 383);
            this.tabPSO.TabIndex = 1;
            this.tabPSO.Text = "PSO";
            this.tabPSO.UseVisualStyleBackColor = true;
            // 
            // tabGA
            // 
            this.tabGA.Location = new System.Drawing.Point(4, 25);
            this.tabGA.Name = "tabGA";
            this.tabGA.Size = new System.Drawing.Size(610, 383);
            this.tabGA.TabIndex = 2;
            this.tabGA.Text = "GA";
            this.tabGA.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer3.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer3_Panel2_Paint);
            this.splitContainer3.Size = new System.Drawing.Size(710, 649);
            this.splitContainer3.SplitterDistance = 235;
            this.splitContainer3.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(710, 235);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // pDocNN
            // 
            this.pDocNN.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pDocNN_PrintPage);
            // 
            // dlgPreview
            // 
            this.dlgPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.dlgPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.dlgPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.dlgPreview.Document = this.pDocNN;
            this.dlgPreview.Enabled = true;
            this.dlgPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("dlgPreview.Icon")));
            this.dlgPreview.Name = "dlgPreview";
            this.dlgPreview.Visible = false;
            this.dlgPreview.Click += new System.EventHandler(this.dlgPreview_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Neuron Num for Each Hidden Layer";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 677);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MLP";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel1.PerformLayout();
            this.splitContainer7.Panel2.ResumeLayout(false);
            this.splitContainer7.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownNeuronNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDownHiddenLayers)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneralizedData.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openFromFilesToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneralizedData;
        private System.Windows.Forms.TabPage tabPSO;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TabPage tabGA;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.PropertyGrid gridSolver;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Button btnTrainToEnd;
        private System.Windows.Forms.Button btnTrainAnEpoch;
        private System.Windows.Forms.Button btnClassificationTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.NumericUpDown nUpDownNeuronNumbers;
        private System.Windows.Forms.NumericUpDown nUpDownHiddenLayers;
        private System.Windows.Forms.ListBox lbNeurons;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument pDocNN;
        private System.Windows.Forms.ToolStripMenuItem printNNToolStripMenuItem;
        private System.Windows.Forms.PrintPreviewDialog dlgPreview;
        private System.Windows.Forms.Label label5;
    }
}

