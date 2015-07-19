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
    public partial class QuYiForm : Form
    {
        public QuYiForm()
        {
            InitializeComponent();
        }
        List<YiFu> list = new List<YiFu>();
        private void ShouYiForm_Load(object sender, EventArgs e)
        {
            DataOperator dop = new DataOperator(UccRuntime.SqlConfig);
            this.txtTicketID.Text = "T" + DateTime.Now.ToString("yyyyMMdd") + dop.Count<ShouYi>();
        }
        
        private void btnTianJia_Click(object sender, EventArgs e)
        {
            YiFuForm form = new YiFuForm();
            form.ShowDialog();
            this.list.Add(YiFuForm.Result);
            this.lbxYiFu.Items.Add(YiFuForm.Result.ClotheID+"|" +YiFuForm.Result.ClotheType);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.lbxYiFu.Items.RemoveAt(this.lbxYiFu.SelectedIndex);
        }

        private void btnXiuGai_Click(object sender, EventArgs e)
        {
            YiFuForm form = new YiFuForm();
            foreach (var item in this.list)
            {
                
            }
            form.ShowDialog();
        }
        DataOperator dop = new DataOperator(UccRuntime.SqlConfig);
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ShouYi ticket = new ShouYi();
                ticket.TicketID = this.txtTicketID.Text;

                ticket = dop.SelectSingle(ticket) as ShouYi;
                if (ticket == null)
                {
                    MessageBox.Show("取衣单填写错误！");
                    return;
                }
                this.txtTicketID.Text = ticket.TicketID;
                this.txtUserID.Text = ticket.UserID;
                this.txtUserName.Text = ticket.UserName;
                this.txtThisMoney.Text = ticket.Price;
                this.txtPhone.Text = ticket.PhoneNo;
                this.txtAddress.Text = ticket.Address;
                this.cbxPutWay.Text = ticket.PutWay;
                this.txtThisMoney.Text = ticket.Price;

                YiFu item = new YiFu();
                item.TicketID = ticket.TicketID;

                User user = new User();
                user.UserID = ticket.UserID;
                user = dop.SelectSingle(user) as User;
                this.txtUserID.Text = user.UserID;
                this.txtUserName.Text = user.UserName;
                this.txtAddress.Text = user.Address;
                this.txtPhone.Text = user.PhoneNo;
                this.txtMoney.Text = user.Money.ToString();

                var list = dop.Select(item, "", "", 0, 0);
                foreach(var l in list)
                {
                    this.yifus.Add(l as YiFu);
                    this.lbxYiFu.Items.Add((l as YiFu).ClotheID + "|" + (l as YiFu).ClotheType);
                }
            }
            catch
            {
                MessageBox.Show("操作失败！");
            }
        }
        List<YiFu> yifus = new List<YiFu>();
        private void btnAddYiFu_Click(object sender, EventArgs e)
        {
            YiFuForm form = new YiFuForm();
            form.ShowDialog();
            if (YiFuForm.Result == null)
                return;
            yifus.Add(YiFuForm.Result);
            lbxYiFu.Items.Add(YiFuForm.Result.ClotheID + "|" + YiFuForm.Result.ClotheType);

            double sum = 0;
            foreach(var item in this.yifus)
            {
                double temp=0;
                double.TryParse(item.Price,out temp);
                sum += temp;
            }
            this.txtThisMoney.Text = sum.ToString();
        }

        private void btnDeleteYiFu_Click(object sender, EventArgs e)
        {
            int delete = -1;
            for (int i = 0; i < yifus.Count;i++ )
            {
                var data = this.lbxYiFu.SelectedItem.ToString().Split('|');
                if (data[0] == yifus[i].ClotheID)
                {
                    delete = i;
                }
            }
            if(delete>=0)
            {
                this.lbxYiFu.Items.RemoveAt(delete);
                this.yifus.RemoveAt(delete);
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            YiFuForm form = new YiFuForm();
            var data = this.yifus[this.lbxYiFu.SelectedIndex];
            form.Bind(data);
            form.ShowDialog();
        }

        private void btnKaiDan_Click(object sender, EventArgs e)
        {
            try
            {
                DataOperator dop = new DataOperator(UccRuntime.SqlConfig);

                for (int i = 0; i < this.yifus.Count; i++)
                {
                    var item = this.yifus[i];
                    dop.Insert(item);
                }

                ShouYi ticket = new ShouYi();
                ticket.TicketID = this.txtTicketID.Text;
                ticket.UserID = this.txtUserID.Text;
                ticket.UserName = this.txtUserName.Text;
                ticket.PhoneNo = this.txtPhone.Text;
                ticket.Address = this.txtAddress.Text;
                ticket.PutWay = this.cbxPutWay.SelectedItem.ToString();
                ticket.Price = this.txtThisMoney.Text;
                ticket.State = "未洗";
                ticket.MoneyState = this.cbxMoneyState.Text;
                ticket.ShouYiDateTime = DateTime.Parse(this.datePutIn.Text);
                ticket.QuYiDateTime = DateTime.Parse(this.datePutOut.Text);
                dop.Insert(ticket);

                if (ticket.MoneyState == "已付")
                {
                    MoneyHistory history = new MoneyHistory();
                    history.MoneyID = "M" + DateTime.Now.ToString("yyyyMMdd") + dop.Count<MoneyHistory>();
                    history.Money = double.Parse(ticket.Price);
                    history.MoneyTime = DateTime.Now;

                    User user = new User();
                    user.UserID = this.txtUserID.Text;
                    user = dop.SelectSingle(user) as User;
                    history.BeforeMoney = user.Money;
                    user.Money += double.Parse(ticket.Price);

                    dop.Insert(history);
                    dop.Update(user);
                }
                dop.Commit();
                MessageBox.Show("操作成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message);
            }
        }

        private void btnShouKuan_Click(object sender, EventArgs e)
        {
            try
            {
                MoneyHistory history = new MoneyHistory();
                history.MoneyID = "M" + DateTime.Now.ToString("yyyyMMdd") + dop.Count<MoneyHistory>();
                history.Money = string.IsNullOrEmpty(this.txtMoney.Text) ? 0 : -double.Parse(this.txtThisMoney.Text);
                history.MoneyTime = DateTime.Now;
                User user = new User();
                if (!string.IsNullOrEmpty(this.txtUserID.Text))
                {
                    user.UserID = this.txtUserID.Text;
                    user = dop.SelectSingle(user) as User;
                    history.BeforeMoney = user.Money;
                    user.Money += history.Money;
                }
                else
                {
                    user.UserName = this.txtUserName.Text;
                }
                ShouYi ticket = new ShouYi();
                ticket.TicketID = this.txtTicketID.Text;
                ticket = dop.SelectSingle(ticket) as ShouYi;
                ticket.MoneyState = "已付";
                this.cbxMoneyState.Text = "已付";

                dop.Insert(history);
                if (user != null)
                    dop.Update(user);
                dop.Update(ticket);
                MessageBox.Show("操作成功！");
            }
            catch
            {
                MessageBox.Show("操作失败！");
            }
        }

        private void btnPrintMoney_Click(object sender, EventArgs e)
        {
            try
            {
                Printer printer = new Printer();
                var lines = GetMoneyLines();
                printer.Print(lines, false);
            }
            catch
            {
                MessageBox.Show("操作失败！");
            }
        }

        private void btnNexTicket_Click(object sender, EventArgs e)
        {
            try
            {
                Printer printer = new Printer();
                var lines = GetTicketLines();
                printer.Print(lines);
            }
            catch
            {
                MessageBox.Show("操作失败！");
            }
        }

        private void btnPreMoney_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer();
            var lines = GetMoneyLines();
            printer.PreView(lines, false);
        }
        private void btnPreView_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer();
            var lines = GetTicketLines();
            printer.PreView(lines);
        }
        List<PrintLine> GetMoneyLines()
        {
            List<PrintLine> lines = new List<PrintLine>();

            lines.Add(new PrintLine("美国UCC国际洗衣", 6, StringAlignment.Center));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("收款凭据", 12, StringAlignment.Center));
            lines.Add(new PrintLine("收款单号：" + "M" + DateTime.Now.ToString("yyyyMMdd") + dop.Count<MoneyHistory>(), 12, StringAlignment.Center));
            lines.Add(new PrintLine("衣物件数：" + this.yifus.Count, 10));

            lines.Add(new PrintLine("========================================", 10));
            lines.Add(new PrintLine("编号    衣物    价格    颜色    品牌    ", 8));
            lines.Add(new PrintLine("========================================", 10));

            double price = 0;
            for (int i = 0; i < this.yifus.Count; i++)
            {
                price = double.Parse(this.txtThisMoney.Text);

                lines.Add(new PrintLine(this.yifus[i].ClotheID + " " + this.yifus[i].ClotheType + " " + this.yifus[i].Price + " " + this.yifus[i].Color + " " + this.yifus[i].PinPai, 8));
                string xiaci = this.yifus[i].XiaCi;
                string[] data = xiaci.Split(',');
                lines.Add(new PrintLine("  瑕疵：", 8));
                for (int j = 0; j < data.Length; j += 2)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int k = j; k < j + 2; k++)
                    {
                        if (k < data.Length)
                            if (!string.IsNullOrEmpty(data[k]))
                                sb.Append(data[k] + "  ");
                    }
                    lines.Add(new PrintLine("   " + sb.ToString(), 8));
                }
            }
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("交易总额：" + price + "元", 8));
            lines.Add(new PrintLine("折扣：" + this.cbxZheKou.Text + "折", 8));
            lines.Add(new PrintLine("------------------------------------------", 8));
            lines.Add(new PrintLine("实际应收：" + price * int.Parse(this.cbxZheKou.Text) * 0.1 + "元", 14));
            lines.Add(new PrintLine("------------------------------------------", 8));
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("顾客签字：_____________", 8));
            lines.Add(new PrintLine("                                        ", 8));
            if (!string.IsNullOrEmpty(this.txtUserID.Text))
                lines.Add(new PrintLine("卡上余额：" + this.txtMoney.Text + "元", 8));
            lines.Add(new PrintLine("收款时间：" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm"), 8));

            return lines;
        }

        List<PrintLine> GetTicketLines()
        {
            List<PrintLine> lines = new List<PrintLine>();

            lines.Add(new PrintLine("美国UCC国际洗衣", 6, StringAlignment.Center));
            lines.Add(new PrintLine("--------------------------------------------------", 8));
            lines.Add(new PrintLine("取衣凭据", 12, StringAlignment.Center));
            lines.Add(new PrintLine("取衣单号：" + this.txtTicketID.Text, 12));
            lines.Add(new PrintLine("取衣时间：" + this.datePutOut.Text, 10));
            lines.Add(new PrintLine("收衣时间：" + this.datePutIn.Text, 10));
            lines.Add(new PrintLine("衣物件数：" + this.yifus.Count, 10));
            lines.Add(new PrintLine("--------------------------------------------------", 10));
            lines.Add(new PrintLine("顾客签字：_____________", 12));
            lines.Add(new PrintLine("==================================================", 10));
            lines.Add(new PrintLine("编号    衣物    价格    颜色    品牌    ", 8));
            lines.Add(new PrintLine("==================================================", 8));

            double price = 0;
            for (int i = 0; i < this.yifus.Count; i++)
            {
                price = double.Parse(this.txtThisMoney.Text);

                lines.Add(new PrintLine(this.yifus[i].ClotheID + " " + this.yifus[i].ClotheType + " " + this.yifus[i].Price + " " + this.yifus[i].Color + " " + this.yifus[i].PinPai, 8));
                string xiaci = this.yifus[i].XiaCi;
                string[] data = xiaci.Split(',');
                lines.Add(new PrintLine("  瑕疵：", 8));
                for (int j = 0; j < data.Length; j += 2)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int k = j; k < j + 2; k++)
                    {
                        if (k < data.Length)
                            if (!string.IsNullOrEmpty(data[k]))
                                sb.Append(data[k] + "  ");
                    }
                    lines.Add(new PrintLine("   " + sb.ToString(), 8));
                }
            }

            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("交易总额：" + price + "元", 10));
            lines.Add(new PrintLine("折扣：" + this.cbxZheKou.Text + "折", 10));
            lines.Add(new PrintLine("--------------------------------------------------", 8));
            lines.Add(new PrintLine("实际应收：" + price * int.Parse(this.cbxZheKou.Text) * 0.1 + "元", 14));
            lines.Add(new PrintLine("付款状态：" + this.cbxMoneyState.Text, 10));
            lines.Add(new PrintLine("                                        ", 8));
            if (!string.IsNullOrEmpty(this.txtUserID.Text))
                lines.Add(new PrintLine("卡上余额：" + this.txtMoney.Text + "元", 12));
            lines.Add(new PrintLine("本店地址: 闵行区金平路19号近鹤庆路", 8));
            lines.Add(new PrintLine("服务热线：13761561263", 8));
            lines.Add(new PrintLine("打印日期：" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm"), 8));
            lines.Add(new PrintLine("==================================================", 8));
            lines.Add(new PrintLine("凭单取衣", 8, StringAlignment.Center));
            lines.Add(new PrintLine("欢迎您的光临", 8, StringAlignment.Center));
            lines.Add(new PrintLine("衣服出门本店概不负责", 8, StringAlignment.Center));
            lines.Add(new PrintLine("保管期超过一个月另收保管费", 8, StringAlignment.Center));
            lines.Add(new PrintLine("关注本店官方微信，获取更多优惠资讯", 8, StringAlignment.Center));

            return lines;
        }
    }
}
