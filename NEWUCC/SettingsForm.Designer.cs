namespace Cleaner
{
    partial class SettingsForm
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
            this.cbxIsAutoStart = new System.Windows.Forms.CheckBox();
            this.cbxIsInDeskTop = new System.Windows.Forms.CheckBox();
            this.cbxIsInStartMenu = new System.Windows.Forms.CheckBox();
            this.cbxIsAutoCloudBackupData = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxInAutoCheckUpdate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbxIsAutoStart
            // 
            this.cbxIsAutoStart.AutoSize = true;
            this.cbxIsAutoStart.Checked = true;
            this.cbxIsAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIsAutoStart.Location = new System.Drawing.Point(39, 30);
            this.cbxIsAutoStart.Name = "cbxIsAutoStart";
            this.cbxIsAutoStart.Size = new System.Drawing.Size(123, 23);
            this.cbxIsAutoStart.TabIndex = 1;
            this.cbxIsAutoStart.Text = "开机自启动";
            this.cbxIsAutoStart.UseVisualStyleBackColor = true;
            // 
            // cbxIsInDeskTop
            // 
            this.cbxIsInDeskTop.AutoSize = true;
            this.cbxIsInDeskTop.Checked = true;
            this.cbxIsInDeskTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIsInDeskTop.Location = new System.Drawing.Point(39, 59);
            this.cbxIsInDeskTop.Name = "cbxIsInDeskTop";
            this.cbxIsInDeskTop.Size = new System.Drawing.Size(180, 23);
            this.cbxIsInDeskTop.TabIndex = 2;
            this.cbxIsInDeskTop.Text = "创建桌面快捷方式";
            this.cbxIsInDeskTop.UseVisualStyleBackColor = true;
            // 
            // cbxIsInStartMenu
            // 
            this.cbxIsInStartMenu.AutoSize = true;
            this.cbxIsInStartMenu.Checked = true;
            this.cbxIsInStartMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIsInStartMenu.Location = new System.Drawing.Point(39, 88);
            this.cbxIsInStartMenu.Name = "cbxIsInStartMenu";
            this.cbxIsInStartMenu.Size = new System.Drawing.Size(142, 23);
            this.cbxIsInStartMenu.TabIndex = 3;
            this.cbxIsInStartMenu.Text = "创建开始菜单";
            this.cbxIsInStartMenu.UseVisualStyleBackColor = true;
            // 
            // cbxIsAutoCloudBackupData
            // 
            this.cbxIsAutoCloudBackupData.AutoSize = true;
            this.cbxIsAutoCloudBackupData.Checked = true;
            this.cbxIsAutoCloudBackupData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIsAutoCloudBackupData.Location = new System.Drawing.Point(39, 117);
            this.cbxIsAutoCloudBackupData.Name = "cbxIsAutoCloudBackupData";
            this.cbxIsAutoCloudBackupData.Size = new System.Drawing.Size(123, 23);
            this.cbxIsAutoCloudBackupData.TabIndex = 5;
            this.cbxIsAutoCloudBackupData.Text = "自动云备份";
            this.cbxIsAutoCloudBackupData.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(49, 197);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(151, 39);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxInAutoCheckUpdate
            // 
            this.cbxInAutoCheckUpdate.AutoSize = true;
            this.cbxInAutoCheckUpdate.Checked = true;
            this.cbxInAutoCheckUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxInAutoCheckUpdate.Location = new System.Drawing.Point(39, 146);
            this.cbxInAutoCheckUpdate.Name = "cbxInAutoCheckUpdate";
            this.cbxInAutoCheckUpdate.Size = new System.Drawing.Size(142, 23);
            this.cbxInAutoCheckUpdate.TabIndex = 10;
            this.cbxInAutoCheckUpdate.Text = "自动检测更新";
            this.cbxInAutoCheckUpdate.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 262);
            this.Controls.Add(this.cbxInAutoCheckUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxIsAutoCloudBackupData);
            this.Controls.Add(this.cbxIsInStartMenu);
            this.Controls.Add(this.cbxIsInDeskTop);
            this.Controls.Add(this.cbxIsAutoStart);
            this.Font = new System.Drawing.Font("宋体", 14F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxIsAutoStart;
        private System.Windows.Forms.CheckBox cbxIsInDeskTop;
        private System.Windows.Forms.CheckBox cbxIsInStartMenu;
        private System.Windows.Forms.CheckBox cbxIsAutoCloudBackupData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbxInAutoCheckUpdate;
    }
}