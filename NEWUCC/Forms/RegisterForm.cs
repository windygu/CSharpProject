using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cleaner;
using Cleaner.Core;
using Roo.Data;

namespace NEWUCC
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Roo.Data.DataOperator dop = new Roo.Data.DataOperator(UccRuntime.SqlConfig);
            User user = new User();
            user.UserID = this.txtUserID.Text;
            user.UserName = this.txtUserName.Text;
            user.PhoneNo = this.txtPhone.Text;
            user.Address = this.txtAddress.Text;
            user.Sex = this.cbxSex.SelectedItem.ToString();
            user.Money = double.Parse(this.cbxMoney.Text) + double.Parse(this.txtZengSong.Text);
            user.Score = (int)user.Money;

            MoneyHistory history = new MoneyHistory();
            history.MoneyID = "M" + DateTime.Now.ToString("yyyyMMdd") + dop.Count<MoneyHistory>();
            history.BeforeMoney = 0;
            history.Money = user.Money;
            history.ZengSongMoney = double.Parse(this.txtZengSong.Text);
            history.UserID = user.UserID;
            history.UserName = user.UserName;
            history.ShiShouMoney = double.Parse(this.cbxMoney.Text);

            dop.Insert(user);
            dop.Insert(history);
            dop.Commit();

            MessageBox.Show("注册成功");
        }

        private void cbxMoney_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = Cleaner.Core.SimpleDataController.Get(AppDomain.CurrentDomain.BaseDirectory + "/data/register_money.txt");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (this.cbxMoney.SelectedItem.ToString() == table.Rows[i][0].ToString())
                    this.txtZengSong.Text = table.Rows[i][1].ToString();
            }
        }
        List<PrintLine> GetUserMoneyLines()
        {
            DataOperator dop = new DataOperator(UccRuntime.SqlConfig);
            List<PrintLine> lines = new List<PrintLine>();

            lines.Add(new PrintLine("美国UCC国际洗衣", 6, StringAlignment.Center));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("收款凭据", 12, StringAlignment.Center));
            lines.Add(new PrintLine("收款单号：" + "M" + DateTime.Now.ToString("yyyyMMdd") + dop.Count<MoneyHistory>(), 8, StringAlignment.Center));
            lines.Add(new PrintLine("收款类型：开通会员", 8));

            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("充值金额：" + this.cbxMoney.Text + "元", 8));
            lines.Add(new PrintLine("赠送金额：" + this.txtZengSong.Text + "元", 6));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("实际应收：" + this.cbxMoney.Text + "元", 14));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("卡内余额：" + (double.Parse(this.txtZengSong.Text) + double.Parse(this.cbxMoney.Text)) + "元", 14));
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("顾客姓名：" + this.txtUserName.Text, 8));
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("收款时间：" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm"), 8));

            return lines;
        }
        List<PrintLine> GetMoneyLines()
        {
            DataOperator dop = new DataOperator(UccRuntime.SqlConfig);
            List<PrintLine> lines = new List<PrintLine>();

            lines.Add(new PrintLine("美国UCC国际洗衣", 6, StringAlignment.Center));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("收款凭据", 12, StringAlignment.Center));
            lines.Add(new PrintLine("收款单号：" + "M" + DateTime.Now.ToString("yyyyMMdd") + dop.Count<MoneyHistory>(), 8, StringAlignment.Center));
            lines.Add(new PrintLine("收款类型：开通会员", 8));

            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("充值金额：" + this.cbxMoney.Text + "元", 8));
            lines.Add(new PrintLine("赠送金额：" + this.txtZengSong.Text + "元", 6));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("实际应收：" + this.cbxMoney.Text + "元", 14));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("卡内余额：" + (double.Parse(this.txtZengSong.Text) + double.Parse(this.cbxMoney.Text)) + "元", 14));
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("顾客签字：_____________", 8));
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("收款时间：" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm"), 8));

            return lines;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Printer printer = new Printer();
                var lines = GetMoneyLines();

                printer.Print(lines, false);
                printer.Print(GetUserMoneyLines(), false);
            }
            catch
            {
                MessageBox.Show("操作失败！");
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            var table = Cleaner.Core.SimpleDataController.Get(AppDomain.CurrentDomain.BaseDirectory + "/data/register_money.txt");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                this.cbxMoney.Items.Add(table.Rows[i][0].ToString());
            }
        }

    }
}
