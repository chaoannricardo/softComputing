namespace R08546019YTKanAss04
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
            this.labOperand1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxUnaryOperators = new System.Windows.Forms.ComboBox();
            this.btnUnaryOperatedFS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.labOperand1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateUniverse
            // 
            this.btnCreateUniverse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCreateUniverse.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateUniverse.Location = new System.Drawing.Point(41, 13);
            this.btnCreateUniverse.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateUniverse.Name = "btnCreateUniverse";
            this.btnCreateUniverse.Size = new System.Drawing.Size(185, 40);
            this.btnCreateUniverse.TabIndex = 0;
            this.btnCreateUniverse.Text = "New Universe";
            this.btnCreateUniverse.UseVisualStyleBackColor = false;
            this.btnCreateUniverse.Click += new System.EventHandler(this.btnCreateUniverse_Click);
            // 
            // trvUniverses
            // 
            this.trvUniverses.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.trvUniverses.HideSelection = false;
            this.trvUniverses.Location = new System.Drawing.Point(41, 59);
            this.trvUniverses.Name = "trvUniverses";
            this.trvUniverses.Size = new System.Drawing.Size(295, 225);
            this.trvUniverses.TabIndex = 1;
            this.trvUniverses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvUniverses_AfterSelect);
            // 
            // ppgTarget
            // 
            this.ppgTarget.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ppgTarget.Location = new System.Drawing.Point(352, 87);
            this.ppgTarget.Name = "ppgTarget";
            this.ppgTarget.Size = new System.Drawing.Size(300, 196);
            this.ppgTarget.TabIndex = 2;
            this.ppgTarget.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ppgTarget_PropertyValueChanged);
            // 
            // cbxFSTypes
            // 
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
            this.cbxFSTypes.Location = new System.Drawing.Point(352, 12);
            this.cbxFSTypes.Name = "cbxFSTypes";
            this.cbxFSTypes.Size = new System.Drawing.Size(297, 25);
            this.cbxFSTypes.TabIndex = 3;
            // 
            // btnCreateFuzzySet
            // 
            this.btnCreateFuzzySet.BackColor = System.Drawing.Color.SkyBlue;
            this.btnCreateFuzzySet.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCreateFuzzySet.Location = new System.Drawing.Point(352, 45);
            this.btnCreateFuzzySet.Name = "btnCreateFuzzySet";
            this.btnCreateFuzzySet.Size = new System.Drawing.Size(200, 40);
            this.btnCreateFuzzySet.TabIndex = 4;
            this.btnCreateFuzzySet.Text = "New Fuzzy Set";
            this.btnCreateFuzzySet.UseVisualStyleBackColor = false;
            this.btnCreateFuzzySet.Click += new System.EventHandler(this.btnCreateFuzzySet_Click);
            // 
            // labOperand1
            // 
            this.labOperand1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            legend1.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.labOperand1.Legends.Add(legend1);
            this.labOperand1.Location = new System.Drawing.Point(12, 309);
            this.labOperand1.Name = "labOperand1";
            this.labOperand1.Size = new System.Drawing.Size(906, 228);
            this.labOperand1.TabIndex = 5;
            this.labOperand1.Text = "chart1";
            this.labOperand1.Click += new System.EventHandler(this.labOperand1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDelete.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Location = new System.Drawing.Point(241, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 40);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(562, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxUnaryOperators
            // 
            this.cbxUnaryOperators.FormattingEnabled = true;
            this.cbxUnaryOperators.Items.AddRange(new object[] {
            "Negate",
            "Alpha Cut"});
            this.cbxUnaryOperators.Location = new System.Drawing.Point(681, 59);
            this.cbxUnaryOperators.Name = "cbxUnaryOperators";
            this.cbxUnaryOperators.Size = new System.Drawing.Size(220, 24);
            this.cbxUnaryOperators.TabIndex = 8;
            // 
            // btnUnaryOperatedFS
            // 
            this.btnUnaryOperatedFS.Location = new System.Drawing.Point(681, 87);
            this.btnUnaryOperatedFS.Name = "btnUnaryOperatedFS";
            this.btnUnaryOperatedFS.Size = new System.Drawing.Size(220, 33);
            this.btnUnaryOperatedFS.TabIndex = 9;
            this.btnUnaryOperatedFS.Text = "Generate Unary Operated FS";
            this.btnUnaryOperatedFS.UseVisualStyleBackColor = true;
            this.btnUnaryOperatedFS.Click += new System.EventHandler(this.btnUnaryOperatedFS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(681, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Unary Operators";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(681, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Click to specify Operand 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(678, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Click to specify Operand 1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(681, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Negate",
            "Alpha Cut"});
            this.comboBox1.Location = new System.Drawing.Point(681, 153);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 24);
            this.comboBox1.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 562);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUnaryOperatedFS);
            this.Controls.Add(this.cbxUnaryOperators);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labOperand1);
            this.Controls.Add(this.btnCreateFuzzySet);
            this.Controls.Add(this.cbxFSTypes);
            this.Controls.Add(this.ppgTarget);
            this.Controls.Add(this.trvUniverses);
            this.Controls.Add(this.btnCreateUniverse);
            this.Controls.Add(this.btnDelete);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assignment 03 YT Kan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.labOperand1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateUniverse;
        private System.Windows.Forms.TreeView trvUniverses;
        private System.Windows.Forms.PropertyGrid ppgTarget;
        private System.Windows.Forms.ComboBox cbxFSTypes;
        private System.Windows.Forms.Button btnCreateFuzzySet;
        private System.Windows.Forms.DataVisualization.Charting.Chart labOperand1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbxUnaryOperators;
        private System.Windows.Forms.Button btnUnaryOperatedFS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

