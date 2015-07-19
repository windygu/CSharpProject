namespace Whats.Installer.CompileClient
{
    partial class UnStart
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
            this.btnUnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUnStart
            // 
            this.btnUnStart.Location = new System.Drawing.Point(98, 72);
            this.btnUnStart.Name = "btnUnStart";
            this.btnUnStart.Size = new System.Drawing.Size(188, 45);
            this.btnUnStart.TabIndex = 0;
            this.btnUnStart.Text = "一键卸载";
            this.btnUnStart.UseVisualStyleBackColor = true;
            this.btnUnStart.Click += new System.EventHandler(this.btnUnStart_Click);
            // 
            // UnStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 188);
            this.Controls.Add(this.btnUnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UnStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "卸载";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnStart;
    }
}