namespace Updater.HelperClient
{
    partial class Client
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtLocaDir = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnBrowserUpdate = new System.Windows.Forms.Button();
            this.txtRemoteUrl = new System.Windows.Forms.TextBox();
            this.gbxCreate = new System.Windows.Forms.GroupBox();
            this.gbxUpdate = new System.Windows.Forms.GroupBox();
            this.txtLocalUpdate = new System.Windows.Forms.TextBox();
            this.btnLocalUpdate = new System.Windows.Forms.Button();
            this.gbxCreate.SuspendLayout();
            this.gbxUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(6, 47);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(292, 53);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtLocaDir
            // 
            this.txtLocaDir.Location = new System.Drawing.Point(6, 20);
            this.txtLocaDir.Name = "txtLocaDir";
            this.txtLocaDir.Size = new System.Drawing.Size(212, 21);
            this.txtLocaDir.TabIndex = 1;
            this.txtLocaDir.Text = "D:\\Projects\\NEWUCC\\bin\\Debug";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(224, 20);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(74, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "本地地址";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(6, 76);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(292, 53);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnBrowserUpdate
            // 
            this.btnBrowserUpdate.Location = new System.Drawing.Point(224, 20);
            this.btnBrowserUpdate.Name = "btnBrowserUpdate";
            this.btnBrowserUpdate.Size = new System.Drawing.Size(74, 23);
            this.btnBrowserUpdate.TabIndex = 4;
            this.btnBrowserUpdate.Text = "远程地址";
            this.btnBrowserUpdate.UseVisualStyleBackColor = true;
            this.btnBrowserUpdate.Click += new System.EventHandler(this.btnBrowserUpdate_Click);
            // 
            // txtRemoteUrl
            // 
            this.txtRemoteUrl.Location = new System.Drawing.Point(6, 20);
            this.txtRemoteUrl.Name = "txtRemoteUrl";
            this.txtRemoteUrl.Size = new System.Drawing.Size(212, 21);
            this.txtRemoteUrl.TabIndex = 5;
            this.txtRemoteUrl.Text = "http://localhost:9999/update_tmp/update.json";
            // 
            // gbxCreate
            // 
            this.gbxCreate.Controls.Add(this.txtLocaDir);
            this.gbxCreate.Controls.Add(this.btnBrowser);
            this.gbxCreate.Controls.Add(this.btnCreate);
            this.gbxCreate.Location = new System.Drawing.Point(12, 12);
            this.gbxCreate.Name = "gbxCreate";
            this.gbxCreate.Size = new System.Drawing.Size(311, 113);
            this.gbxCreate.TabIndex = 6;
            this.gbxCreate.TabStop = false;
            this.gbxCreate.Text = "创建版本";
            // 
            // gbxUpdate
            // 
            this.gbxUpdate.Controls.Add(this.txtLocalUpdate);
            this.gbxUpdate.Controls.Add(this.btnLocalUpdate);
            this.gbxUpdate.Controls.Add(this.txtRemoteUrl);
            this.gbxUpdate.Controls.Add(this.btnBrowserUpdate);
            this.gbxUpdate.Controls.Add(this.btnUpdate);
            this.gbxUpdate.Location = new System.Drawing.Point(12, 139);
            this.gbxUpdate.Name = "gbxUpdate";
            this.gbxUpdate.Size = new System.Drawing.Size(311, 147);
            this.gbxUpdate.TabIndex = 7;
            this.gbxUpdate.TabStop = false;
            this.gbxUpdate.Text = "更新操作";
            // 
            // txtLocalUpdate
            // 
            this.txtLocalUpdate.Location = new System.Drawing.Point(6, 47);
            this.txtLocalUpdate.Name = "txtLocalUpdate";
            this.txtLocalUpdate.Size = new System.Drawing.Size(212, 21);
            this.txtLocalUpdate.TabIndex = 6;
            this.txtLocalUpdate.Text = "D:\\工作目录\\update_test";
            // 
            // btnLocalUpdate
            // 
            this.btnLocalUpdate.Location = new System.Drawing.Point(224, 47);
            this.btnLocalUpdate.Name = "btnLocalUpdate";
            this.btnLocalUpdate.Size = new System.Drawing.Size(74, 23);
            this.btnLocalUpdate.TabIndex = 7;
            this.btnLocalUpdate.Text = "本地地址";
            this.btnLocalUpdate.UseVisualStyleBackColor = true;
            this.btnLocalUpdate.Click += new System.EventHandler(this.btnLocalUpdate_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 409);
            this.Controls.Add(this.gbxUpdate);
            this.Controls.Add(this.gbxCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Helper Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.gbxCreate.ResumeLayout(false);
            this.gbxCreate.PerformLayout();
            this.gbxUpdate.ResumeLayout(false);
            this.gbxUpdate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtLocaDir;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnBrowserUpdate;
        private System.Windows.Forms.TextBox txtRemoteUrl;
        private System.Windows.Forms.GroupBox gbxCreate;
        private System.Windows.Forms.GroupBox gbxUpdate;
        private System.Windows.Forms.TextBox txtLocalUpdate;
        private System.Windows.Forms.Button btnLocalUpdate;
    }
}

