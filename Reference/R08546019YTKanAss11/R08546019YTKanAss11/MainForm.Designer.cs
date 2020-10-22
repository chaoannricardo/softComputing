namespace R08546019YTKanAss11
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbcObjNSol = new System.Windows.Forms.TabControl();
            this.pagObjective = new System.Windows.Forms.TabPage();
            this.pagSolutionsInfo = new System.Windows.Forms.TabPage();
            this.ltbSolutions = new System.Windows.Forms.ListBox();
            this.ckxShowSolutions = new System.Windows.Forms.CheckBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.labSoFarTheBestSolution = new System.Windows.Forms.Label();
            this.rtbSoFarTheBestSolution = new System.Windows.Forms.RichTextBox();
            this.btnRunToEnd = new System.Windows.Forms.Button();
            this.btnRunOneIteration = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCreateSolver = new System.Windows.Forms.Button();
            this.ckxRealTimeUpdate = new System.Windows.Forms.CheckBox();
            this.rbtnGA = new System.Windows.Forms.RadioButton();
            this.rbtnPSO = new System.Windows.Forms.RadioButton();
            this.labSoFarTheBestObjectiveValue = new System.Windows.Forms.Label();
            this.ppgTarget = new System.Windows.Forms.PropertyGrid();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.tbcObjNSol.SuspendLayout();
            this.pagSolutionsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menuStrip1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1444, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(110, 22);
            this.tsmOpen.Text = "Open";
            this.tsmOpen.Click += new System.EventHandler(this.OpenABenchmark);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labStatus,
            this.pgbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 850);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1444, 31);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = false;
            this.labStatus.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(1175, 26);
            this.labStatus.Spring = true;
            this.labStatus.Text = "Time Spent";
            // 
            // pgbStatus
            // 
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(250, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1444, 32);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOpen
            // 
            this.tsbOpen.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tsbOpen.Image = global::R08546019YTKanAss11.Properties.Resources.open;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(155, 29);
            this.tsbOpen.Text = "Open A Benchmark";
            this.tsbOpen.Click += new System.EventHandler(this.OpenABenchmark);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 59);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1444, 791);
            this.splitContainer1.SplitterDistance = 383;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(1057, 791);
            this.splitContainer2.SplitterDistance = 694;
            this.splitContainer2.TabIndex = 0;
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
            this.splitContainer3.Panel1.Controls.Add(this.mainChart);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tbcObjNSol);
            this.splitContainer3.Size = new System.Drawing.Size(694, 791);
            this.splitContainer3.SplitterDistance = 339;
            this.splitContainer3.TabIndex = 0;
            // 
            // mainChart
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.Title = "Iteration";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.Title = "Objective";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            chartArea1.Name = "ChartArea1";
            this.mainChart.ChartAreas.Add(chartArea1);
            this.mainChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(0, 0);
            this.mainChart.Name = "mainChart";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.YellowGreen;
            series1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Iteration Average";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DeepSkyBlue;
            series2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "Iteration Best";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Legend = "Legend1";
            series3.Name = "So Far The Best";
            this.mainChart.Series.Add(series1);
            this.mainChart.Series.Add(series2);
            this.mainChart.Series.Add(series3);
            this.mainChart.Size = new System.Drawing.Size(694, 339);
            this.mainChart.TabIndex = 0;
            this.mainChart.Text = "chart1";
            // 
            // tbcObjNSol
            // 
            this.tbcObjNSol.Controls.Add(this.pagObjective);
            this.tbcObjNSol.Controls.Add(this.pagSolutionsInfo);
            this.tbcObjNSol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcObjNSol.Location = new System.Drawing.Point(0, 0);
            this.tbcObjNSol.Name = "tbcObjNSol";
            this.tbcObjNSol.SelectedIndex = 0;
            this.tbcObjNSol.Size = new System.Drawing.Size(694, 448);
            this.tbcObjNSol.TabIndex = 0;
            // 
            // pagObjective
            // 
            this.pagObjective.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pagObjective.Location = new System.Drawing.Point(4, 25);
            this.pagObjective.Name = "pagObjective";
            this.pagObjective.Padding = new System.Windows.Forms.Padding(3);
            this.pagObjective.Size = new System.Drawing.Size(686, 419);
            this.pagObjective.TabIndex = 0;
            this.pagObjective.Text = "Objective";
            this.pagObjective.UseVisualStyleBackColor = true;
            // 
            // pagSolutionsInfo
            // 
            this.pagSolutionsInfo.Controls.Add(this.ltbSolutions);
            this.pagSolutionsInfo.Controls.Add(this.ckxShowSolutions);
            this.pagSolutionsInfo.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.pagSolutionsInfo.Location = new System.Drawing.Point(4, 22);
            this.pagSolutionsInfo.Name = "pagSolutionsInfo";
            this.pagSolutionsInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pagSolutionsInfo.Size = new System.Drawing.Size(811, 471);
            this.pagSolutionsInfo.TabIndex = 1;
            this.pagSolutionsInfo.Text = "Solutions Info";
            this.pagSolutionsInfo.UseVisualStyleBackColor = true;
            // 
            // ltbSolutions
            // 
            this.ltbSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ltbSolutions.FormattingEnabled = true;
            this.ltbSolutions.HorizontalScrollbar = true;
            this.ltbSolutions.ItemHeight = 16;
            this.ltbSolutions.Location = new System.Drawing.Point(15, 47);
            this.ltbSolutions.Name = "ltbSolutions";
            this.ltbSolutions.ScrollAlwaysVisible = true;
            this.ltbSolutions.Size = new System.Drawing.Size(780, 404);
            this.ltbSolutions.TabIndex = 15;
            // 
            // ckxShowSolutions
            // 
            this.ckxShowSolutions.AutoSize = true;
            this.ckxShowSolutions.Location = new System.Drawing.Point(15, 13);
            this.ckxShowSolutions.Name = "ckxShowSolutions";
            this.ckxShowSolutions.Size = new System.Drawing.Size(113, 20);
            this.ckxShowSolutions.TabIndex = 14;
            this.ckxShowSolutions.Text = "Show Solutions";
            this.ckxShowSolutions.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.labSoFarTheBestSolution);
            this.splitContainer4.Panel1.Controls.Add(this.rtbSoFarTheBestSolution);
            this.splitContainer4.Panel1.Controls.Add(this.btnRunToEnd);
            this.splitContainer4.Panel1.Controls.Add(this.btnRunOneIteration);
            this.splitContainer4.Panel1.Controls.Add(this.btnReset);
            this.splitContainer4.Panel1.Controls.Add(this.btnCreateSolver);
            this.splitContainer4.Panel1.Controls.Add(this.ckxRealTimeUpdate);
            this.splitContainer4.Panel1.Controls.Add(this.rbtnGA);
            this.splitContainer4.Panel1.Controls.Add(this.rbtnPSO);
            this.splitContainer4.Panel1.Controls.Add(this.labSoFarTheBestObjectiveValue);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.ppgTarget);
            this.splitContainer4.Size = new System.Drawing.Size(359, 791);
            this.splitContainer4.SplitterDistance = 343;
            this.splitContainer4.TabIndex = 0;
            // 
            // labSoFarTheBestSolution
            // 
            this.labSoFarTheBestSolution.AutoSize = true;
            this.labSoFarTheBestSolution.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labSoFarTheBestSolution.ForeColor = System.Drawing.Color.Navy;
            this.labSoFarTheBestSolution.Location = new System.Drawing.Point(7, 230);
            this.labSoFarTheBestSolution.Name = "labSoFarTheBestSolution";
            this.labSoFarTheBestSolution.Size = new System.Drawing.Size(169, 17);
            this.labSoFarTheBestSolution.TabIndex = 10;
            this.labSoFarTheBestSolution.Text = "So Far The Best Solution :  ";
            // 
            // rtbSoFarTheBestSolution
            // 
            this.rtbSoFarTheBestSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSoFarTheBestSolution.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSoFarTheBestSolution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSoFarTheBestSolution.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbSoFarTheBestSolution.ForeColor = System.Drawing.Color.Navy;
            this.rtbSoFarTheBestSolution.Location = new System.Drawing.Point(10, 248);
            this.rtbSoFarTheBestSolution.Name = "rtbSoFarTheBestSolution";
            this.rtbSoFarTheBestSolution.Size = new System.Drawing.Size(340, 181);
            this.rtbSoFarTheBestSolution.TabIndex = 18;
            this.rtbSoFarTheBestSolution.Text = "";
            // 
            // btnRunToEnd
            // 
            this.btnRunToEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunToEnd.BackColor = System.Drawing.Color.PowderBlue;
            this.btnRunToEnd.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRunToEnd.Location = new System.Drawing.Point(10, 142);
            this.btnRunToEnd.Name = "btnRunToEnd";
            this.btnRunToEnd.Size = new System.Drawing.Size(340, 30);
            this.btnRunToEnd.TabIndex = 17;
            this.btnRunToEnd.Text = "Run To End";
            this.btnRunToEnd.UseVisualStyleBackColor = false;
            this.btnRunToEnd.Click += new System.EventHandler(this.btnRunToEnd_Click);
            // 
            // btnRunOneIteration
            // 
            this.btnRunOneIteration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunOneIteration.BackColor = System.Drawing.Color.PowderBlue;
            this.btnRunOneIteration.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRunOneIteration.Location = new System.Drawing.Point(10, 107);
            this.btnRunOneIteration.Name = "btnRunOneIteration";
            this.btnRunOneIteration.Size = new System.Drawing.Size(340, 30);
            this.btnRunOneIteration.TabIndex = 16;
            this.btnRunOneIteration.Text = "Run One Iteration";
            this.btnRunOneIteration.UseVisualStyleBackColor = false;
            this.btnRunOneIteration.Click += new System.EventHandler(this.btnRunOneIteration_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.PowderBlue;
            this.btnReset.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReset.Location = new System.Drawing.Point(10, 72);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(340, 30);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCreateSolver
            // 
            this.btnCreateSolver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateSolver.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCreateSolver.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateSolver.Location = new System.Drawing.Point(10, 37);
            this.btnCreateSolver.Name = "btnCreateSolver";
            this.btnCreateSolver.Size = new System.Drawing.Size(340, 30);
            this.btnCreateSolver.TabIndex = 14;
            this.btnCreateSolver.Text = "Create Solver";
            this.btnCreateSolver.UseVisualStyleBackColor = false;
            this.btnCreateSolver.Click += new System.EventHandler(this.btnCreateSolver_Click);
            // 
            // ckxRealTimeUpdate
            // 
            this.ckxRealTimeUpdate.AutoSize = true;
            this.ckxRealTimeUpdate.Location = new System.Drawing.Point(10, 180);
            this.ckxRealTimeUpdate.Name = "ckxRealTimeUpdate";
            this.ckxRealTimeUpdate.Size = new System.Drawing.Size(130, 20);
            this.ckxRealTimeUpdate.TabIndex = 13;
            this.ckxRealTimeUpdate.Text = "Real-time Update";
            this.ckxRealTimeUpdate.UseVisualStyleBackColor = true;
            // 
            // rbtnGA
            // 
            this.rbtnGA.AutoSize = true;
            this.rbtnGA.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnGA.ForeColor = System.Drawing.Color.Navy;
            this.rbtnGA.Location = new System.Drawing.Point(79, 8);
            this.rbtnGA.Name = "rbtnGA";
            this.rbtnGA.Size = new System.Drawing.Size(45, 21);
            this.rbtnGA.TabIndex = 12;
            this.rbtnGA.Text = "GA";
            this.rbtnGA.UseVisualStyleBackColor = true;
            // 
            // rbtnPSO
            // 
            this.rbtnPSO.AutoSize = true;
            this.rbtnPSO.Checked = true;
            this.rbtnPSO.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnPSO.ForeColor = System.Drawing.Color.Navy;
            this.rbtnPSO.Location = new System.Drawing.Point(10, 8);
            this.rbtnPSO.Name = "rbtnPSO";
            this.rbtnPSO.Size = new System.Drawing.Size(53, 21);
            this.rbtnPSO.TabIndex = 11;
            this.rbtnPSO.TabStop = true;
            this.rbtnPSO.Text = "PSO";
            this.rbtnPSO.UseVisualStyleBackColor = true;
            // 
            // labSoFarTheBestObjectiveValue
            // 
            this.labSoFarTheBestObjectiveValue.AutoSize = true;
            this.labSoFarTheBestObjectiveValue.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labSoFarTheBestObjectiveValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labSoFarTheBestObjectiveValue.Location = new System.Drawing.Point(7, 206);
            this.labSoFarTheBestObjectiveValue.Name = "labSoFarTheBestObjectiveValue";
            this.labSoFarTheBestObjectiveValue.Size = new System.Drawing.Size(211, 17);
            this.labSoFarTheBestObjectiveValue.TabIndex = 9;
            this.labSoFarTheBestObjectiveValue.Text = "So Far The Best Objective Value : ";
            // 
            // ppgTarget
            // 
            this.ppgTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppgTarget.Location = new System.Drawing.Point(0, 0);
            this.ppgTarget.Name = "ppgTarget";
            this.ppgTarget.Size = new System.Drawing.Size(359, 444);
            this.ppgTarget.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 881);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Particle Swarm Optimization for Continuous Optimization Problems";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.tbcObjNSol.ResumeLayout(false);
            this.pagSolutionsInfo.ResumeLayout(false);
            this.pagSolutionsInfo.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labStatus;
        private System.Windows.Forms.ToolStripProgressBar pgbStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.TabControl tbcObjNSol;
        private System.Windows.Forms.TabPage pagObjective;
        private System.Windows.Forms.TabPage pagSolutionsInfo;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PropertyGrid ppgTarget;
        private System.Windows.Forms.Button btnRunToEnd;
        private System.Windows.Forms.Button btnRunOneIteration;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCreateSolver;
        private System.Windows.Forms.CheckBox ckxRealTimeUpdate;
        private System.Windows.Forms.RadioButton rbtnGA;
        private System.Windows.Forms.RadioButton rbtnPSO;
        private System.Windows.Forms.Label labSoFarTheBestSolution;
        private System.Windows.Forms.Label labSoFarTheBestObjectiveValue;
        private System.Windows.Forms.ListBox ltbSolutions;
        private System.Windows.Forms.CheckBox ckxShowSolutions;
        private System.Windows.Forms.RichTextBox rtbSoFarTheBestSolution;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

