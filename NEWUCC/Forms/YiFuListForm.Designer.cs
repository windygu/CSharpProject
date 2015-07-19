namespace NEWUCC
{
    partial class YiFuListForm
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
            this.lbxList = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYiFuID = new System.Windows.Forms.TextBox();
            this.txtTicketID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnXiHao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxList
            // 
            this.lbxList.FormattingEnabled = true;
            this.lbxList.ItemHeight = 19;
            this.lbxList.Location = new System.Drawing.Point(14, 81);
            this.lbxList.Margin = new System.Windows.Forms.Padding(5);
            this.lbxList.Name = "lbxList";
            this.lbxList.Size = new System.Drawing.Size(669, 327);
            this.lbxList.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(558, 14);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(125, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "衣物编号";
            // 
            // txtYiFuID
            // 
            this.txtYiFuID.Location = new System.Drawing.Point(103, 20);
            this.txtYiFuID.Name = "txtYiFuID";
            this.txtYiFuID.Size = new System.Drawing.Size(169, 29);
            this.txtYiFuID.TabIndex = 3;
            // 
            // txtTicketID
            // 
            this.txtTicketID.Location = new System.Drawing.Point(376, 20);
            this.txtTicketID.Name = "txtTicketID";
            this.txtTicketID.Size = new System.Drawing.Size(174, 29);
            this.txtTicketID.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "衣单编号";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(377, 420);
            this.btnView.Margin = new System.Windows.Forms.Padding(5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(125, 35);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "查看";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnXiHao
            // 
            this.btnXiHao.Location = new System.Drawing.Point(147, 420);
            this.btnXiHao.Margin = new System.Windows.Forms.Padding(5);
            this.btnXiHao.Name = "btnXiHao";
            this.btnXiHao.Size = new System.Drawing.Size(125, 35);
            this.btnXiHao.TabIndex = 7;
            this.btnXiHao.Text = "已经洗好";
            this.btnXiHao.UseVisualStyleBackColor = true;
            this.btnXiHao.Click += new System.EventHandler(this.btnXiHao_Click);
            // 
            // YiFuListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 469);
            this.Controls.Add(this.btnXiHao);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtTicketID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtYiFuID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lbxList);
            this.Font = new System.Drawing.Font("宋体", 14F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "YiFuListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "YiFuListForm";
            this.Load += new System.EventHandler(this.YiFuListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYiFuID;
        private System.Windows.Forms.TextBox txtTicketID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnXiHao;
    }
}