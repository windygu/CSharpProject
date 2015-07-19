namespace Whats.Cloud.QiniuFileManager
{
    partial class PassForm
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
            this.txtACCESSKEY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSECRETKEY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBucket = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOperator = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtACCESSKEY
            // 
            this.txtACCESSKEY.Location = new System.Drawing.Point(84, 21);
            this.txtACCESSKEY.Name = "txtACCESSKEY";
            this.txtACCESSKEY.Size = new System.Drawing.Size(100, 21);
            this.txtACCESSKEY.TabIndex = 0;
            this.txtACCESSKEY.Text = "d__z80SkcAJ5DQJKEGKrnJ3dqI-zt6QehAMUUXkr";
            this.txtACCESSKEY.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ACCESS_KEY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "SECRET_KEY";
            // 
            // txtSECRETKEY
            // 
            this.txtSECRETKEY.Location = new System.Drawing.Point(84, 48);
            this.txtSECRETKEY.Name = "txtSECRETKEY";
            this.txtSECRETKEY.Size = new System.Drawing.Size(100, 21);
            this.txtSECRETKEY.TabIndex = 2;
            this.txtSECRETKEY.Text = "xzlotG1VWSR41v0wB9t9L4oFotvphcsvYiVX6u17";
            this.txtSECRETKEY.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bucket";
            // 
            // txtBucket
            // 
            this.txtBucket.Location = new System.Drawing.Point(84, 75);
            this.txtBucket.Name = "txtBucket";
            this.txtBucket.Size = new System.Drawing.Size(100, 21);
            this.txtBucket.TabIndex = 4;
            this.txtBucket.Text = "cleaner-backup";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Operator";
            // 
            // txtOperator
            // 
            this.txtOperator.Location = new System.Drawing.Point(84, 102);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Size = new System.Drawing.Size(100, 21);
            this.txtOperator.TabIndex = 6;
            this.txtOperator.Text = "lujiejie";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(15, 156);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(169, 41);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Ok";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Pass";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(84, 129);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 21);
            this.txtPass.TabIndex = 9;
            this.txtPass.Text = "121226nnn";
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // PassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 212);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOperator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBucket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSECRETKEY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtACCESSKEY);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pass";
            this.Load += new System.EventHandler(this.PassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtACCESSKEY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSECRETKEY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBucket;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOperator;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPass;
    }
}

