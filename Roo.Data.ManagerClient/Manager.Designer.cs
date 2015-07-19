namespace Roo.Data.ManagerClient
{
    partial class Manager
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateTableFromModelCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateTableFromModelCode
            // 
            this.btnCreateTableFromModelCode.Location = new System.Drawing.Point(37, 42);
            this.btnCreateTableFromModelCode.Name = "btnCreateTableFromModelCode";
            this.btnCreateTableFromModelCode.Size = new System.Drawing.Size(258, 60);
            this.btnCreateTableFromModelCode.TabIndex = 0;
            this.btnCreateTableFromModelCode.Text = "CreateTableFromModelCode";
            this.btnCreateTableFromModelCode.UseVisualStyleBackColor = true;
            this.btnCreateTableFromModelCode.Click += new System.EventHandler(this.btnCreateTableFromModelCode_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 262);
            this.Controls.Add(this.btnCreateTableFromModelCode);
            this.Name = "Manager";
            this.Text = "Roo Data Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateTableFromModelCode;
    }
}

