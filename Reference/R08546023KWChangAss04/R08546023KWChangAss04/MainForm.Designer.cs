namespace R08546023KWChangAss05
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.btnCreateUniverse = new System.Windows.Forms.Button();
            this.trvUniverses = new System.Windows.Forms.TreeView();
            this.ppgTarget = new System.Windows.Forms.PropertyGrid();
            this.cbxFSTypes = new System.Windows.Forms.ComboBox();
            this.btnCreateFuzzySet = new System.Windows.Forms.Button();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbxUnaryOperator = new System.Windows.Forms.ComboBox();
            this.btnUnaryOperatedFS = new System.Windows.Forms.Button();
            this.labOperand1 = new System.Windows.Forms.Label();
            this.labOperand2 = new System.Windows.Forms.Label();
            this.cbxBinaryOperator = new System.Windows.Forms.ComboBox();
            this.btnBinaryOperatedFS = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvRules = new System.Windows.Forms.DataGridView();
            this.dgvCondition = new System.Windows.Forms.DataGridView();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.btnSingleInference = new System.Windows.Forms.Button();
            this.btnCrispAllInference = new System.Windows.Forms.Button();
            this.txbCrisp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondition)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateUniverse
            // 
            this.btnCreateUniverse.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateUniverse.Location = new System.Drawing.Point(65, 39);
            this.btnCreateUniverse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateUniverse.Name = "btnCreateUniverse";
            this.btnCreateUniverse.Size = new System.Drawing.Size(232, 31);
            this.btnCreateUniverse.TabIndex = 0;
            this.btnCreateUniverse.Text = "New Universe";
            this.btnCreateUniverse.UseVisualStyleBackColor = true;
            this.btnCreateUniverse.Click += new System.EventHandler(this.btnCreateUniverse_Click);
            // 
            // trvUniverses
            // 
            this.trvUniverses.HideSelection = false;
            this.trvUniverses.Location = new System.Drawing.Point(65, 119);
            this.trvUniverses.Name = "trvUniverses";
            this.trvUniverses.Size = new System.Drawing.Size(212, 162);
            this.trvUniverses.TabIndex = 1;
            this.trvUniverses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvUniverses_AfterSelect);
            // 
            // ppgTarget
            // 
            this.ppgTarget.Location = new System.Drawing.Point(370, 176);
            this.ppgTarget.Name = "ppgTarget";
            this.ppgTarget.Size = new System.Drawing.Size(216, 184);
            this.ppgTarget.TabIndex = 2;
            this.ppgTarget.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ppgTarget_PropertyValueChanged);
            // 
            // cbxFSTypes
            // 
            this.cbxFSTypes.FormattingEnabled = true;
            this.cbxFSTypes.Items.AddRange(new object[] {
            "Gaussian Fuzzy Set",
            "Triangular Fuzzy Set",
            "Trapezoidal Fuzzy Set",
            "Bell Fuzzy Set",
            "Sigmoidal Fuzzy Set",
            "Left-right Fuzzy Set",
            "Pi-shaped Fuzzy Set",
            "S-shaped Fuzzy Set",
            "Z-shaped Fuzzy Set"});
            this.cbxFSTypes.Location = new System.Drawing.Point(370, 78);
            this.cbxFSTypes.Name = "cbxFSTypes";
            this.cbxFSTypes.Size = new System.Drawing.Size(216, 24);
            this.cbxFSTypes.TabIndex = 3;
            // 
            // btnCreateFuzzySet
            // 
            this.btnCreateFuzzySet.BackColor = System.Drawing.Color.Wheat;
            this.btnCreateFuzzySet.Enabled = false;
            this.btnCreateFuzzySet.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateFuzzySet.Location = new System.Drawing.Point(370, 117);
            this.btnCreateFuzzySet.Name = "btnCreateFuzzySet";
            this.btnCreateFuzzySet.Size = new System.Drawing.Size(216, 31);
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
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(569, 406);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(332, 289);
            this.mainChart.TabIndex = 5;
            this.mainChart.Text = "chart1";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Location = new System.Drawing.Point(65, 78);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(232, 31);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbxUnaryOperator
            // 
            this.cbxUnaryOperator.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbxUnaryOperator.FormattingEnabled = true;
            this.cbxUnaryOperator.Items.AddRange(new object[] {
            "Negate Operator",
            "Alpha-cut Operator",
            "Value-scale Operator",
            "Concentration Operator",
            "Dilation Operator",
            "Intensification Operator",
            "Diminisher Operator",
            "Extreme Operator",
            "Sugeno-complement Operator",
            "Yager-complement Operator"});
            this.cbxUnaryOperator.Location = new System.Drawing.Point(13, 39);
            this.cbxUnaryOperator.Name = "cbxUnaryOperator";
            this.cbxUnaryOperator.Size = new System.Drawing.Size(216, 24);
            this.cbxUnaryOperator.TabIndex = 8;
            // 
            // btnUnaryOperatedFS
            // 
            this.btnUnaryOperatedFS.BackColor = System.Drawing.Color.Salmon;
            this.btnUnaryOperatedFS.Enabled = false;
            this.btnUnaryOperatedFS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnUnaryOperatedFS.Location = new System.Drawing.Point(13, 80);
            this.btnUnaryOperatedFS.Name = "btnUnaryOperatedFS";
            this.btnUnaryOperatedFS.Size = new System.Drawing.Size(216, 31);
            this.btnUnaryOperatedFS.TabIndex = 9;
            this.btnUnaryOperatedFS.Text = "Generate Unary Operated FS";
            this.btnUnaryOperatedFS.UseVisualStyleBackColor = false;
            this.btnUnaryOperatedFS.Click += new System.EventHandler(this.btnUnaryOperatedFS_Click);
            // 
            // labOperand1
            // 
            this.labOperand1.AutoSize = true;
            this.labOperand1.BackColor = System.Drawing.Color.LightBlue;
            this.labOperand1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labOperand1.Location = new System.Drawing.Point(20, 112);
            this.labOperand1.Name = "labOperand1";
            this.labOperand1.Size = new System.Drawing.Size(204, 20);
            this.labOperand1.TabIndex = 12;
            this.labOperand1.Text = "Click to specify Operand 1";
            this.labOperand1.TextChanged += new System.EventHandler(this.labOperand1_TextChanged);
            this.labOperand1.Click += new System.EventHandler(this.labOperand1_Click);
            // 
            // labOperand2
            // 
            this.labOperand2.AutoSize = true;
            this.labOperand2.BackColor = System.Drawing.Color.Thistle;
            this.labOperand2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labOperand2.Location = new System.Drawing.Point(643, 323);
            this.labOperand2.Name = "labOperand2";
            this.labOperand2.Size = new System.Drawing.Size(204, 20);
            this.labOperand2.TabIndex = 13;
            this.labOperand2.Text = "Click to specify Operand 2";
            this.labOperand2.TextChanged += new System.EventHandler(this.labOperand2_TextChanged);
            this.labOperand2.Click += new System.EventHandler(this.labOperand2_Click);
            // 
            // cbxBinaryOperator
            // 
            this.cbxBinaryOperator.FormattingEnabled = true;
            this.cbxBinaryOperator.Items.AddRange(new object[] {
            "Minimum T-norm Operator",
            "Maximum S-norm Operator",
            "Algebriac Product T-norm Operator",
            "Algebriac Sum S-norm Operator",
            "Bounded Product T-norm Operator",
            "Bounded Sum S-norm Operator",
            "Drastic Product T-norm Operator",
            "Drastic Sum S-norm Operator",
            "Sugeno T-norm Operator",
            "Sugeno S-norm Operator",
            "Einstein Product T-norm Operator",
            "Einstein Sum S-norm Operator",
            "Hamacher Product T-norm Operator",
            "Hamacher Sum S-norm Operator",
            "Yager Product T-norm Operator",
            "Yager Sum S-norm Operator"});
            this.cbxBinaryOperator.Location = new System.Drawing.Point(637, 216);
            this.cbxBinaryOperator.Name = "cbxBinaryOperator";
            this.cbxBinaryOperator.Size = new System.Drawing.Size(216, 24);
            this.cbxBinaryOperator.TabIndex = 14;
            // 
            // btnBinaryOperatedFS
            // 
            this.btnBinaryOperatedFS.BackColor = System.Drawing.Color.Pink;
            this.btnBinaryOperatedFS.Enabled = false;
            this.btnBinaryOperatedFS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnBinaryOperatedFS.Location = new System.Drawing.Point(637, 250);
            this.btnBinaryOperatedFS.Name = "btnBinaryOperatedFS";
            this.btnBinaryOperatedFS.Size = new System.Drawing.Size(216, 31);
            this.btnBinaryOperatedFS.TabIndex = 15;
            this.btnBinaryOperatedFS.Text = "Generate Binary Operated FS";
            this.btnBinaryOperatedFS.UseVisualStyleBackColor = false;
            this.btnBinaryOperatedFS.Click += new System.EventHandler(this.btnBinaryOperatedFS_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(355, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 125);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Fuzzy Set";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUnaryOperatedFS);
            this.groupBox2.Controls.Add(this.cbxUnaryOperator);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(624, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 125);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Unary Operator";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labOperand1);
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(624, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 179);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Binary Operator";
            // 
            // dgvRules
            // 
            this.dgvRules.AllowUserToAddRows = false;
            this.dgvRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRules.Location = new System.Drawing.Point(34, 406);
            this.dgvRules.Name = "dgvRules";
            this.dgvRules.RowTemplate.Height = 24;
            this.dgvRules.Size = new System.Drawing.Size(437, 87);
            this.dgvRules.TabIndex = 20;
            this.dgvRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRules_CellClick);
            // 
            // dgvCondition
            // 
            this.dgvCondition.AllowUserToAddRows = false;
            this.dgvCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCondition.Location = new System.Drawing.Point(34, 523);
            this.dgvCondition.Name = "dgvCondition";
            this.dgvCondition.RowTemplate.Height = 24;
            this.dgvCondition.Size = new System.Drawing.Size(437, 74);
            this.dgvCondition.TabIndex = 21;
            this.dgvCondition.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCondition_CellClick);
            // 
            // btnAddRule
            // 
            this.btnAddRule.Location = new System.Drawing.Point(396, 377);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(75, 23);
            this.btnAddRule.TabIndex = 22;
            this.btnAddRule.Text = "Add Rule";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // btnSingleInference
            // 
            this.btnSingleInference.Location = new System.Drawing.Point(385, 499);
            this.btnSingleInference.Name = "btnSingleInference";
            this.btnSingleInference.Size = new System.Drawing.Size(117, 23);
            this.btnSingleInference.TabIndex = 23;
            this.btnSingleInference.Text = "Single Inference";
            this.btnSingleInference.UseVisualStyleBackColor = true;
            this.btnSingleInference.Click += new System.EventHandler(this.btnSingleInference_Click);
            // 
            // btnCrispAllInference
            // 
            this.btnCrispAllInference.Location = new System.Drawing.Point(498, 377);
            this.btnCrispAllInference.Name = "btnCrispAllInference";
            this.btnCrispAllInference.Size = new System.Drawing.Size(88, 86);
            this.btnCrispAllInference.TabIndex = 24;
            this.btnCrispAllInference.Text = "Crisp Inference";
            this.btnCrispAllInference.UseVisualStyleBackColor = true;
            this.btnCrispAllInference.Click += new System.EventHandler(this.btnCrispAllInference_Click);
            // 
            // txbCrisp
            // 
            this.txbCrisp.Location = new System.Drawing.Point(498, 471);
            this.txbCrisp.Name = "txbCrisp";
            this.txbCrisp.Size = new System.Drawing.Size(88, 23);
            this.txbCrisp.TabIndex = 25;
            this.txbCrisp.Text = "5.6, 4.8";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 728);
            this.Controls.Add(this.txbCrisp);
            this.Controls.Add(this.btnCrispAllInference);
            this.Controls.Add(this.btnSingleInference);
            this.Controls.Add(this.btnAddRule);
            this.Controls.Add(this.dgvCondition);
            this.Controls.Add(this.dgvRules);
            this.Controls.Add(this.btnBinaryOperatedFS);
            this.Controls.Add(this.cbxBinaryOperator);
            this.Controls.Add(this.labOperand2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.btnCreateFuzzySet);
            this.Controls.Add(this.cbxFSTypes);
            this.Controls.Add(this.ppgTarget);
            this.Controls.Add(this.trvUniverses);
            this.Controls.Add(this.btnCreateUniverse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondition)).EndInit();
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
        private System.Windows.Forms.ComboBox cbxUnaryOperator;
        private System.Windows.Forms.Button btnUnaryOperatedFS;
        private System.Windows.Forms.Label labOperand1;
        private System.Windows.Forms.Label labOperand2;
        private System.Windows.Forms.ComboBox cbxBinaryOperator;
        private System.Windows.Forms.Button btnBinaryOperatedFS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvRules;
        private System.Windows.Forms.DataGridView dgvCondition;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.Button btnSingleInference;
        private System.Windows.Forms.Button btnCrispAllInference;
        private System.Windows.Forms.TextBox txbCrisp;
    }
}

