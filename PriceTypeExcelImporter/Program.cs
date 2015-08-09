using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using Cleaner.Core;
using Roo.Data;
using Utils;

namespace PriceTypeExcelImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            string excelPath = AppDomain.CurrentDomain.BaseDirectory + "abc.xlsx";
            var conn = ExcelHelper.CreateConnection("abc.xlsx", ExcelHelper.ExcelVerion.Excel2007);
            conn.Open();
            var dt = ExcelHelper.GetWorkBookName(conn);
            
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for(int j=0;j<dt.Columns.Count;j++)
            //    {
            //        Console.Write("  " + dt.Rows[i][j].ToString() + "  ");
            //    }
            //}

            int lines = 0;
            var ds = ExcelHelper.ExecuteDataSet(conn, "SELECT * FROM  [Sheet2$]", null);
            for (int main = 0; main < ds.Tables.Count;main++ )
            {
                for (int i = 0; i < ds.Tables[main].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[main].Columns.Count; j++)
                    {
                        Console.Write("  " + ds.Tables[main].Rows[i][j].ToString() + "  ");
                    }
                    Console.WriteLine("test:"+ds.Tables[main].Rows[i][1].ToString());
                    YiFuPriceType data = new YiFuPriceType();
                    data.YiFuName = ds.Tables[main].Rows[i][0].ToString();
                    data.Price = ds.Tables[main].Rows[i][1].ToString();
                    SqlConfig config = new SqlConfig(DataDriverType.Sqlite, "UCC_", "", "~db.db");
                    DataOperator dop = new DataOperator(config);
                    //var tmp = dop.SelectSingle(data) as YiFuPriceType;
                    YiFuPriceType tmp = null;
                    if (tmp == null)
                    {
                        data.YiFuPriceID = dop.Count<YiFuPriceType>().ToString();
                        data.YiFuName = ds.Tables[main].Rows[i][0].ToString();
                        data.Cat = ds.Tables[main].Rows[i][2].ToString();
                        data.IsZheKou = int.Parse(ds.Tables[main].Rows[i][3].ToString());
                        data.Price = ds.Tables[main].Rows[i][1].ToString();
                        dop.Insert<YiFuPriceType>(data);
                        dop.Commit();
                    }
                    
                    lines++;
                    Console.WriteLine();

                }
            }
            
            Console.WriteLine("lines:" + lines);
            Console.ReadKey();
        }
        //加载Excel   
        public static DataSet LoadDataFromExcel(string filePath)
        {
            try
            {
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT * FROM  [Sheet1$]";//可是更改Sheet名称，比如sheet2，等等   

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, "Sheet1");
                OleConn.Close();
                return OleDsExcle;
            }
            catch (Exception err)
            {
                Console.WriteLine("数据绑定Excel失败!失败原因：" + err.Message);
                return null;
            }
        } 
    }
}
