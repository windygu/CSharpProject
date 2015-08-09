using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cleaner.Core;
using Roo.Data;
using Whats.Core;

namespace NEWUCC
{
    public partial class YiFuForm : Form
    {
        public static YiFu Result = null;
        public int Index = 1;
        public YiFuForm()
        {
            InitializeComponent();
            this.yifuTypeList.DoubleClick += yifuTypeList_DoubleClick;
            this.Controls.Add(yifuTypeList);
            this.yifuTypeList.Hide();
            //this.txtClotheType.LostFocus += txtClotheType_LostFocus;
        }

        void txtClotheType_LostFocus(object sender, EventArgs e)
        {
            this.yifuTypeList.Hide();
        }

        void yifuTypeList_DoubleClick(object sender, EventArgs e)
        {
            this.txtClotheType.Text = this.yifuTypeList.SelectedItem.ToString();
            this.yifuTypeList.Hide();
            YiFuPriceType type=new YiFuPriceType();
            type.YiFuName=this.txtClotheType.Text;
            type = UccRuntime.Dop.SelectSingle(type) as YiFuPriceType;
            this.txtPrice.Text = type.Price;
        }
        public void Bind(YiFu yifu)
        {
            Result = new YiFu();
            Result = yifu;
            this.txtYiFuID.Text = yifu.ClotheID;
            this.txtClotheType.Text = yifu.ClotheType;
            this.txtYanSe.Text = yifu.Color;
            this.txtPinPai.Text = yifu.PinPai;
            this.txtPrice.Text = yifu.Price;
            this.txtBeiZhu.Text = yifu.BeiZhu;
            this.txtXiaCi.Text = yifu.XiaCi;
            this.yifuTypeList.Hide();
        }

        private void YiFuForm_Load(object sender, EventArgs e)
        {
            if (Result == null)
                this.txtYiFuID.Text = "T" + DateTime.Now.ToString("yyyyMMdd") +
                    UccRuntime.Dop.Count<ShouYi>() + "-" + this.Index;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            double price = 0;

            if (!double.TryParse(this.txtPrice.Text, out price))
            {
                MessageBox.Show("价格输入不正确！");
            }
            else
            {
                if (Result == null)
                    Result = new YiFu();

                Result.ClotheID = this.txtYiFuID.Text;
                Result.ClotheType = this.txtClotheType.Text;
                Result.Color = this.txtYanSe.Text;
                Result.PinPai = this.txtPinPai.Text;
                Result.Price = this.txtPrice.Text;
                Result.XiaCi = this.txtXiaCi.Text;
                Result.BeiZhu = this.txtBeiZhu.Text;
                Result.State = "未洗";
                this.Close();
            }
        }
        
        private void btnYiFuID_Click(object sender, EventArgs e)
        {
            this.txtYiFuID.Text = "T" + DateTime.Now.ToString("yyyyMMdd") +
                UccRuntime.Dop.Count<ShouYi>() + "-" + this.Index;
        }

        private void btnYanSe_Click(object sender, EventArgs e)
        {
            YiFuYanSe form = new YiFuYanSe();
            form.ShowDialog();
            this.txtYanSe.Text = YiFuYanSe.Result;
        }

        private void btnLeiXing_Click(object sender, EventArgs e)
        {
            YiFuLeiXing form = new YiFuLeiXing();
            form.ShowDialog();
            if (YiFuLeiXing.Result == null)
                return;
            this.txtClotheType.Text = YiFuLeiXing.Result.YiFuName;
            this.txtPrice.Text = YiFuLeiXing.Result.Price;
            this.yifuTypeList.Hide();
        }

        private void btnPinPai_Click(object sender, EventArgs e)
        {
            YiFuPinPai form = new YiFuPinPai();
            form.ShowDialog();
            
            this.txtPinPai.Text = YiFuPinPai.Result;
        }

        private void btnXiaCi_Click(object sender, EventArgs e)
        {
            YiFuXiaCi form = new YiFuXiaCi();
            form.Bind(this.txtXiaCi.Text);
            form.ShowDialog();
            this.txtXiaCi.Text = YiFuXiaCi.Result;
        }

        private void YiFuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        ListBox yifuTypeList = new ListBox();

        private void txtClotheType_TextChanged(object sender, EventArgs e)
        {
            yifuTypeList.Items.Clear();
            if(this.txtClotheType.Text.Length>0){
                if (!Char.IsLetter(this.txtClotheType.Text[0]))
                {
                    this.yifuTypeList.Hide();
                    return;
                }
            }
            var items = UccRuntime.Dop.SelectAll<YiFuPriceType>(new YiFuPriceType());
            
            if (items == null)
                return;
            if (items.Count > 0)
            {

                foreach (var item in items)
                {
                    var pinYin = PinYinConverter.Get(item.YiFuName).ToLower();
                    if (pinYin.StartsWith(this.txtClotheType.Text.ToLower()))
                    {
                        yifuTypeList.Items.Add(item.YiFuName);
                    }
                    else
                    {
                        pinYin = PinYinConverter.GetFirst(item.YiFuName).ToLower();
                        if (pinYin.StartsWith(this.txtClotheType.Text.ToLower()))
                            yifuTypeList.Items.Add(item.YiFuName);
                    }
                    
                }
                yifuTypeList.Location = new Point(this.txtClotheType.Location.X, this.txtClotheType.Location.Y + this.txtClotheType.Height);
                yifuTypeList.Height = this.Height / 2;
                this.yifuTypeList.Width = this.Width / 2;
                this.yifuTypeList.Show();
                yifuTypeList.BringToFront();
            }
        }

        private void txtClotheType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.PageDown)
            {
                if (this.yifuTypeList.SelectedIndex < this.yifuTypeList.Items.Count - 1)
                {
                    this.yifuTypeList.SelectedIndex = this.yifuTypeList.SelectedIndex + 1;
                }
            }
            else if(e.KeyChar==(char)Keys.Up)
            {
                if (this.yifuTypeList.SelectedIndex >= 1)
                {
                    this.yifuTypeList.SelectedIndex = this.yifuTypeList.SelectedIndex - 1;
                }
            }
        }
    }
}
