namespace Whats.DataBackupClient
{
    partial class LocalDataBackup
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBackUpDir = new System.Windows.Forms.TextBox();
            this.btnBrowserBackUpDir = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnCloud = new System.Windows.Forms.Button();
            this.btnCloudRestore = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地备份文件夹";
            // 
            // txtBackUpDir
            // 
            this.txtBackUpDir.Location = new System.Drawing.Point(192, 33);
            this.txtBackUpDir.Name = "txtBackUpDir";
            this.txtBackUpDir.Size = new System.Drawing.Size(212, 32);
            this.txtBackUpDir.TabIndex = 1;
            this.txtBackUpDir.Text = "D:/UCCDATA/";
            // 
            // btnBrowserBackUpDir
            // 
            this.btnBrowserBackUpDir.Location = new System.Drawing.Point(410, 31);
            this.btnBrowserBackUpDir.Name = "btnBrowserBackUpDir";
            this.btnBrowserBackUpDir.Size = new System.Drawing.Size(87, 31);
            this.btnBrowserBackUpDir.TabIndex = 2;
            this.btnBrowserBackUpDir.Text = "浏览";
            this.btnBrowserBackUpDir.UseVisualStyleBackColor = true;
            this.btnBrowserBackUpDir.Click += new System.EventHandler(this.btnBrowserBackUpDir_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(503, 31);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(105, 31);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "备份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(47, 219);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(139, 37);
            this.btnOut.TabIndex = 4;
            this.btnOut.Text = "导出数据库";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnCloud
            // 
            this.btnCloud.Location = new System.Drawing.Point(192, 219);
            this.btnCloud.Name = "btnCloud";
            this.btnCloud.Size = new System.Drawing.Size(139, 37);
            this.btnCloud.TabIndex = 5;
            this.btnCloud.Text = "一键云备份";
            this.btnCloud.UseVisualStyleBackColor = true;
            this.btnCloud.Click += new System.EventHandler(this.btnCloud_Click);
            // 
            // btnCloudRestore
            // 
            this.btnCloudRestore.Location = new System.Drawing.Point(47, 305);
            this.btnCloudRestore.Name = "btnCloudRestore";
            this.btnCloudRestore.Size = new System.Drawing.Size(139, 37);
            this.btnCloudRestore.TabIndex = 6;
            this.btnCloudRestore.Text = "云数据还原";
            this.btnCloudRestore.UseVisualStyleBackColor = true;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(47, 262);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(139, 37);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "数据还原";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // LocalDataBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 406);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnCloudRestore);
            this.Controls.Add(this.btnCloud);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnBrowserBackUpDir);
            this.Controls.Add(this.txtBackUpDir);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 16F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "LocalDataBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "备份";
            this.Load += new System.EventHandler(this.DataBackUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBackUpDir;
        private System.Windows.Forms.Button btnBrowserBackUpDir;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnCloud;
        private System.Windows.Forms.Button btnCloudRestore;
        private System.Windows.Forms.Button btnRestore;
    }
}