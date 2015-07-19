namespace Roo.Data.ManagerClient
{
    partial class Create
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
            this.txtDBPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnModels = new System.Windows.Forms.Button();
            this.txtDataPre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowserDBPath = new System.Windows.Forms.Button();
            this.lbxModels = new System.Windows.Forms.ListBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDBPath
            // 
            this.txtDBPath.Location = new System.Drawing.Point(105, 5);
            this.txtDBPath.Name = "txtDBPath";
            this.txtDBPath.Size = new System.Drawing.Size(293, 21);
            this.txtDBPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库保存路径";
            // 
            // btnModels
            // 
            this.btnModels.Location = new System.Drawing.Point(12, 60);
            this.btnModels.Name = "btnModels";
            this.btnModels.Size = new System.Drawing.Size(460, 23);
            this.btnModels.TabIndex = 5;
            this.btnModels.Text = "数据模型";
            this.btnModels.UseVisualStyleBackColor = true;
            this.btnModels.Click += new System.EventHandler(this.btnModels_Click);
            // 
            // txtDataPre
            // 
            this.txtDataPre.Location = new System.Drawing.Point(105, 32);
            this.txtDataPre.Name = "txtDataPre";
            this.txtDataPre.Size = new System.Drawing.Size(367, 21);
            this.txtDataPre.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "数据前缀";
            // 
            // btnBrowserDBPath
            // 
            this.btnBrowserDBPath.Location = new System.Drawing.Point(404, 3);
            this.btnBrowserDBPath.Name = "btnBrowserDBPath";
            this.btnBrowserDBPath.Size = new System.Drawing.Size(68, 23);
            this.btnBrowserDBPath.TabIndex = 8;
            this.btnBrowserDBPath.Text = "浏览";
            this.btnBrowserDBPath.UseVisualStyleBackColor = true;
            this.btnBrowserDBPath.Click += new System.EventHandler(this.btnBrowserDBPath_Click);
            // 
            // lbxModels
            // 
            this.lbxModels.FormattingEnabled = true;
            this.lbxModels.ItemHeight = 12;
            this.lbxModels.Location = new System.Drawing.Point(12, 90);
            this.lbxModels.Name = "lbxModels";
            this.lbxModels.Size = new System.Drawing.Size(460, 184);
            this.lbxModels.TabIndex = 9;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 281);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(460, 28);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "创建";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 324);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lbxModels);
            this.Controls.Add(this.btnBrowserDBPath);
            this.Controls.Add(this.txtDataPre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnModels);
            this.Controls.Add(this.txtDBPath);
            this.Controls.Add(this.label2);
            this.Name = "Create";
            this.Text = "创建数据库";
            this.Load += new System.EventHandler(this.Create_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDBPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModels;
        private System.Windows.Forms.TextBox txtDataPre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowserDBPath;
        private System.Windows.Forms.ListBox lbxModels;
        private System.Windows.Forms.Button btnCreate;
    }
}