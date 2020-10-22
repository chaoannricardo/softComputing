namespace R08546000FCYangAss10
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.rtbPblem = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pagCityNRoute = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCreateACS = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(24, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(112, 41);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open A TSP";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // rtbPblem
            // 
            this.rtbPblem.Location = new System.Drawing.Point(13, 112);
            this.rtbPblem.Name = "rtbPblem";
            this.rtbPblem.Size = new System.Drawing.Size(200, 301);
            this.rtbPblem.TabIndex = 1;
            this.rtbPblem.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.pagCityNRoute);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(241, 124);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(497, 289);
            this.tabControl1.TabIndex = 2;
            // 
            // pagCityNRoute
            // 
            this.pagCityNRoute.Location = new System.Drawing.Point(4, 22);
            this.pagCityNRoute.Name = "pagCityNRoute";
            this.pagCityNRoute.Padding = new System.Windows.Forms.Padding(3);
            this.pagCityNRoute.Size = new System.Drawing.Size(489, 263);
            this.pagCityNRoute.TabIndex = 0;
            this.pagCityNRoute.Text = "tabPage1";
            this.pagCityNRoute.UseVisualStyleBackColor = true;
            this.pagCityNRoute.Paint += new System.Windows.Forms.PaintEventHandler(this.pagCityNRoute_Paint);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCreateACS
            // 
            this.btnCreateACS.Location = new System.Drawing.Point(332, 16);
            this.btnCreateACS.Name = "btnCreateACS";
            this.btnCreateACS.Size = new System.Drawing.Size(148, 32);
            this.btnCreateACS.TabIndex = 3;
            this.btnCreateACS.Text = "Create ACS Solver";
            this.btnCreateACS.UseVisualStyleBackColor = true;
            this.btnCreateACS.Click += new System.EventHandler(this.btnCreateACS_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateACS);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.rtbPblem);
            this.Controls.Add(this.btnOpen);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.RichTextBox rtbPblem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pagCityNRoute;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCreateACS;
    }
}

