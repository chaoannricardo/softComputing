namespace R08546019YTKanAss05
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Input Universe");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Output Universe");
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCreateUniverse = new System.Windows.Forms.Button();
            this.trvUniverses = new System.Windows.Forms.TreeView();
            this.ppgTarget = new System.Windows.Forms.PropertyGrid();
            this.cbxFSTypes = new System.Windows.Forms.ComboBox();
            this.btnCreateFuzzySet = new System.Windows.Forms.Button();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbxUnaryOperators = new System.Windows.Forms.ComboBox();
            this.btnCreateUnaryOperatedFS = new System.Windows.Forms.Button();
            this.cbxBinaryOperators = new System.Windows.Forms.ComboBox();
            this.btnCreateBinaryOperatedFS = new System.Windows.Forms.Button();
            this.labOperand1 = new System.Windows.Forms.Label();
            this.labOperand2 = new System.Windows.Forms.Label();
            this.gpxUnaryOperatedFS = new System.Windows.Forms.GroupBox();
            this.labUnaryOperators = new System.Windows.Forms.Label();
            this.gpxBinaryOperatedFS = new System.Windows.Forms.GroupBox();
            this.btnDeleteOperands = new System.Windows.Forms.Button();
            this.labOperands = new System.Windows.Forms.Label();
            this.labBinaryOperators = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.txbTitle = new System.Windows.Forms.TextBox();
            this.tbcFS_Rules = new System.Windows.Forms.TabControl();
            this.tbpFS = new System.Windows.Forms.TabPage();
            this.gpxPrimaryFuzzySet = new System.Windows.Forms.GroupBox();
            this.labFSType = new System.Windows.Forms.Label();
            this.tbpIfThenRules = new System.Windows.Forms.TabPage();
            this.rbtnScale = new System.Windows.Forms.RadioButton();
            this.rbtnCut = new System.Windows.Forms.RadioButton();
            this.btnDeleteRule = new System.Windows.Forms.Button();
            this.btnSingleInference = new System.Windows.Forms.Button();
            this.btnAddRules = new System.Windows.Forms.Button();
            this.labCondition = new System.Windows.Forms.Label();
            this.labRules = new System.Windows.Forms.Label();
            this.dgvCondition = new System.Windows.Forms.DataGridView();
            this.dgvRules = new System.Windows.Forms.DataGridView();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.labCrisp = new System.Windows.Forms.Label();
            this.txbCrisp = new System.Windows.Forms.TextBox();
            this.btnCrispAllInference = new System.Windows.Forms.Button();
            this.rbtnMamdani = new System.Windows.Forms.RadioButton();
            this.rbtnSugeno = new System.Windows.Forms.RadioButton();
            this.rbtnTsukamoto = new System.Windows.Forms.RadioButton();
            this.pagSugeno = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tChart1 = new Steema.TeeChart.TChart();
            this.chartController1 = new Steema.TeeChart.ChartController();
            this.surface1 = new Steema.TeeChart.Styles.Surface();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.gpxUnaryOperatedFS.SuspendLayout();
            this.gpxBinaryOperatedFS.SuspendLayout();
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
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tbcFS_Rules.SuspendLayout();
            this.tbpFS.SuspendLayout();
            this.gpxPrimaryFuzzySet.SuspendLayout();
            this.tbpIfThenRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.pagSugeno.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateUniverse
            // 
            this.btnCreateUniverse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCreateUniverse.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateUniverse.Location = new System.Drawing.Point(12, 4);
            this.btnCreateUniverse.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateUniverse.Name = "btnCreateUniverse";
            this.btnCreateUniverse.Size = new System.Drawing.Size(165, 30);
            this.btnCreateUniverse.TabIndex = 0;
            this.btnCreateUniverse.Text = "New Universe";
            this.btnCreateUniverse.UseVisualStyleBackColor = false;
            this.btnCreateUniverse.Click += new System.EventHandler(this.btnCreateUniverse_Click);
            // 
            // trvUniverses
            // 
            this.trvUniverses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvUniverses.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.trvUniverses.HideSelection = false;
            this.trvUniverses.Location = new System.Drawing.Point(12, 40);
            this.trvUniverses.Name = "trvUniverses";
            treeNode13.Name = "nodeInputUniverse";
            treeNode13.Text = "Input Universe";
            treeNode14.Name = "nodeOutputUniverse";
            treeNode14.Text = "Output Universe";
            this.trvUniverses.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            this.trvUniverses.Size = new System.Drawing.Size(252, 214);
            this.trvUniverses.TabIndex = 1;
            this.trvUniverses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvUniverses_AfterSelect);
            // 
            // ppgTarget
            // 
            this.ppgTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppgTarget.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ppgTarget.Location = new System.Drawing.Point(3, 19);
            this.ppgTarget.Name = "ppgTarget";
            this.ppgTarget.Size = new System.Drawing.Size(261, 218);
            this.ppgTarget.TabIndex = 2;
            this.ppgTarget.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ppgTarget_PropertyValueChanged);
            // 
            // cbxFSTypes
            // 
            this.cbxFSTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFSTypes.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxFSTypes.FormattingEnabled = true;
            this.cbxFSTypes.Items.AddRange(new object[] {
            "Gaussian Fuzzy Set",
            "Triangular Fuzzy Set",
            "Trapezoidal Fuzzy Set",
            "Bell Fuzzy Set",
            "Sigmoidal Fuzzy Set",
            "Left-Right Fuzzy Set",
            "S-Shaped Fuzzy Set",
            "Z-Shaped Fuzzy Set",
            "Pi-Shaped Fuzzy Set"});
            this.cbxFSTypes.Location = new System.Drawing.Point(12, 37);
            this.cbxFSTypes.Name = "cbxFSTypes";
            this.cbxFSTypes.Size = new System.Drawing.Size(295, 25);
            this.cbxFSTypes.TabIndex = 3;
            // 
            // btnCreateFuzzySet
            // 
            this.btnCreateFuzzySet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateFuzzySet.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCreateFuzzySet.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateFuzzySet.ForeColor = System.Drawing.Color.Black;
            this.btnCreateFuzzySet.Location = new System.Drawing.Point(313, 17);
            this.btnCreateFuzzySet.Name = "btnCreateFuzzySet";
            this.btnCreateFuzzySet.Size = new System.Drawing.Size(169, 45);
            this.btnCreateFuzzySet.TabIndex = 4;
            this.btnCreateFuzzySet.Text = "New Fuzzy Set";
            this.btnCreateFuzzySet.UseVisualStyleBackColor = false;
            this.btnCreateFuzzySet.Click += new System.EventHandler(this.btnCreateFuzzySet_Click);
            // 
            // mainChart
            // 
            this.mainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            legend7.Alignment = System.Drawing.StringAlignment.Center;
            legend7.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend7.Name = "Legend1";
            this.mainChart.Legends.Add(legend7);
            this.mainChart.Location = new System.Drawing.Point(13, 7);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(717, 392);
            this.mainChart.TabIndex = 5;
            this.mainChart.Text = "chart1";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDelete.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Location = new System.Drawing.Point(184, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbxUnaryOperators
            // 
            this.cbxUnaryOperators.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxUnaryOperators.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxUnaryOperators.FormattingEnabled = true;
            this.cbxUnaryOperators.Items.AddRange(new object[] {
            "Negate",
            "Alpha Cut",
            "Alpha Scale",
            "Concentration",
            "Dilation",
            "Extremely",
            "Intensification",
            "Diminisher",
            "Sugeno-Negate",
            "Yager-Negate"});
            this.cbxUnaryOperators.Location = new System.Drawing.Point(12, 39);
            this.cbxUnaryOperators.Name = "cbxUnaryOperators";
            this.cbxUnaryOperators.Size = new System.Drawing.Size(295, 25);
            this.cbxUnaryOperators.TabIndex = 8;
            // 
            // btnCreateUnaryOperatedFS
            // 
            this.btnCreateUnaryOperatedFS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateUnaryOperatedFS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreateUnaryOperatedFS.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateUnaryOperatedFS.ForeColor = System.Drawing.Color.White;
            this.btnCreateUnaryOperatedFS.Location = new System.Drawing.Point(313, 19);
            this.btnCreateUnaryOperatedFS.Name = "btnCreateUnaryOperatedFS";
            this.btnCreateUnaryOperatedFS.Size = new System.Drawing.Size(169, 45);
            this.btnCreateUnaryOperatedFS.TabIndex = 9;
            this.btnCreateUnaryOperatedFS.Text = "Generate Unary Operated Fuzzy Set";
            this.btnCreateUnaryOperatedFS.UseVisualStyleBackColor = false;
            this.btnCreateUnaryOperatedFS.Click += new System.EventHandler(this.btnCreateUnaryOperatedFS_Click);
            // 
            // cbxBinaryOperators
            // 
            this.cbxBinaryOperators.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxBinaryOperators.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxBinaryOperators.FormattingEnabled = true;
            this.cbxBinaryOperators.Items.AddRange(new object[] {
            "Minimum T-norm",
            "Algebraic Product",
            "Bounded Product",
            "Drastic Product",
            "Maximum S-norm",
            "Algebraic Sum",
            "Bounded Sum",
            "Drastic Sum",
            "Sugeno T-norm",
            "Yager T-norm",
            "Hamacher T-norm",
            "Schweizer-Sklar T-norm",
            "Sugeno S-norm",
            "Yager S-norm",
            "Hamacher S-norm"});
            this.cbxBinaryOperators.Location = new System.Drawing.Point(12, 39);
            this.cbxBinaryOperators.Name = "cbxBinaryOperators";
            this.cbxBinaryOperators.Size = new System.Drawing.Size(295, 25);
            this.cbxBinaryOperators.TabIndex = 11;
            // 
            // btnCreateBinaryOperatedFS
            // 
            this.btnCreateBinaryOperatedFS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateBinaryOperatedFS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreateBinaryOperatedFS.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateBinaryOperatedFS.ForeColor = System.Drawing.Color.White;
            this.btnCreateBinaryOperatedFS.Location = new System.Drawing.Point(313, 21);
            this.btnCreateBinaryOperatedFS.Name = "btnCreateBinaryOperatedFS";
            this.btnCreateBinaryOperatedFS.Size = new System.Drawing.Size(169, 45);
            this.btnCreateBinaryOperatedFS.TabIndex = 12;
            this.btnCreateBinaryOperatedFS.Text = "Generate Binary Operated Fuzzy Set";
            this.btnCreateBinaryOperatedFS.UseVisualStyleBackColor = false;
            this.btnCreateBinaryOperatedFS.Click += new System.EventHandler(this.btnCreateBinaryOperatedFS_Click);
            // 
            // labOperand1
            // 
            this.labOperand1.AutoSize = true;
            this.labOperand1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.labOperand1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labOperand1.ForeColor = System.Drawing.Color.Black;
            this.labOperand1.Location = new System.Drawing.Point(73, 73);
            this.labOperand1.Name = "labOperand1";
            this.labOperand1.Size = new System.Drawing.Size(161, 16);
            this.labOperand1.TabIndex = 13;
            this.labOperand1.Text = "Click to specify Operand 1";
            this.labOperand1.Click += new System.EventHandler(this.labOperand1_Click_1);
            // 
            // labOperand2
            // 
            this.labOperand2.AutoSize = true;
            this.labOperand2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.labOperand2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labOperand2.ForeColor = System.Drawing.Color.Black;
            this.labOperand2.Location = new System.Drawing.Point(240, 73);
            this.labOperand2.Name = "labOperand2";
            this.labOperand2.Size = new System.Drawing.Size(161, 16);
            this.labOperand2.TabIndex = 14;
            this.labOperand2.Text = "Click to specify Operand 2";
            this.labOperand2.Click += new System.EventHandler(this.labOperand2_Click);
            // 
            // gpxUnaryOperatedFS
            // 
            this.gpxUnaryOperatedFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpxUnaryOperatedFS.Controls.Add(this.btnCreateUnaryOperatedFS);
            this.gpxUnaryOperatedFS.Controls.Add(this.labUnaryOperators);
            this.gpxUnaryOperatedFS.Controls.Add(this.cbxUnaryOperators);
            this.gpxUnaryOperatedFS.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gpxUnaryOperatedFS.ForeColor = System.Drawing.Color.Navy;
            this.gpxUnaryOperatedFS.Location = new System.Drawing.Point(6, 84);
            this.gpxUnaryOperatedFS.Name = "gpxUnaryOperatedFS";
            this.gpxUnaryOperatedFS.Size = new System.Drawing.Size(490, 72);
            this.gpxUnaryOperatedFS.TabIndex = 16;
            this.gpxUnaryOperatedFS.TabStop = false;
            this.gpxUnaryOperatedFS.Text = "Unary Operated Fuzzy Set";
            // 
            // labUnaryOperators
            // 
            this.labUnaryOperators.AutoSize = true;
            this.labUnaryOperators.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labUnaryOperators.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labUnaryOperators.Location = new System.Drawing.Point(9, 21);
            this.labUnaryOperators.Name = "labUnaryOperators";
            this.labUnaryOperators.Size = new System.Drawing.Size(135, 15);
            this.labUnaryOperators.TabIndex = 10;
            this.labUnaryOperators.Text = "Type of Unary Operators";
            // 
            // gpxBinaryOperatedFS
            // 
            this.gpxBinaryOperatedFS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpxBinaryOperatedFS.Controls.Add(this.btnCreateBinaryOperatedFS);
            this.gpxBinaryOperatedFS.Controls.Add(this.btnDeleteOperands);
            this.gpxBinaryOperatedFS.Controls.Add(this.labOperands);
            this.gpxBinaryOperatedFS.Controls.Add(this.labBinaryOperators);
            this.gpxBinaryOperatedFS.Controls.Add(this.labOperand1);
            this.gpxBinaryOperatedFS.Controls.Add(this.labOperand2);
            this.gpxBinaryOperatedFS.Controls.Add(this.cbxBinaryOperators);
            this.gpxBinaryOperatedFS.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gpxBinaryOperatedFS.ForeColor = System.Drawing.Color.Navy;
            this.gpxBinaryOperatedFS.Location = new System.Drawing.Point(6, 162);
            this.gpxBinaryOperatedFS.Name = "gpxBinaryOperatedFS";
            this.gpxBinaryOperatedFS.Size = new System.Drawing.Size(490, 97);
            this.gpxBinaryOperatedFS.TabIndex = 17;
            this.gpxBinaryOperatedFS.TabStop = false;
            this.gpxBinaryOperatedFS.Text = "Binary Operated Fuzzy Set";
            // 
            // btnDeleteOperands
            // 
            this.btnDeleteOperands.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDeleteOperands.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDeleteOperands.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteOperands.Location = new System.Drawing.Point(407, 70);
            this.btnDeleteOperands.Name = "btnDeleteOperands";
            this.btnDeleteOperands.Size = new System.Drawing.Size(50, 22);
            this.btnDeleteOperands.TabIndex = 7;
            this.btnDeleteOperands.Text = "X";
            this.btnDeleteOperands.UseVisualStyleBackColor = false;
            // 
            // labOperands
            // 
            this.labOperands.AutoSize = true;
            this.labOperands.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labOperands.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labOperands.Location = new System.Drawing.Point(9, 73);
            this.labOperands.Name = "labOperands";
            this.labOperands.Size = new System.Drawing.Size(58, 15);
            this.labOperands.TabIndex = 16;
            this.labOperands.Text = "Operands";
            // 
            // labBinaryOperators
            // 
            this.labBinaryOperators.AutoSize = true;
            this.labBinaryOperators.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labBinaryOperators.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labBinaryOperators.Location = new System.Drawing.Point(9, 21);
            this.labBinaryOperators.Name = "labBinaryOperators";
            this.labBinaryOperators.Size = new System.Drawing.Size(137, 15);
            this.labBinaryOperators.TabIndex = 15;
            this.labBinaryOperators.Text = "Type of Binary Operators";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1284, 25);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 663);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 614);
            this.splitContainer1.SplitterDistance = 538;
            this.splitContainer1.TabIndex = 22;
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbcFS_Rules);
            this.splitContainer2.Size = new System.Drawing.Size(538, 614);
            this.splitContainer2.SplitterDistance = 257;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.trvUniverses);
            this.splitContainer3.Panel1.Controls.Add(this.btnCreateUniverse);
            this.splitContainer3.Panel1.Controls.Add(this.btnDelete);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txbTitle);
            this.splitContainer3.Panel2.Controls.Add(this.ppgTarget);
            this.splitContainer3.Size = new System.Drawing.Size(538, 257);
            this.splitContainer3.SplitterDistance = 267;
            this.splitContainer3.TabIndex = 0;
            // 
            // txbTitle
            // 
            this.txbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbTitle.Cursor = System.Windows.Forms.Cursors.No;
            this.txbTitle.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txbTitle.ForeColor = System.Drawing.Color.White;
            this.txbTitle.Location = new System.Drawing.Point(88, 7);
            this.txbTitle.Name = "txbTitle";
            this.txbTitle.Size = new System.Drawing.Size(170, 29);
            this.txbTitle.TabIndex = 3;
            this.txbTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbcFS_Rules
            // 
            this.tbcFS_Rules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcFS_Rules.Controls.Add(this.tbpFS);
            this.tbcFS_Rules.Controls.Add(this.tbpIfThenRules);
            this.tbcFS_Rules.Controls.Add(this.pagSugeno);
            this.tbcFS_Rules.Location = new System.Drawing.Point(14, 3);
            this.tbcFS_Rules.Name = "tbcFS_Rules";
            this.tbcFS_Rules.SelectedIndex = 0;
            this.tbcFS_Rules.Size = new System.Drawing.Size(517, 324);
            this.tbcFS_Rules.TabIndex = 0;
            // 
            // tbpFS
            // 
            this.tbpFS.BackColor = System.Drawing.Color.White;
            this.tbpFS.Controls.Add(this.gpxPrimaryFuzzySet);
            this.tbpFS.Controls.Add(this.gpxBinaryOperatedFS);
            this.tbpFS.Controls.Add(this.gpxUnaryOperatedFS);
            this.tbpFS.Location = new System.Drawing.Point(4, 26);
            this.tbpFS.Name = "tbpFS";
            this.tbpFS.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFS.Size = new System.Drawing.Size(509, 294);
            this.tbpFS.TabIndex = 0;
            this.tbpFS.Text = "Fuzzy Sets";
            // 
            // gpxPrimaryFuzzySet
            // 
            this.gpxPrimaryFuzzySet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpxPrimaryFuzzySet.Controls.Add(this.btnCreateFuzzySet);
            this.gpxPrimaryFuzzySet.Controls.Add(this.labFSType);
            this.gpxPrimaryFuzzySet.Controls.Add(this.cbxFSTypes);
            this.gpxPrimaryFuzzySet.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gpxPrimaryFuzzySet.ForeColor = System.Drawing.Color.Navy;
            this.gpxPrimaryFuzzySet.Location = new System.Drawing.Point(6, 6);
            this.gpxPrimaryFuzzySet.Name = "gpxPrimaryFuzzySet";
            this.gpxPrimaryFuzzySet.Size = new System.Drawing.Size(490, 72);
            this.gpxPrimaryFuzzySet.TabIndex = 18;
            this.gpxPrimaryFuzzySet.TabStop = false;
            this.gpxPrimaryFuzzySet.Text = "Primary Fuzzy Set";
            // 
            // labFSType
            // 
            this.labFSType.AutoSize = true;
            this.labFSType.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labFSType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labFSType.Location = new System.Drawing.Point(9, 19);
            this.labFSType.Name = "labFSType";
            this.labFSType.Size = new System.Drawing.Size(102, 15);
            this.labFSType.TabIndex = 11;
            this.labFSType.Text = "Type of Fuzzy Sets";
            // 
            // tbpIfThenRules
            // 
            this.tbpIfThenRules.Controls.Add(this.labCrisp);
            this.tbpIfThenRules.Controls.Add(this.rbtnScale);
            this.tbpIfThenRules.Controls.Add(this.txbCrisp);
            this.tbpIfThenRules.Controls.Add(this.rbtnCut);
            this.tbpIfThenRules.Controls.Add(this.btnCrispAllInference);
            this.tbpIfThenRules.Controls.Add(this.btnDeleteRule);
            this.tbpIfThenRules.Controls.Add(this.btnSingleInference);
            this.tbpIfThenRules.Controls.Add(this.btnAddRules);
            this.tbpIfThenRules.Controls.Add(this.labCondition);
            this.tbpIfThenRules.Controls.Add(this.labRules);
            this.tbpIfThenRules.Controls.Add(this.dgvCondition);
            this.tbpIfThenRules.Controls.Add(this.dgvRules);
            this.tbpIfThenRules.Location = new System.Drawing.Point(4, 26);
            this.tbpIfThenRules.Name = "tbpIfThenRules";
            this.tbpIfThenRules.Padding = new System.Windows.Forms.Padding(3);
            this.tbpIfThenRules.Size = new System.Drawing.Size(509, 294);
            this.tbpIfThenRules.TabIndex = 1;
            this.tbpIfThenRules.Text = "If-Then Rules";
            this.tbpIfThenRules.UseVisualStyleBackColor = true;
            // 
            // rbtnScale
            // 
            this.rbtnScale.AutoSize = true;
            this.rbtnScale.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnScale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnScale.Location = new System.Drawing.Point(143, 174);
            this.rbtnScale.Name = "rbtnScale";
            this.rbtnScale.Size = new System.Drawing.Size(56, 20);
            this.rbtnScale.TabIndex = 8;
            this.rbtnScale.TabStop = true;
            this.rbtnScale.Text = "Scale";
            this.rbtnScale.UseVisualStyleBackColor = true;
            // 
            // rbtnCut
            // 
            this.rbtnCut.AutoSize = true;
            this.rbtnCut.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnCut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnCut.Location = new System.Drawing.Point(143, 152);
            this.rbtnCut.Name = "rbtnCut";
            this.rbtnCut.Size = new System.Drawing.Size(47, 20);
            this.rbtnCut.TabIndex = 7;
            this.rbtnCut.TabStop = true;
            this.rbtnCut.Text = "Cut";
            this.rbtnCut.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRule
            // 
            this.btnDeleteRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRule.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDeleteRule.Location = new System.Drawing.Point(277, 14);
            this.btnDeleteRule.Name = "btnDeleteRule";
            this.btnDeleteRule.Size = new System.Drawing.Size(95, 28);
            this.btnDeleteRule.TabIndex = 4;
            this.btnDeleteRule.Text = "Delete Rule";
            this.btnDeleteRule.UseVisualStyleBackColor = false;
            this.btnDeleteRule.Click += new System.EventHandler(this.btnDeleteRule_Click);
            // 
            // btnSingleInference
            // 
            this.btnSingleInference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSingleInference.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSingleInference.Location = new System.Drawing.Point(196, 159);
            this.btnSingleInference.Name = "btnSingleInference";
            this.btnSingleInference.Size = new System.Drawing.Size(140, 35);
            this.btnSingleInference.TabIndex = 3;
            this.btnSingleInference.Text = "Single Inference";
            this.btnSingleInference.UseVisualStyleBackColor = false;
            this.btnSingleInference.Click += new System.EventHandler(this.btnSingleInference_Click);
            // 
            // btnAddRules
            // 
            this.btnAddRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddRules.ForeColor = System.Drawing.Color.Red;
            this.btnAddRules.Location = new System.Drawing.Point(378, 14);
            this.btnAddRules.Name = "btnAddRules";
            this.btnAddRules.Size = new System.Drawing.Size(95, 28);
            this.btnAddRules.TabIndex = 2;
            this.btnAddRules.Text = "Add Rule";
            this.btnAddRules.UseVisualStyleBackColor = false;
            this.btnAddRules.Click += new System.EventHandler(this.btnAddRules_Click);
            // 
            // labCondition
            // 
            this.labCondition.AutoSize = true;
            this.labCondition.ForeColor = System.Drawing.Color.Navy;
            this.labCondition.Location = new System.Drawing.Point(23, 176);
            this.labCondition.Name = "labCondition";
            this.labCondition.Size = new System.Drawing.Size(75, 18);
            this.labCondition.TabIndex = 6;
            this.labCondition.Text = "Condition";
            // 
            // labRules
            // 
            this.labRules.AutoSize = true;
            this.labRules.ForeColor = System.Drawing.Color.Navy;
            this.labRules.Location = new System.Drawing.Point(23, 24);
            this.labRules.Name = "labRules";
            this.labRules.Size = new System.Drawing.Size(45, 18);
            this.labRules.TabIndex = 5;
            this.labRules.Text = "Rules";
            // 
            // dgvCondition
            // 
            this.dgvCondition.AllowUserToAddRows = false;
            this.dgvCondition.AllowUserToDeleteRows = false;
            this.dgvCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCondition.Location = new System.Drawing.Point(23, 200);
            this.dgvCondition.Name = "dgvCondition";
            this.dgvCondition.RowTemplate.Height = 24;
            this.dgvCondition.RowTemplate.ReadOnly = true;
            this.dgvCondition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCondition.Size = new System.Drawing.Size(313, 71);
            this.dgvCondition.TabIndex = 1;
            this.dgvCondition.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCondition_CellClick);
            // 
            // dgvRules
            // 
            this.dgvRules.AllowUserToAddRows = false;
            this.dgvRules.AllowUserToDeleteRows = false;
            this.dgvRules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRules.Location = new System.Drawing.Point(23, 48);
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.RowTemplate.Height = 24;
            this.dgvRules.RowTemplate.ReadOnly = true;
            this.dgvRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRules.Size = new System.Drawing.Size(450, 100);
            this.dgvRules.TabIndex = 0;
            this.dgvRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRules_CellClick);
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
            this.splitContainer4.Panel1.Controls.Add(this.mainChart);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(742, 614);
            this.splitContainer4.SplitterDistance = 416;
            this.splitContainer4.TabIndex = 8;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.chartController1);
            this.splitContainer5.Panel1.Controls.Add(this.tChart1);
            this.splitContainer5.Panel1.Controls.Add(this.button2);
            this.splitContainer5.Size = new System.Drawing.Size(742, 194);
            this.splitContainer5.SplitterDistance = 508;
            this.splitContainer5.TabIndex = 0;
            // 
            // labCrisp
            // 
            this.labCrisp.AutoSize = true;
            this.labCrisp.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labCrisp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labCrisp.Location = new System.Drawing.Point(338, 217);
            this.labCrisp.Name = "labCrisp";
            this.labCrisp.Size = new System.Drawing.Size(66, 15);
            this.labCrisp.TabIndex = 12;
            this.labCrisp.Text = "Crisp Value";
            // 
            // txbCrisp
            // 
            this.txbCrisp.Location = new System.Drawing.Point(415, 212);
            this.txbCrisp.Name = "txbCrisp";
            this.txbCrisp.Size = new System.Drawing.Size(79, 25);
            this.txbCrisp.TabIndex = 7;
            this.txbCrisp.Text = "5.6, 4.8";
            // 
            // btnCrispAllInference
            // 
            this.btnCrispAllInference.Location = new System.Drawing.Point(374, 243);
            this.btnCrispAllInference.Name = "btnCrispAllInference";
            this.btnCrispAllInference.Size = new System.Drawing.Size(120, 28);
            this.btnCrispAllInference.TabIndex = 4;
            this.btnCrispAllInference.Text = "Crisp Infrernce";
            this.btnCrispAllInference.UseVisualStyleBackColor = true;
            this.btnCrispAllInference.Click += new System.EventHandler(this.btnCrispAllInference_Click);
            // 
            // rbtnMamdani
            // 
            this.rbtnMamdani.AutoSize = true;
            this.rbtnMamdani.Checked = true;
            this.rbtnMamdani.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnMamdani.Location = new System.Drawing.Point(18, 23);
            this.rbtnMamdani.Name = "rbtnMamdani";
            this.rbtnMamdani.Size = new System.Drawing.Size(82, 20);
            this.rbtnMamdani.TabIndex = 23;
            this.rbtnMamdani.TabStop = true;
            this.rbtnMamdani.Text = "Mamdani";
            this.rbtnMamdani.UseVisualStyleBackColor = true;
            this.rbtnMamdani.Click += new System.EventHandler(this.InferenceSystemChanged);
            // 
            // rbtnSugeno
            // 
            this.rbtnSugeno.AutoSize = true;
            this.rbtnSugeno.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnSugeno.Location = new System.Drawing.Point(106, 23);
            this.rbtnSugeno.Name = "rbtnSugeno";
            this.rbtnSugeno.Size = new System.Drawing.Size(72, 20);
            this.rbtnSugeno.TabIndex = 24;
            this.rbtnSugeno.Text = "Sugeno";
            this.rbtnSugeno.UseVisualStyleBackColor = true;
            this.rbtnSugeno.Click += new System.EventHandler(this.InferenceSystemChanged);
            // 
            // rbtnTsukamoto
            // 
            this.rbtnTsukamoto.AutoSize = true;
            this.rbtnTsukamoto.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rbtnTsukamoto.Location = new System.Drawing.Point(184, 23);
            this.rbtnTsukamoto.Name = "rbtnTsukamoto";
            this.rbtnTsukamoto.Size = new System.Drawing.Size(93, 20);
            this.rbtnTsukamoto.TabIndex = 25;
            this.rbtnTsukamoto.Text = "Tsukamoto";
            this.rbtnTsukamoto.UseVisualStyleBackColor = true;
            this.rbtnTsukamoto.Click += new System.EventHandler(this.InferenceSystemChanged);
            // 
            // pagSugeno
            // 
            this.pagSugeno.Controls.Add(this.button1);
            this.pagSugeno.Controls.Add(this.listBox1);
            this.pagSugeno.Location = new System.Drawing.Point(4, 26);
            this.pagSugeno.Name = "pagSugeno";
            this.pagSugeno.Size = new System.Drawing.Size(509, 294);
            this.pagSugeno.TabIndex = 2;
            this.pagSugeno.Text = "Output Equation";
            this.pagSugeno.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Items.AddRange(new object[] {
            "0: x *  ㄅ+ 6.4",
            "1: x + y"});
            this.listBox1.Location = new System.Drawing.Point(28, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(299, 225);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 128);
            this.button2.TabIndex = 0;
            this.button2.Text = "Crisp Inferencing All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tChart1
            // 
            this.tChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tChart1.Aspect.Chart3DPercent = 100;
            this.tChart1.Aspect.Orthogonal = false;
            this.tChart1.Aspect.Perspective = 42;
            this.tChart1.Aspect.View3D = true;
            this.tChart1.Aspect.Zoom = 70;
            this.tChart1.Aspect.ZoomFloat = 70D;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChart1.Axes.Bottom.Labels.Brush.Solid = true;
            this.tChart1.Axes.Bottom.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Axes.Bottom.Labels.Font.Brush.Solid = true;
            this.tChart1.Axes.Bottom.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Bottom.Labels.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Bottom.Labels.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.Bottom.Labels.Font.Size = 9;
            this.tChart1.Axes.Bottom.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.Bottom.Labels.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.Bottom.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Bottom.Labels.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Bottom.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Angle = 0;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChart1.Axes.Bottom.Title.Brush.Solid = true;
            this.tChart1.Axes.Bottom.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Axes.Bottom.Title.Font.Brush.Solid = true;
            this.tChart1.Axes.Bottom.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.Bottom.Title.Font.Size = 11;
            this.tChart1.Axes.Bottom.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.Bottom.Title.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.Bottom.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Bottom.Title.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Bottom.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChart1.Axes.Depth.Labels.Brush.Solid = true;
            this.tChart1.Axes.Depth.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Axes.Depth.Labels.Font.Brush.Solid = true;
            this.tChart1.Axes.Depth.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Depth.Labels.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Depth.Labels.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.Depth.Labels.Font.Size = 9;
            this.tChart1.Axes.Depth.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.Depth.Labels.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.Depth.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Depth.Labels.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Depth.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Angle = 0;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChart1.Axes.Depth.Title.Brush.Solid = true;
            this.tChart1.Axes.Depth.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Axes.Depth.Title.Font.Brush.Solid = true;
            this.tChart1.Axes.Depth.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Depth.Title.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Depth.Title.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.Depth.Title.Font.Size = 11;
            this.tChart1.Axes.Depth.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.Depth.Title.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.Depth.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Depth.Title.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Depth.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChart1.Axes.DepthTop.Labels.Brush.Solid = true;
            this.tChart1.Axes.DepthTop.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Axes.DepthTop.Labels.Font.Brush.Solid = true;
            this.tChart1.Axes.DepthTop.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.DepthTop.Labels.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.DepthTop.Labels.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.DepthTop.Labels.Font.Size = 9;
            this.tChart1.Axes.DepthTop.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.DepthTop.Labels.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.DepthTop.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.DepthTop.Labels.Shadow.Brush.Solid = true;
            this.tChart1.Axes.DepthTop.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Angle = 0;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChart1.Axes.DepthTop.Title.Brush.Solid = true;
            this.tChart1.Axes.DepthTop.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Axes.DepthTop.Title.Font.Brush.Solid = true;
            this.tChart1.Axes.DepthTop.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.DepthTop.Title.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.DepthTop.Title.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.DepthTop.Title.Font.Size = 11;
            this.tChart1.Axes.DepthTop.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.DepthTop.Title.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.DepthTop.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.DepthTop.Title.Shadow.Brush.Solid = true;
            this.tChart1.Axes.DepthTop.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChart1.Axes.Left.Labels.Brush.Solid = true;
            this.tChart1.Axes.Left.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Axes.Left.Labels.Font.Brush.Solid = true;
            this.tChart1.Axes.Left.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Left.Labels.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Left.Labels.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.Left.Labels.Font.Size = 9;
            this.tChart1.Axes.Left.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.Left.Labels.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.Left.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Left.Labels.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Left.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Angle = 90;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChart1.Axes.Left.Title.Brush.Solid = true;
            this.tChart1.Axes.Left.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Axes.Left.Title.Font.Brush.Solid = true;
            this.tChart1.Axes.Left.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Left.Title.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Left.Title.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.Left.Title.Font.Size = 11;
            this.tChart1.Axes.Left.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.Left.Title.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.Left.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Left.Title.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Left.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChart1.Axes.Right.Labels.Brush.Solid = true;
            this.tChart1.Axes.Right.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Axes.Right.Labels.Font.Brush.Solid = true;
            this.tChart1.Axes.Right.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Right.Labels.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Right.Labels.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.Right.Labels.Font.Size = 9;
            this.tChart1.Axes.Right.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.Right.Labels.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.Right.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Right.Labels.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Right.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Angle = 270;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChart1.Axes.Right.Title.Brush.Solid = true;
            this.tChart1.Axes.Right.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Axes.Right.Title.Font.Brush.Solid = true;
            this.tChart1.Axes.Right.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Right.Title.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Right.Title.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.Right.Title.Font.Size = 11;
            this.tChart1.Axes.Right.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.Right.Title.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.Right.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Right.Title.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Right.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Brush.Color = System.Drawing.Color.White;
            this.tChart1.Axes.Top.Labels.Brush.Solid = true;
            this.tChart1.Axes.Top.Labels.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Axes.Top.Labels.Font.Brush.Solid = true;
            this.tChart1.Axes.Top.Labels.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Top.Labels.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Top.Labels.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.Top.Labels.Font.Size = 9;
            this.tChart1.Axes.Top.Labels.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.Top.Labels.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.Top.Labels.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Top.Labels.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Top.Labels.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Angle = 0;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Brush.Color = System.Drawing.Color.Silver;
            this.tChart1.Axes.Top.Title.Brush.Solid = true;
            this.tChart1.Axes.Top.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Axes.Top.Title.Font.Brush.Solid = true;
            this.tChart1.Axes.Top.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Top.Title.Font.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Top.Title.Font.Shadow.Brush.Visible = true;
            this.tChart1.Axes.Top.Title.Font.Size = 11;
            this.tChart1.Axes.Top.Title.Font.SizeFloat = 11F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Axes.Top.Title.ImageBevel.Brush.Solid = true;
            this.tChart1.Axes.Top.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Axes.Top.Title.Shadow.Brush.Solid = true;
            this.tChart1.Axes.Top.Title.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Footer.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Footer.Brush.Color = System.Drawing.Color.Silver;
            this.tChart1.Footer.Brush.Solid = true;
            this.tChart1.Footer.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Footer.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Footer.Font.Brush.Color = System.Drawing.Color.Red;
            this.tChart1.Footer.Font.Brush.Solid = true;
            this.tChart1.Footer.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Footer.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Footer.Font.Shadow.Brush.Solid = true;
            this.tChart1.Footer.Font.Shadow.Brush.Visible = true;
            this.tChart1.Footer.Font.Size = 8;
            this.tChart1.Footer.Font.SizeFloat = 8F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Footer.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Footer.ImageBevel.Brush.Solid = true;
            this.tChart1.Footer.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Footer.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Footer.Shadow.Brush.Solid = true;
            this.tChart1.Footer.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Header.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Header.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tChart1.Header.Brush.Solid = true;
            this.tChart1.Header.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Header.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Header.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.Header.Font.Brush.Solid = true;
            this.tChart1.Header.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Header.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Header.Font.Shadow.Brush.Solid = true;
            this.tChart1.Header.Font.Shadow.Brush.Visible = true;
            this.tChart1.Header.Font.Size = 12;
            this.tChart1.Header.Font.SizeFloat = 12F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Header.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Header.ImageBevel.Brush.Solid = true;
            this.tChart1.Header.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Header.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tChart1.Header.Shadow.Brush.Solid = true;
            this.tChart1.Header.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Legend.Brush.Color = System.Drawing.Color.White;
            this.tChart1.Legend.Brush.Solid = true;
            this.tChart1.Legend.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Legend.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.Legend.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tChart1.Legend.Font.Brush.Solid = true;
            this.tChart1.Legend.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Legend.Font.Shadow.Brush.Solid = true;
            this.tChart1.Legend.Font.Shadow.Brush.Visible = true;
            this.tChart1.Legend.Font.Size = 9;
            this.tChart1.Legend.Font.SizeFloat = 9F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Legend.ImageBevel.Brush.Solid = true;
            this.tChart1.Legend.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tChart1.Legend.Shadow.Brush.Solid = true;
            this.tChart1.Legend.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Legend.Symbol.Shadow.Brush.Solid = true;
            this.tChart1.Legend.Symbol.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Title.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Brush.Color = System.Drawing.Color.White;
            this.tChart1.Legend.Title.Brush.Solid = true;
            this.tChart1.Legend.Title.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Brush.Color = System.Drawing.Color.Black;
            this.tChart1.Legend.Title.Font.Brush.Solid = true;
            this.tChart1.Legend.Title.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Legend.Title.Font.Shadow.Brush.Solid = true;
            this.tChart1.Legend.Title.Font.Shadow.Brush.Visible = true;
            this.tChart1.Legend.Title.Font.Size = 8;
            this.tChart1.Legend.Title.Font.SizeFloat = 8F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Title.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Legend.Title.ImageBevel.Brush.Solid = true;
            this.tChart1.Legend.Title.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Title.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Legend.Title.Shadow.Brush.Solid = true;
            this.tChart1.Legend.Title.Shadow.Brush.Visible = true;
            this.tChart1.Location = new System.Drawing.Point(69, 29);
            this.tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Panel.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart1.Panel.Brush.Solid = true;
            this.tChart1.Panel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Panel.ImageBevel.Brush.Solid = true;
            this.tChart1.Panel.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Panel.Shadow.Brush.Solid = true;
            this.tChart1.Panel.Shadow.Brush.Visible = true;
            this.tChart1.Series.Add(this.surface1);
            this.tChart1.Size = new System.Drawing.Size(379, 135);
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubFooter.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.SubFooter.Brush.Color = System.Drawing.Color.Silver;
            this.tChart1.SubFooter.Brush.Solid = true;
            this.tChart1.SubFooter.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.SubFooter.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.SubFooter.Font.Brush.Color = System.Drawing.Color.Red;
            this.tChart1.SubFooter.Font.Brush.Solid = true;
            this.tChart1.SubFooter.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubFooter.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.SubFooter.Font.Shadow.Brush.Solid = true;
            this.tChart1.SubFooter.Font.Shadow.Brush.Visible = true;
            this.tChart1.SubFooter.Font.Size = 8;
            this.tChart1.SubFooter.Font.SizeFloat = 8F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubFooter.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.SubFooter.ImageBevel.Brush.Solid = true;
            this.tChart1.SubFooter.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubFooter.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.SubFooter.Shadow.Brush.Solid = true;
            this.tChart1.SubFooter.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubHeader.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.SubHeader.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tChart1.SubHeader.Brush.Solid = true;
            this.tChart1.SubHeader.Brush.Visible = true;
            // 
            // 
            // 
            this.tChart1.SubHeader.Font.Bold = false;
            // 
            // 
            // 
            this.tChart1.SubHeader.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart1.SubHeader.Font.Brush.Solid = true;
            this.tChart1.SubHeader.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubHeader.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.SubHeader.Font.Shadow.Brush.Solid = true;
            this.tChart1.SubHeader.Font.Shadow.Brush.Visible = true;
            this.tChart1.SubHeader.Font.Size = 12;
            this.tChart1.SubHeader.Font.SizeFloat = 12F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubHeader.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.SubHeader.ImageBevel.Brush.Solid = true;
            this.tChart1.SubHeader.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubHeader.Shadow.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tChart1.SubHeader.Shadow.Brush.Solid = true;
            this.tChart1.SubHeader.Shadow.Brush.Visible = true;
            this.tChart1.TabIndex = 1;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Back.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Walls.Back.Brush.Color = System.Drawing.Color.Silver;
            this.tChart1.Walls.Back.Brush.Solid = true;
            this.tChart1.Walls.Back.Brush.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Back.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Walls.Back.ImageBevel.Brush.Solid = true;
            this.tChart1.Walls.Back.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Back.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Walls.Back.Shadow.Brush.Solid = true;
            this.tChart1.Walls.Back.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.Brush.Color = System.Drawing.Color.White;
            this.tChart1.Walls.Bottom.Brush.Solid = true;
            this.tChart1.Walls.Bottom.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Walls.Bottom.ImageBevel.Brush.Solid = true;
            this.tChart1.Walls.Bottom.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Walls.Bottom.Shadow.Brush.Solid = true;
            this.tChart1.Walls.Bottom.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Left.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Walls.Left.Brush.Color = System.Drawing.Color.LightYellow;
            this.tChart1.Walls.Left.Brush.Solid = true;
            this.tChart1.Walls.Left.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Left.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Walls.Left.ImageBevel.Brush.Solid = true;
            this.tChart1.Walls.Left.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Left.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Walls.Left.Shadow.Brush.Solid = true;
            this.tChart1.Walls.Left.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Right.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Walls.Right.Brush.Color = System.Drawing.Color.LightYellow;
            this.tChart1.Walls.Right.Brush.Solid = true;
            this.tChart1.Walls.Right.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Right.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.tChart1.Walls.Right.ImageBevel.Brush.Solid = true;
            this.tChart1.Walls.Right.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Right.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.tChart1.Walls.Right.Shadow.Brush.Solid = true;
            this.tChart1.Walls.Right.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Zoom.Brush.Color = System.Drawing.Color.LightBlue;
            this.tChart1.Zoom.Brush.Solid = true;
            this.tChart1.Zoom.Brush.Visible = true;
            // 
            // chartController1
            // 
            this.chartController1.ButtonSize = Steema.TeeChart.ControllerButtonSize.x16;
            this.chartController1.Chart = this.tChart1;
            this.chartController1.LabelValues = true;
            this.chartController1.Location = new System.Drawing.Point(0, 0);
            this.chartController1.Name = "chartController1";
            this.chartController1.Size = new System.Drawing.Size(508, 25);
            this.chartController1.TabIndex = 2;
            this.chartController1.Text = "chartController1";
            // 
            // surface1
            // 
            // 
            // 
            // 
            this.surface1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(153)))), ((int)(((byte)(214)))));
            this.surface1.Brush.Solid = true;
            this.surface1.Brush.Visible = true;
            this.surface1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(153)))), ((int)(((byte)(214)))));
            this.surface1.ColorEach = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Legend.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.surface1.Legend.Brush.Color = System.Drawing.Color.White;
            this.surface1.Legend.Brush.Solid = true;
            this.surface1.Legend.Brush.Visible = true;
            // 
            // 
            // 
            this.surface1.Legend.Font.Bold = false;
            // 
            // 
            // 
            this.surface1.Legend.Font.Brush.Color = System.Drawing.Color.Black;
            this.surface1.Legend.Font.Brush.Solid = true;
            this.surface1.Legend.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Legend.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.surface1.Legend.Font.Shadow.Brush.Solid = true;
            this.surface1.Legend.Font.Shadow.Brush.Visible = true;
            this.surface1.Legend.Font.Size = 8;
            this.surface1.Legend.Font.SizeFloat = 8F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Legend.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.surface1.Legend.ImageBevel.Brush.Solid = true;
            this.surface1.Legend.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Legend.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.surface1.Legend.Shadow.Brush.Solid = true;
            this.surface1.Legend.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Marks.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.surface1.Marks.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.surface1.Marks.Brush.Solid = true;
            this.surface1.Marks.Brush.Visible = true;
            // 
            // 
            // 
            this.surface1.Marks.Font.Bold = false;
            // 
            // 
            // 
            this.surface1.Marks.Font.Brush.Color = System.Drawing.Color.Black;
            this.surface1.Marks.Font.Brush.Solid = true;
            this.surface1.Marks.Font.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Marks.Font.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.surface1.Marks.Font.Shadow.Brush.Solid = true;
            this.surface1.Marks.Font.Shadow.Brush.Visible = true;
            this.surface1.Marks.Font.Size = 8;
            this.surface1.Marks.Font.SizeFloat = 8F;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Marks.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.surface1.Marks.ImageBevel.Brush.Solid = true;
            this.surface1.Marks.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Marks.Shadow.Brush.Color = System.Drawing.Color.Gray;
            this.surface1.Marks.Shadow.Brush.Solid = true;
            this.surface1.Marks.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Marks.Symbol.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.surface1.Marks.Symbol.Brush.Color = System.Drawing.Color.White;
            this.surface1.Marks.Symbol.Brush.Solid = true;
            this.surface1.Marks.Symbol.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Marks.Symbol.ImageBevel.Brush.Color = System.Drawing.Color.LightGray;
            this.surface1.Marks.Symbol.ImageBevel.Brush.Solid = true;
            this.surface1.Marks.Symbol.ImageBevel.Brush.Visible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.surface1.Marks.Symbol.Shadow.Brush.Color = System.Drawing.Color.DarkGray;
            this.surface1.Marks.Symbol.Shadow.Brush.Solid = true;
            this.surface1.Marks.Symbol.Shadow.Brush.Visible = true;
            // 
            // 
            // 
            this.surface1.Marks.TailParams.Align = Steema.TeeChart.Styles.TailAlignment.Auto;
            this.surface1.Marks.TailParams.CustomPointPos = ((System.Drawing.PointF)(resources.GetObject("resource.CustomPointPos")));
            this.surface1.Marks.TailParams.Margin = 0F;
            this.surface1.Marks.TailParams.PointerHeight = 8D;
            this.surface1.Marks.TailParams.PointerWidth = 8D;
            this.surface1.OriginalCursor = null;
            this.surface1.PaletteMin = 0D;
            this.surface1.PaletteStep = 0D;
            this.surface1.PaletteStyle = Steema.TeeChart.Styles.PaletteStyles.Pale;
            // 
            // 
            // 
            this.surface1.SideBrush.Color = System.Drawing.Color.Black;
            this.surface1.SideBrush.Solid = true;
            this.surface1.SideBrush.Visible = false;
            this.surface1.Title = "surface1";
            this.surface1.UseExtendedNumRange = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 685);
            this.Controls.Add(this.rbtnTsukamoto);
            this.Controls.Add(this.rbtnSugeno);
            this.Controls.Add(this.rbtnMamdani);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fuzzy Inference System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.gpxUnaryOperatedFS.ResumeLayout(false);
            this.gpxUnaryOperatedFS.PerformLayout();
            this.gpxBinaryOperatedFS.ResumeLayout(false);
            this.gpxBinaryOperatedFS.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tbcFS_Rules.ResumeLayout(false);
            this.tbpFS.ResumeLayout(false);
            this.gpxPrimaryFuzzySet.ResumeLayout(false);
            this.gpxPrimaryFuzzySet.PerformLayout();
            this.tbpIfThenRules.ResumeLayout(false);
            this.tbpIfThenRules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.pagSugeno.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateUniverse;
        private System.Windows.Forms.TreeView trvUniverses;
        private System.Windows.Forms.PropertyGrid ppgTarget;
        private System.Windows.Forms.ComboBox cbxFSTypes;
        private System.Windows.Forms.Button btnCreateFuzzySet;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbxUnaryOperators;
        private System.Windows.Forms.Button btnCreateUnaryOperatedFS;
        private System.Windows.Forms.ComboBox cbxBinaryOperators;
        private System.Windows.Forms.Button btnCreateBinaryOperatedFS;
        private System.Windows.Forms.Label labOperand1;
        private System.Windows.Forms.Label labOperand2;
        private System.Windows.Forms.GroupBox gpxUnaryOperatedFS;
        private System.Windows.Forms.GroupBox gpxBinaryOperatedFS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tbcFS_Rules;
        private System.Windows.Forms.TabPage tbpFS;
        private System.Windows.Forms.TabPage tbpIfThenRules;
        private System.Windows.Forms.DataGridView dgvCondition;
        private System.Windows.Forms.DataGridView dgvRules;
        private System.Windows.Forms.Button btnAddRules;
        private System.Windows.Forms.Button btnCrispAllInference;
        private System.Windows.Forms.Button btnSingleInference;
        private System.Windows.Forms.TextBox txbCrisp;
        private System.Windows.Forms.Label labUnaryOperators;
        private System.Windows.Forms.Label labBinaryOperators;
        private System.Windows.Forms.GroupBox gpxPrimaryFuzzySet;
        private System.Windows.Forms.Label labFSType;
        private System.Windows.Forms.Button btnDeleteRule;
        private System.Windows.Forms.TextBox txbTitle;
        private System.Windows.Forms.RadioButton rbtnMamdani;
        private System.Windows.Forms.RadioButton rbtnSugeno;
        private System.Windows.Forms.RadioButton rbtnTsukamoto;
        private System.Windows.Forms.Button btnDeleteOperands;
        private System.Windows.Forms.Label labOperands;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Label labCrisp;
        private System.Windows.Forms.Label labCondition;
        private System.Windows.Forms.Label labRules;
        private System.Windows.Forms.RadioButton rbtnScale;
        private System.Windows.Forms.RadioButton rbtnCut;
        private System.Windows.Forms.TabPage pagSugeno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private Steema.TeeChart.TChart tChart1;
        private Steema.TeeChart.ChartController chartController1;
        private Steema.TeeChart.Styles.Surface surface1;
    }
}

