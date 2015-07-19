namespace Whats.DataBackupClient
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
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnCloud = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnCloudAdvanced = new System.Windows.Forms.Button();
            this.btnLocalAdvanced = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(33, 61);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(223, 32);
            this.btnLocal.TabIndex = 0;
            this.btnLocal.Text = "一键本地备份";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnCloud
            // 
            this.btnCloud.Location = new System.Drawing.Point(33, 23);
            this.btnCloud.Name = "btnCloud";
            this.btnCloud.Size = new System.Drawing.Size(223, 32);
            this.btnCloud.TabIndex = 1;
            this.btnCloud.Text = "一键云端备份";
            this.btnCloud.UseVisualStyleBackColor = true;
            this.btnCloud.Click += new System.EventHandler(this.btnCloud_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(33, 176);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(223, 32);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "数据恢复";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnCloudAdvanced
            // 
            this.btnCloudAdvanced.Location = new System.Drawing.Point(33, 139);
            this.btnCloudAdvanced.Name = "btnCloudAdvanced";
            this.btnCloudAdvanced.Size = new System.Drawing.Size(223, 32);
            this.btnCloudAdvanced.TabIndex = 4;
            this.btnCloudAdvanced.Text = "云端备份高级";
            this.btnCloudAdvanced.UseVisualStyleBackColor = true;
            this.btnCloudAdvanced.Click += new System.EventHandler(this.btnCloudAdvanced_Click);
            // 
            // btnLocalAdvanced
            // 
            this.btnLocalAdvanced.Location = new System.Drawing.Point(33, 101);
            this.btnLocalAdvanced.Name = "btnLocalAdvanced";
            this.btnLocalAdvanced.Size = new System.Drawing.Size(223, 32);
            this.btnLocalAdvanced.TabIndex = 3;
            this.btnLocalAdvanced.Text = "本地备份高级";
            this.btnLocalAdvanced.UseVisualStyleBackColor = true;
            this.btnLocalAdvanced.Click += new System.EventHandler(this.btnLocalAdvanced_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(33, 215);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(223, 32);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 270);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnCloudAdvanced);
            this.Controls.Add(this.btnLocalAdvanced);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnCloud);
            this.Controls.Add(this.btnLocal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据管理";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnCloud;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnCloudAdvanced;
        private System.Windows.Forms.Button btnLocalAdvanced;
        private System.Windows.Forms.Button btnAbout;
    }
}