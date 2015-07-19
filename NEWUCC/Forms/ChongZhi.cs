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
    public partial class ChongZhi : Form
    {
        public ChongZhi()
        {
            InitializeComponent();
        }
        public void Bind(string userID)
        {
            this.txtUserID.Text = userID;
        }
        private void btnUserID_Click(object sender, EventArgs e)
        {
            DataOperator dop = new DataOperator(UccRuntime.SqlConfig);
            User user = new User();
            user.UserID = this.txtUserID.Text;
            user = dop.SelectSingle(user) as User;
            this.txtUserName.Text = user.UserName;
            this.txtMoney.Text = user.Money.ToString();
        }

        private void btnChongZhi_Click(object sender, EventArgs e)
        {
            DataOperator dop = new DataOperator(UccRuntime.SqlConfig);
            User user = new User();
            user.UserID = this.txtUserID.Text;
            user = dop.SelectSingle(user) as User;
            
            double shishou = 0;
            if (double.TryParse(this.txtShiShou.Text, out shishou))
                user.Money += shishou;
            double zengsong = 0;
            if (double.TryParse(this.txtZengSong.Text, out zengsong))
                user.Money += zengsong;
            //user.Money = double.Parse(this.txtMoney.Text) + double.Parse(this.txtShiShou.Text) + int.Parse(this.txtZengSong.Text);
            dop.Update(user);

            MoneyHistory history = new MoneyHistory();
            history.UserID = this.txtUserID.Text;
            history.UserName = this.txtUserName.Text;
            history.MoneyID = "M" + DateTime.Now.ToString("yyyyMMdd") + dop.Count<MoneyHistory>();
            history.MoneyTime = DateTime.Now;
            history.ShiShouMoney = shishou;
            history.ZengSongMoney = zengsong;
            dop.Insert(history);
            dop.Commit();

            MessageBox.Show("操作成功！");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Printer print = new Printer();
            print.Print(GetMoneyLines(), false);
        }
        List<PrintLine> GetMoneyLines()
        {
            List<PrintLine> lines = new List<PrintLine>();

            lines.Add(new PrintLine("美国UCC国际洗衣", 6, StringAlignment.Center));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("收款凭据", 12, StringAlignment.Center));
            lines.Add(new PrintLine("交易类型：会员卡充值", 6));
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("充值金额：" + this.txtShiShou.Text + "元", 8));
            lines.Add(new PrintLine("赠送金额：" + this.txtZengSong.Text + "元", 8));
            lines.Add(new PrintLine("实际充入：" + this.txtShiShou.Text + "元", 8));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("实际收款：" + this.txtShiShou.Text + "元", 14));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("顾客签字：_____________", 8));
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("充值前卡上余额：" + this.txtMoney.Text + "元", 8));
            lines.Add(new PrintLine("收款时间：" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm"), 8));

            return lines;
        }

        private void btnPreView_Click(object sender, EventArgs e)
        {
            Printer print = new Printer();
            print.PreView(GetMoneyLines(), false);
        }
    }
}
