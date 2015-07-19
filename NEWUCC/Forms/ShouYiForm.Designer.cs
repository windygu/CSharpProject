namespace NEWUCC
{
    partial class ShouYiForm
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
            this.label16 = new System.Windows.Forms.Label();
            this.cbxZheKou = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxMoneyState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtThisMoney = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.联系方式 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPutWay = new System.Windows.Forms.ComboBox();
            this.datePutIn = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datePutOut = new System.Windows.Forms.DateTimePicker();
            this.btnUserID = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtTicketID = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDeleteYiFu = new System.Windows.Forms.Button();
            this.btnAddYiFu = new System.Windows.Forms.Button();
            this.btnShouKuan = new System.Windows.Forms.Button();
            this.btnKaiDan = new System.Windows.Forms.Button();
            this.btnPreMoney = new System.Windows.Forms.Button();
            this.btnPrintMoney = new System.Windows.Forms.Button();
            this.btnPreView = new System.Windows.Forms.Button();
            this.btnNexTicket = new System.Windows.Forms.Button();
            this.lbxYiFu = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(633, 253);
            this.label16.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 19);
            this.label16.TabIndex = 94;
            this.label16.Text = "折扣";
            // 
            // cbxZheKou
            // 
            this.cbxZheKou.FormattingEnabled = true;
            this.cbxZheKou.Items.AddRange(new object[] {
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1"});
            this.cbxZheKou.Location = new System.Drawing.Point(762, 246);
            this.cbxZheKou.Margin = new System.Windows.Forms.Padding(8);
            this.cbxZheKou.Name = "cbxZheKou";
            this.cbxZheKou.Size = new System.Drawing.Size(349, 27);
            this.cbxZheKou.TabIndex = 95;
            this.cbxZheKou.Text = "10";
            this.cbxZheKou.SelectedIndexChanged += new System.EventHandler(this.cbxZheKou_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 254);
            this.label15.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 19);
            this.label15.TabIndex = 92;
            this.label15.Text = "付款状态";
            // 
            // cbxMoneyState
            // 
            this.cbxMoneyState.FormattingEnabled = true;
            this.cbxMoneyState.Items.AddRange(new object[] {
            "未付",
            "已付"});
            this.cbxMoneyState.Location = new System.Drawing.Point(150, 250);
            this.cbxMoneyState.Margin = new System.Windows.Forms.Padding(8);
            this.cbxMoneyState.Name = "cbxMoneyState";
            this.cbxMoneyState.Size = new System.Drawing.Size(296, 27);
            this.cbxMoneyState.TabIndex = 93;
            this.cbxMoneyState.Text = "未付";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 71;
            this.label1.Text = "收衣单编号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(633, 208);
            this.label13.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 19);
            this.label13.TabIndex = 91;
            this.label13.Text = "此次交易额";
            // 
            // txtThisMoney
            // 
            this.txtThisMoney.Location = new System.Drawing.Point(762, 202);
            this.txtThisMoney.Margin = new System.Windows.Forms.Padding(8);
            this.txtThisMoney.Name = "txtThisMoney";
            this.txtThisMoney.Size = new System.Drawing.Size(352, 29);
            this.txtThisMoney.TabIndex = 90;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(763, 73);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(8);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(352, 29);
            this.txtPhone.TabIndex = 72;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(464, 22);
            this.btnOk.Margin = new System.Windows.Forms.Padding(8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(153, 33);
            this.btnOk.TabIndex = 89;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // 联系方式
            // 
            this.联系方式.AutoSize = true;
            this.联系方式.Location = new System.Drawing.Point(633, 81);
            this.联系方式.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.联系方式.Name = "联系方式";
            this.联系方式.Size = new System.Drawing.Size(85, 19);
            this.联系方式.TabIndex = 73;
            this.联系方式.Text = "联系方式";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(633, 170);
            this.label12.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 19);
            this.label12.TabIndex = 88;
            this.label12.Text = "余额";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(763, 118);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(8);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(352, 29);
            this.txtAddress.TabIndex = 74;
            // 
            // txtMoney
            // 
            this.txtMoney.Enabled = false;
            this.txtMoney.Location = new System.Drawing.Point(763, 162);
            this.txtMoney.Margin = new System.Windows.Forms.Padding(8);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(352, 29);
            this.txtMoney.TabIndex = 87;
            this.txtMoney.TextChanged += new System.EventHandler(this.txtMoney_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(633, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 75;
            this.label2.Text = "地址";
            // 
            // cbxPutWay
            // 
            this.cbxPutWay.FormattingEnabled = true;
            this.cbxPutWay.Items.AddRange(new object[] {
            "自提",
            "上门"});
            this.cbxPutWay.Location = new System.Drawing.Point(150, 162);
            this.cbxPutWay.Margin = new System.Windows.Forms.Padding(8);
            this.cbxPutWay.Name = "cbxPutWay";
            this.cbxPutWay.Size = new System.Drawing.Size(298, 27);
            this.cbxPutWay.TabIndex = 86;
            this.cbxPutWay.Text = "自提";
            // 
            // datePutIn
            // 
            this.datePutIn.Location = new System.Drawing.Point(150, 71);
            this.datePutIn.Margin = new System.Windows.Forms.Padding(8);
            this.datePutIn.Name = "datePutIn";
            this.datePutIn.Size = new System.Drawing.Size(298, 29);
            this.datePutIn.TabIndex = 76;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 166);
            this.label10.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 19);
            this.label10.TabIndex = 85;
            this.label10.Text = "取衣方式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 77;
            this.label3.Text = "收衣日期";
            // 
            // datePutOut
            // 
            this.datePutOut.Location = new System.Drawing.Point(150, 116);
            this.datePutOut.Margin = new System.Windows.Forms.Padding(8);
            this.datePutOut.Name = "datePutOut";
            this.datePutOut.Size = new System.Drawing.Size(298, 29);
            this.datePutOut.TabIndex = 78;
            // 
            // btnUserID
            // 
            this.btnUserID.Location = new System.Drawing.Point(462, 201);
            this.btnUserID.Margin = new System.Windows.Forms.Padding(8);
            this.btnUserID.Name = "btnUserID";
            this.btnUserID.Size = new System.Drawing.Size(153, 33);
            this.btnUserID.TabIndex = 84;
            this.btnUserID.Text = "读";
            this.btnUserID.UseVisualStyleBackColor = true;
            this.btnUserID.Click += new System.EventHandler(this.btnUserID_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 79;
            this.label4.Text = "取衣日期";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(633, 29);
            this.label9.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 19);
            this.label9.TabIndex = 83;
            this.label9.Text = "会员名称";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(762, 22);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(8);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(352, 29);
            this.txtUserName.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 207);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 19);
            this.label8.TabIndex = 81;
            this.label8.Text = "会员编号";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(150, 205);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(8);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(296, 29);
            this.txtUserID.TabIndex = 80;
            // 
            // txtTicketID
            // 
            this.txtTicketID.Location = new System.Drawing.Point(150, 26);
            this.txtTicketID.Margin = new System.Windows.Forms.Padding(8);
            this.txtTicketID.Name = "txtTicketID";
            this.txtTicketID.Size = new System.Drawing.Size(298, 29);
            this.txtTicketID.TabIndex = 70;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(461, 392);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(154, 37);
            this.btnEdit.TabIndex = 115;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDeleteYiFu
            // 
            this.btnDeleteYiFu.Location = new System.Drawing.Point(461, 339);
            this.btnDeleteYiFu.Margin = new System.Windows.Forms.Padding(8);
            this.btnDeleteYiFu.Name = "btnDeleteYiFu";
            this.btnDeleteYiFu.Size = new System.Drawing.Size(154, 37);
            this.btnDeleteYiFu.TabIndex = 114;
            this.btnDeleteYiFu.Text = "删除";
            this.btnDeleteYiFu.UseVisualStyleBackColor = true;
            this.btnDeleteYiFu.Click += new System.EventHandler(this.btnDeleteYiFu_Click);
            // 
            // btnAddYiFu
            // 
            this.btnAddYiFu.Location = new System.Drawing.Point(461, 290);
            this.btnAddYiFu.Margin = new System.Windows.Forms.Padding(8);
            this.btnAddYiFu.Name = "btnAddYiFu";
            this.btnAddYiFu.Size = new System.Drawing.Size(156, 33);
            this.btnAddYiFu.TabIndex = 113;
            this.btnAddYiFu.Text = "添加";
            this.btnAddYiFu.UseVisualStyleBackColor = true;
            this.btnAddYiFu.Click += new System.EventHandler(this.btnAddYiFu_Click);
            // 
            // btnShouKuan
            // 
            this.btnShouKuan.Location = new System.Drawing.Point(178, 590);
            this.btnShouKuan.Margin = new System.Windows.Forms.Padding(8);
            this.btnShouKuan.Name = "btnShouKuan";
            this.btnShouKuan.Size = new System.Drawing.Size(132, 45);
            this.btnShouKuan.TabIndex = 112;
            this.btnShouKuan.Text = "收款";
            this.btnShouKuan.UseVisualStyleBackColor = true;
            this.btnShouKuan.Click += new System.EventHandler(this.btnShouKuan_Click);
            // 
            // btnKaiDan
            // 
            this.btnKaiDan.Location = new System.Drawing.Point(30, 590);
            this.btnKaiDan.Margin = new System.Windows.Forms.Padding(8);
            this.btnKaiDan.Name = "btnKaiDan";
            this.btnKaiDan.Size = new System.Drawing.Size(132, 45);
            this.btnKaiDan.TabIndex = 111;
            this.btnKaiDan.Text = "开单";
            this.btnKaiDan.UseVisualStyleBackColor = true;
            this.btnKaiDan.Click += new System.EventHandler(this.btnKaiDan_Click);
            // 
            // btnPreMoney
            // 
            this.btnPreMoney.Location = new System.Drawing.Point(770, 590);
            this.btnPreMoney.Margin = new System.Windows.Forms.Padding(8);
            this.btnPreMoney.Name = "btnPreMoney";
            this.btnPreMoney.Size = new System.Drawing.Size(132, 45);
            this.btnPreMoney.TabIndex = 110;
            this.btnPreMoney.Text = "预览收款单";
            this.btnPreMoney.UseVisualStyleBackColor = true;
            this.btnPreMoney.Click += new System.EventHandler(this.btnPreMoney_Click);
            // 
            // btnPrintMoney
            // 
            this.btnPrintMoney.Location = new System.Drawing.Point(326, 590);
            this.btnPrintMoney.Margin = new System.Windows.Forms.Padding(8);
            this.btnPrintMoney.Name = "btnPrintMoney";
            this.btnPrintMoney.Size = new System.Drawing.Size(132, 45);
            this.btnPrintMoney.TabIndex = 109;
            this.btnPrintMoney.Text = "打印收款单";
            this.btnPrintMoney.UseVisualStyleBackColor = true;
            this.btnPrintMoney.Click += new System.EventHandler(this.btnPrintMoney_Click);
            // 
            // btnPreView
            // 
            this.btnPreView.Location = new System.Drawing.Point(622, 590);
            this.btnPreView.Margin = new System.Windows.Forms.Padding(8);
            this.btnPreView.Name = "btnPreView";
            this.btnPreView.Size = new System.Drawing.Size(132, 45);
            this.btnPreView.TabIndex = 108;
            this.btnPreView.Text = "预览取衣单";
            this.btnPreView.UseVisualStyleBackColor = true;
            this.btnPreView.Click += new System.EventHandler(this.btnPreView_Click);
            // 
            // btnNexTicket
            // 
            this.btnNexTicket.Location = new System.Drawing.Point(474, 590);
            this.btnNexTicket.Margin = new System.Windows.Forms.Padding(8);
            this.btnNexTicket.Name = "btnNexTicket";
            this.btnNexTicket.Size = new System.Drawing.Size(132, 45);
            this.btnNexTicket.TabIndex = 107;
            this.btnNexTicket.Text = "打印取衣单";
            this.btnNexTicket.UseVisualStyleBackColor = true;
            this.btnNexTicket.Click += new System.EventHandler(this.btnNexTicket_Click);
            // 
            // lbxYiFu
            // 
            this.lbxYiFu.FormattingEnabled = true;
            this.lbxYiFu.ItemHeight = 19;
            this.lbxYiFu.Location = new System.Drawing.Point(30, 290);
            this.lbxYiFu.Margin = new System.Windows.Forms.Padding(5);
            this.lbxYiFu.Name = "lbxYiFu";
            this.lbxYiFu.Size = new System.Drawing.Size(418, 270);
            this.lbxYiFu.TabIndex = 106;
            // 
            // ShouYiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 662);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDeleteYiFu);
            this.Controls.Add(this.btnAddYiFu);
            this.Controls.Add(this.btnShouKuan);
            this.Controls.Add(this.btnKaiDan);
            this.Controls.Add(this.btnPreMoney);
            this.Controls.Add(this.btnPrintMoney);
            this.Controls.Add(this.btnPreView);
            this.Controls.Add(this.btnNexTicket);
            this.Controls.Add(this.lbxYiFu);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbxZheKou);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbxMoneyState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtThisMoney);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.联系方式);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxPutWay);
            this.Controls.Add(this.datePutIn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datePutOut);
            this.Controls.Add(this.btnUserID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtTicketID);
            this.Font = new System.Drawing.Font("宋体", 14F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ShouYiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "洗衣单";
            this.Load += new System.EventHandler(this.ShouYiForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbxZheKou;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxMoneyState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtThisMoney;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label 联系方式;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxPutWay;
        private System.Windows.Forms.DateTimePicker datePutIn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datePutOut;
        private System.Windows.Forms.Button btnUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtTicketID;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDeleteYiFu;
        private System.Windows.Forms.Button btnAddYiFu;
        private System.Windows.Forms.Button btnShouKuan;
        private System.Windows.Forms.Button btnKaiDan;
        private System.Windows.Forms.Button btnPreMoney;
        private System.Windows.Forms.Button btnPrintMoney;
        private System.Windows.Forms.Button btnPreView;
        private System.Windows.Forms.Button btnNexTicket;
        private System.Windows.Forms.ListBox lbxYiFu;

    }
}