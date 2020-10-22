namespace R08546000FCYangAss04
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnCreateUniverse = new System.Windows.Forms.Button();
            this.trvUniverses = new System.Windows.Forms.TreeView();
            this.ppgTarget = new System.Windows.Forms.PropertyGrid();
            this.cbxFSTypes = new System.Windows.Forms.ComboBox();
            this.btnCreateFuzzySet = new System.Windows.Forms.Button();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateUniverse
            // 
            this.btnCreateUniverse.Location = new System.Drawing.Point(12, 13);
            this.btnCreateUniverse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateUniverse.Name = "btnCreateUniverse";
            this.btnCreateUniverse.Size = new System.Drawing.Size(166, 37);
            this.btnCreateUniverse.TabIndex = 0;
            this.btnCreateUniverse.Text = "New Universe";
            this.btnCreateUniverse.UseVisualStyleBackColor = true;
            this.btnCreateUniverse.Click += new System.EventHandler(this.btnCreateUniverse_Click);
            // 
            // trvUniverses
            // 
            this.trvUniverses.HideSelection = false;
            this.trvUniverses.Location = new System.Drawing.Point(12, 88);
            this.trvUniverses.Name = "trvUniverses";
            this.trvUniverses.Size = new System.Drawing.Size(247, 228);
            this.trvUniverses.TabIndex = 1;
            this.trvUniverses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvUniverses_AfterSelect);
            // 
            // ppgTarget
            // 
            this.ppgTarget.Location = new System.Drawing.Point(365, 128);
            this.ppgTarget.Name = "ppgTarget";
            this.ppgTarget.Size = new System.Drawing.Size(234, 146);
            this.ppgTarget.TabIndex = 2;
            this.ppgTarget.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.ppgTarget_PropertyValueChanged);
            // 
            // cbxFSTypes
            // 
            this.cbxFSTypes.FormattingEnabled = true;
            this.cbxFSTypes.Items.AddRange(new object[] {
            "Gaussian Fuzzy Set",
            "Triangular Fuzzy Set",
            "..."});
            this.cbxFSTypes.Location = new System.Drawing.Point(378, 13);
            this.cbxFSTypes.Name = "cbxFSTypes";
            this.cbxFSTypes.Size = new System.Drawing.Size(204, 24);
            this.cbxFSTypes.TabIndex = 3;
            // 
            // btnCreateFuzzySet
            // 
            this.btnCreateFuzzySet.Location = new System.Drawing.Point(378, 65);
            this.btnCreateFuzzySet.Name = "btnCreateFuzzySet";
            this.btnCreateFuzzySet.Size = new System.Drawing.Size(204, 42);
            this.btnCreateFuzzySet.TabIndex = 4;
            this.btnCreateFuzzySet.Text = "Create Fuzzy Set";
            this.btnCreateFuzzySet.UseVisualStyleBackColor = true;
            this.btnCreateFuzzySet.Click += new System.EventHandler(this.btnCreateFuzzySet_Click);
            // 
            // mainChart
            // 
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(82, 334);
            this.mainChart.Name = "mainChart";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.mainChart.Series.Add(series1);
            this.mainChart.Size = new System.Drawing.Size(517, 198);
            this.mainChart.TabIndex = 5;
            this.mainChart.Text = "chart1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 544);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.btnCreateFuzzySet);
            this.Controls.Add(this.cbxFSTypes);
            this.Controls.Add(this.ppgTarget);
            this.Controls.Add(this.trvUniverses);
            this.Controls.Add(this.btnCreateUniverse);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateUniverse;
        private System.Windows.Forms.TreeView trvUniverses;
        private System.Windows.Forms.PropertyGrid ppgTarget;
        private System.Windows.Forms.ComboBox cbxFSTypes;
        private System.Windows.Forms.Button btnCreateFuzzySet;
        private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
    }
}

