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
    public partial class ShouYiForm : Form
    {
        public ShouYiForm()
        {
            InitializeComponent();
        }
        List<YiFu> YiFuList = new List<YiFu>();
        ShouYi Ticket = new ShouYi();

        public ShouYi GetTicket()
        {
            var ticket = new ShouYi();
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
            ticket.ZheKou = double.Parse(this.cbxZheKou.SelectedItem.ToString());
            return ticket;
        }
        public List<YiFu> GetYiFuList()
        {
            return this.YiFuList;
        }
        public void Bind(ShouYi data)
        {
            this.txtTicketID.Text = data.TicketID;
            this.datePutIn.Text = data.ShouYiDateTime.ToString("yyyy年MM月dd日");
            this.datePutOut.Text = data.QuYiDateTime.ToString("yyyy年MM月dd日");
            this.cbxMoneyState.Text = data.MoneyState;
            this.cbxPutWay.Text = data.PutWay;
            this.txtThisMoney.Text = data.Price;
            
            User user = new User();
            if(!string.IsNullOrEmpty(data.UserID))
            {
                user.UserID = data.UserID;
                user = UccRuntime.Dop.SelectSingle(user) as User;
                this.txtUserID.Text = user.UserID;
                this.txtUserName.Text = user.UserName;
                this.txtAddress.Text = user.Address;
                this.txtMoney.Text = user.Money.ToString();
                this.txtPhone.Text = user.PhoneNo;
            }
            else
            {
                this.txtUserName.Text = data.UserName;
                this.txtAddress.Text = data.Address;
                this.txtPhone.Text = data.PhoneNo;
            }
            

            YiFuList = new List<YiFu>();
            YiFu yifu = new YiFu();
            yifu.TicketID = data.TicketID;
            YiFuList = UccRuntime.Dop.Select(yifu, "", "", 0, 0);
            foreach (var item in YiFuList)
            {
                this.lbxYiFu.Items.Add(item.ClotheID.PadRight(30) + item.ClotheType);
            }
        }

        private void ShouYiForm_Load(object sender, EventArgs e)
        {
            this.txtTicketID.Text = "T" + DateTime.Now.ToString("yyyyMMdd") + 
                UccRuntime.Dop.Count<ShouYi>();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Ticket = new ShouYi();
                Ticket.TicketID = this.txtTicketID.Text;

                Ticket = UccRuntime.Dop.SelectSingle(Ticket) as ShouYi;
                if (Ticket == null)
                {
                    MessageBox.Show("取衣单填写错误！");
                    return;
                }
                this.Bind(Ticket);
            }
            catch(Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message);
            }
        }
        private void btnAddYiFu_Click(object sender, EventArgs e)
        {
            YiFuForm.Result = null;
            YiFuForm form = new YiFuForm();
            form.Index = this.lbxYiFu.Items.Count + 1;
            form.ShowDialog();
            if (YiFuForm.Result == null)
                return;
            if (string.IsNullOrEmpty(YiFuForm.Result.Price))
                return;
            
            YiFuForm.Result.TicketID = this.txtTicketID.Text;
            YiFu temp = new YiFu();
            temp = YiFuForm.Result;
            YiFuList.Add(temp);
            YiFuForm.Result = null;
            lbxYiFu.Items.Add(temp.ClotheType);

            this.txtThisMoney.Text = GetMoney(GetTicket(), this.YiFuList).ToString();
        }

        private void btnDeleteYiFu_Click(object sender, EventArgs e)
        {
            try
            {
                this.YiFuList.RemoveAt(this.lbxYiFu.SelectedIndex);
                this.lbxYiFu.Items.RemoveAt(this.lbxYiFu.SelectedIndex);
                this.txtThisMoney.Text = GetMoney(GetTicket(), GetYiFuList()).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("请选择要删除的衣服！");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                YiFuForm.Result = null;
                YiFuForm form = new YiFuForm();
                var data = this.YiFuList[this.lbxYiFu.SelectedIndex];
                form.Bind(data);
                
                form.ShowDialog();
                this.txtThisMoney.Text = GetMoney(GetTicket(), GetYiFuList()).ToString();
            }
            catch { }
        }
        private void btnKaiDan_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(var item in GetYiFuList())
                {
                    foreach(var tempItem in GetYiFuList())
                    {
                        if (tempItem != item && item.ClotheID == tempItem.ClotheID)
                        {
                            MessageBox.Show("衣服里面有重复的衣服单号！请检查一下！衣服单号：" + item.ClotheID);
                            return;
                        }
                    }
                }
                DataOperator dop = new DataOperator(UccRuntime.SqlConfig);

                if (Ticket == null)
                    Ticket = new ShouYi();
                Ticket.TicketID = this.txtTicketID.Text;
                var temp = dop.SelectSingle(Ticket) as ShouYi;
                if (temp != null)
                {
                    MessageBox.Show("此单号已经开过！请重新开单！");
                    return;
                }
                
                Ticket.UserID = this.txtUserID.Text;
                Ticket.UserName = this.txtUserName.Text;
                Ticket.PhoneNo = this.txtPhone.Text;
                Ticket.Address = this.txtAddress.Text;
                Ticket.PutWay = this.cbxPutWay.SelectedItem.ToString();
                Ticket.Price = this.txtThisMoney.Text;
                Ticket.State = "未洗";
                Ticket.MoneyState = this.cbxMoneyState.Text;
                Ticket.ShouYiDateTime = DateTime.Parse(this.datePutIn.Text);
                Ticket.QuYiDateTime = DateTime.Parse(this.datePutOut.Text);
                Ticket.ZheKou = double.Parse(this.cbxZheKou.Text);
                dop.Insert(Ticket);

                for (int i = 0; i < this.YiFuList.Count; i++)
                {
                    var item = this.YiFuList[i];
                    item.ClotheID = item.TicketID + "-" + (i + 1);
                    dop.Insert(item);
                }
                dop.Commit();
                MessageBox.Show("操作成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message + ex.StackTrace);
            }
        }
        public double GetMoney(ShouYi ticket, List<YiFu> yiFuList)
        {
            double sum = 0;
            double dazhe = 0;
            foreach (var item in yiFuList)
            {
                YiFuPriceType pinpai = new YiFuPriceType();
                pinpai.YiFuName = item.ClotheType;
                pinpai = UccRuntime.Dop.SelectSingle(pinpai) as YiFuPriceType;
                if (pinpai.IsZheKou > 0)
                    dazhe += double.Parse(item.Price);
                else
                    sum += double.Parse(item.Price);
            }
            return sum + dazhe * 0.1 * ticket.ZheKou;
        }
        private void btnShouKuan_Click(object sender, EventArgs e)
        {
            try
            {
                MoneyHistory history = new MoneyHistory();
                history.MoneyID = "M" + DateTime.Now.ToString("yyyyMMdd") + UccRuntime.Dop.Count<MoneyHistory>();
                history.Money = string.IsNullOrEmpty(this.txtMoney.Text) ? 0 : -double.Parse(this.txtThisMoney.Text);
                history.MoneyTime = DateTime.Now;
                
                User user = new User();
                if (!string.IsNullOrEmpty(this.txtUserID.Text))
                {
                    user.UserID = this.txtUserID.Text;
                    user = UccRuntime.Dop.SelectSingle(user) as User;
                    history.BeforeMoney = user.Money;
                    history.UserID = user.UserID;
                    history.UserName = user.UserName;
                    user.Money += history.Money;
                }
                else
                {
                    user.UserName = this.txtUserName.Text;
                }

                Ticket.TicketID = this.txtTicketID.Text;
                Ticket = UccRuntime.Dop.SelectSingle(Ticket) as ShouYi;
                Ticket.MoneyState = "已付";
                this.cbxMoneyState.Text = "已付";

                UccRuntime.Dop.Insert(history);
                
                if (user != null)
                    UccRuntime.Dop.Update(user);

                UccRuntime.Dop.Update(Ticket);
                MessageBox.Show("操作成功！");
            }
            catch(Exception ex)
            {
                MessageBox.Show("操作失败！"+ex.Message);
            }
        }

        private void btnPrintMoney_Click(object sender, EventArgs e)
        {
            try
            {
                Printer printer = new Printer();
                var lines =PrintHelper.GetMoneyLines(GetTicket(),GetYiFuList());
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
                var lines = PrintHelper.GetTicketLines(GetTicket(), GetYiFuList());
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
            var lines = PrintHelper.GetMoneyLines(GetTicket(), GetYiFuList());
            printer.PreView(lines, false);
        }
        private void btnPreView_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer();
            var temp_ticket=GetTicket();
            var temp_YiFuList=GetYiFuList();
            var lines = PrintHelper.GetTicketLines(temp_ticket, temp_YiFuList);
            printer.PreView(lines);
        }

        private void btnUserID_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserID = this.txtUserID.Text;
            user = UccRuntime.Dop.SelectSingle(user) as User;
            this.txtAddress.Text = user.Address;
            this.txtUserName.Text = user.UserName;
            this.txtPhone.Text = user.PhoneNo;
            this.txtMoney.Text = user.Money.ToString();
        }

        private void cbxZheKou_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtThisMoney.Text = GetMoney(GetTicket(), GetYiFuList()).ToString();
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
