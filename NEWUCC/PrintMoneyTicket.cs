using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cleaner.Core;

namespace Cleaner
{
    public partial class PrintMoneyTicket : Form
    {
        public PrintMoneyTicket()
        {
            InitializeComponent();
        }

        private void btnOkUserID_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.UserID = this.txtUserID.Text;
            u = UccRuntime.Dop.SelectSingle(u) as User;
            if(u==null)
            {
                MessageBox.Show("用户不存在！请检查输入会员卡号是否正确！");
                return;
            }
            this.txtRestMoney.Text = u.Money.ToString();
        }

        private void txtDoMoney_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.UserID = this.txtUserID.Text;
            u = UccRuntime.Dop.SelectSingle(u) as User;
            u.Money = u.Money - double.Parse(this.txtTicketMoney.Text);

            MoneyHistory history = new MoneyHistory();
            history.Money = -double.Parse(this.txtTicketMoney.Text);
            history.MoneyID = "M" + DateTime.Now.ToString("yyyyMMdd") + UccRuntime.Dop.Count<MoneyHistory>();
            history.ShiShouMoney = history.Money;
            history.UserID = this.txtUserID.Text;
            history.UserName = u.UserName;
            history.BeiZhu = this.txtTicketID.Text;
            history.MoneyTime = DateTime.Now;

            UccRuntime.Dop.Update(u);
            UccRuntime.Dop.Insert(history);
            UccRuntime.Dop.Commit();
            MessageBox.Show("收款成功！");
        }

        private void txtPrint_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer();
            printer.Print(GetMoneyLines());
        }
        List<PrintLine> GetMoneyLines()
        {
            List<PrintLine> lines = new List<PrintLine>();

            lines.Add(new PrintLine("美国UCC国际洗衣", 6, StringAlignment.Center));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("收款凭据", 12, StringAlignment.Center));
            lines.Add(new PrintLine("收费事由：" + this.txtReason.Text, 8));
            lines.Add(new PrintLine("收衣单号:" + this.txtTicketID.Text, 8));
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("收费金额：" + this.txtTicketMoney.Text + "元", 8));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("顾客签字：_____________", 8));
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("余额：" + (double.Parse(this.txtRestMoney.Text) - double.Parse(this.txtTicketMoney.Text)) + "元", 8));
            lines.Add(new PrintLine("收款时间：" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm"), 8));

            return lines;
        }
        private void PrintMoneyTicket_Load(object sender, EventArgs e)
        {

        }
    }
}
