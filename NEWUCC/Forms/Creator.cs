using System;
using System.IO;
using System.Windows.Forms;
using Cleaner.Core;
using Roo.Data;

namespace NewUCCDataCreator
{
    public partial class Creator : Form
    {
        public Creator()
        {
            InitializeComponent();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string path = UccRuntime.SqlConfig.DataBasePath.Replace("~", AppDomain.CurrentDomain.BaseDirectory);
            if (File.Exists(path))
                File.Delete(path);
            DataOperator dop = new DataOperator(UccRuntime.SqlConfig);

            dop.CreateTable<User>();
            dop.CreateTable<YiFu>();
            dop.CreateTable<ShouYi>();
            dop.CreateTable<MoneyHistory>();


            dop.CreateTable<XiaCi>();
            dop.CreateTable<YanSe>();
            dop.CreateTable<PinPai>();
            dop.CreateTable<YiFuPriceType>();
            dop.CreateTable<ChongZhiType>();

            dop.Commit();

            //xiace
            var table= SimpleDataController.Get(AppDomain.CurrentDomain.BaseDirectory + "/data/clothes_error.txt");
            for(int i=0;i<table.Rows.Count;i++)
            {
                XiaCi item = new XiaCi();
                item.XiaCiID = dop.Count<XiaCi>().ToString();
                item.XiaCiContent = table.Rows[i][1].ToString();
                dop.Insert(item);
                dop.Commit();
            }
            table = SimpleDataController.Get(AppDomain.CurrentDomain.BaseDirectory + "/data/clothes_color.txt");
            for(int i=0;i<table.Rows.Count;i++)
            {
                YanSe item = new YanSe();
                item.YanSeID = dop.Count<YanSe>().ToString();
                item.YanSeName = table.Rows[i][1].ToString();
                dop.Insert(item);
                dop.Commit();
            }
            table = SimpleDataController.Get(AppDomain.CurrentDomain.BaseDirectory + "/data/clothes_pinpai.txt");
            for(int i=0;i<table.Rows.Count;i++)
            {
                PinPai item = new PinPai();
                item.PinPaiID = dop.Count<PinPai>().ToString();
                item.PinPaiName = table.Rows[i][0].ToString();
                dop.Insert(item);
                dop.Commit();
            }
            table = SimpleDataController.Get(AppDomain.CurrentDomain.BaseDirectory + "/data/clothes.txt");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                YiFuPriceType item = new YiFuPriceType();
                item.YiFuPriceID = dop.Count<YiFuPriceType>().ToString();
                item.YiFuName = table.Rows[i][1].ToString();
                item.DanWei = table.Rows[i][2].ToString();
                item.Price = table.Rows[i][3].ToString();
                dop.Insert(item);
                dop.Commit();
            }
            table = SimpleDataController.Get(AppDomain.CurrentDomain.BaseDirectory + "/data/register_money.txt");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                ChongZhiType item = new ChongZhiType();
                item.ChonZhiMoney = double.Parse(table.Rows[i][0].ToString());
                item.ZengSongMoney = double.Parse(table.Rows[i][1].ToString());
                dop.Insert(item);
                dop.Commit();
            }
            dop.Commit();
            MessageBox.Show("操作成功！");
        }
    }
}
