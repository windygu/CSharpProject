namespace Cleaner
{
    partial class PrintMoneyTicketForm
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
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtRestMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOkUserID = new System.Windows.Forms.Button();
            this.txtTicketMoney = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrint = new System.Windows.Forms.Button();
            this.txtTicketID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDoMoney = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员卡号";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(138, 27);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(184, 29);
            this.txtUserID.TabIndex = 1;
            // 
            // txtRestMoney
            // 
            this.txtRestMoney.Location = new System.Drawing.Point(138, 80);
            this.txtRestMoney.Margin = new System.Windows.Forms.Padding(5);
            this.txtRestMoney.Name = "txtRestMoney";
            this.txtRestMoney.Size = new System.Drawing.Size(318, 29);
            this.txtRestMoney.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "卡上余额";
            // 
            // btnOkUserID
            // 
            this.btnOkUserID.Location = new System.Drawing.Point(348, 24);
            this.btnOkUserID.Name = "btnOkUserID";
            this.btnOkUserID.Size = new System.Drawing.Size(108, 34);
            this.btnOkUserID.TabIndex = 4;
            this.btnOkUserID.Text = "读取";
            this.btnOkUserID.UseVisualStyleBackColor = true;
            this.btnOkUserID.Click += new System.EventHandler(this.btnOkUserID_Click);
            // 
            // txtTicketMoney
            // 
            this.txtTicketMoney.Location = new System.Drawing.Point(138, 136);
            this.txtTicketMoney.Margin = new System.Windows.Forms.Padding(5);
            this.txtTicketMoney.Name = "txtTicketMoney";
            this.txtTicketMoney.Size = new System.Drawing.Size(318, 29);
            this.txtTicketMoney.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "账单金额";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(138, 187);
            this.txtReason.Margin = new System.Windows.Forms.Padding(5);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(318, 84);
            this.txtReason.TabIndex = 8;
            this.txtReason.Text = "洗衣收费";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 192);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "扣费缘由";
            // 
            // txtPrint
            // 
            this.txtPrint.Location = new System.Drawing.Point(284, 341);
            this.txtPrint.Name = "txtPrint";
            this.txtPrint.Size = new System.Drawing.Size(111, 39);
            this.txtPrint.TabIndex = 9;
            this.txtPrint.Text = "打印";
            this.txtPrint.UseVisualStyleBackColor = true;
            this.txtPrint.Click += new System.EventHandler(this.txtPrint_Click);
            // 
            // txtTicketID
            // 
            this.txtTicketID.Location = new System.Drawing.Point(138, 291);
            this.txtTicketID.Margin = new System.Windows.Forms.Padding(5);
            this.txtTicketID.Name = "txtTicketID";
            this.txtTicketID.Size = new System.Drawing.Size(318, 29);
            this.txtTicketID.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 296);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "收衣单号";
            // 
            // txtDoMoney
            // 
            this.txtDoMoney.Location = new System.Drawing.Point(125, 341);
            this.txtDoMoney.Name = "txtDoMoney";
            this.txtDoMoney.Size = new System.Drawing.Size(111, 39);
            this.txtDoMoney.TabIndex = 12;
            this.txtDoMoney.Text = "扣费";
            this.txtDoMoney.UseVisualStyleBackColor = true;
            this.txtDoMoney.Click += new System.EventHandler(this.txtDoMoney_Click);
            // 
            // PrintMoneyTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 401);
            this.Controls.Add(this.txtDoMoney);
            this.Controls.Add(this.txtTicketID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPrint);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTicketMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOkUserID);
            this.Controls.Add(this.txtRestMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "PrintMoneyTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手写单扣费打印";
            this.Load += new System.EventHandler(this.PrintMoneyTicket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtRestMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOkUserID;
        private System.Windows.Forms.TextBox txtTicketMoney;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button txtPrint;
        private System.Windows.Forms.TextBox txtTicketID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button txtDoMoney;
    }
}