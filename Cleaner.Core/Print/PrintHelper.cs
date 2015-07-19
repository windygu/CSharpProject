using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Cleaner.Core
{
    public class PrintHelper
    {
        public static List<PrintLine> GetMoneyLines(ShouYi ticket,List<YiFu> YiFuList)
        {
            List<PrintLine> lines = new List<PrintLine>();

            lines.Add(new PrintLine("美国UCC国际洗衣", 6, StringAlignment.Center));
            lines.Add(new PrintLine("----------------------------------------", 8));
            lines.Add(new PrintLine("收款凭据", 12, StringAlignment.Center));
            lines.Add(new PrintLine("收款单号：" + "M" + DateTime.Now.ToString("yyyyMMdd") + UccRuntime.Dop.Count<MoneyHistory>(), 12, StringAlignment.Center));
            lines.Add(new PrintLine("衣物件数：" + YiFuList.Count, 10));

            lines.Add(new PrintLine("========================================", 10));
            lines.Add(new PrintLine("编号    衣物    价格    颜色    品牌    ", 8));
            lines.Add(new PrintLine("========================================", 10));

            double sumMoney = 0;
            for(int i=0;i<YiFuList.Count;i++)
            {
                sumMoney += double.Parse(YiFuList[i].Price);
            }

            double price = 0;
            for (int i = 0; i < YiFuList.Count; i++)
            {
                price = double.Parse(ticket.Price);

                lines.Add(new PrintLine(YiFuList[i].ClotheID + " " + YiFuList[i].ClotheType + " " + YiFuList[i].Price + " " + YiFuList[i].Color + " " + YiFuList[i].PinPai, 8));
                string xiaci = YiFuList[i].XiaCi;
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
            lines.Add(new PrintLine("交易总额：" + sumMoney + "元", 8));
            lines.Add(new PrintLine("折扣：" + ticket.ZheKou + "折", 8));
            lines.Add(new PrintLine("仿皮、皮草、地毯、单烫等不打折", 8));

            lines.Add(new PrintLine("------------------------------------------", 8));
            lines.Add(new PrintLine("实际应收：" + ticket.Price, 14));
            lines.Add(new PrintLine("------------------------------------------", 8));
            lines.Add(new PrintLine("                                        ", 8));
            lines.Add(new PrintLine("顾客签字：_____________", 8));
            lines.Add(new PrintLine("                                        ", 8));
            if (!string.IsNullOrEmpty(ticket.UserID))
            {
                User user = new User();
                user.UserID = ticket.UserID;
                user = UccRuntime.Dop.SelectSingle(user) as User;

                lines.Add(new PrintLine("卡上余额：" + user.Money + "元", 12));
            }
            lines.Add(new PrintLine("收款时间：" + DateTime.Now.ToString("yyyy年MM月dd日 HH:mm"), 8));

            return lines;
        }

        public static List<PrintLine> GetTicketLines(ShouYi ticket,List<YiFu> YiFuList)
        {
            List<PrintLine> lines = new List<PrintLine>();

            lines.Add(new PrintLine("美国UCC国际洗衣", 6, StringAlignment.Center));
            lines.Add(new PrintLine("--------------------------------------------------", 8));
            lines.Add(new PrintLine("取衣凭据", 12, StringAlignment.Center));
            lines.Add(new PrintLine("取衣单号：" + ticket.TicketID, 12));
            lines.Add(new PrintLine("取衣时间：" + ticket.QuYiDateTime.ToString("yyyy年MM月dd日"), 10));
            lines.Add(new PrintLine("收衣时间：" + ticket.ShouYiDateTime.ToString("yyyy年MM月dd日"), 10));
            lines.Add(new PrintLine("衣物件数：" + YiFuList.Count, 10));
            lines.Add(new PrintLine("--------------------------------------------------", 10));
            lines.Add(new PrintLine("顾客签字：_____________", 12));
            lines.Add(new PrintLine("==================================================", 10));
            lines.Add(new PrintLine("编号    衣物    价格    颜色    品牌    ", 8));
            lines.Add(new PrintLine("==================================================", 8));


            double sumMoney = 0;
            for (int i = 0; i < YiFuList.Count; i++)
            {
                sumMoney += double.Parse(YiFuList[i].Price);
            }

            double price = 0;
            for (int i = 0; i < YiFuList.Count; i++)
            {
                price = double.Parse(ticket.Price);

                lines.Add(new PrintLine(YiFuList[i].ClotheID + " " + YiFuList[i].ClotheType + " " + YiFuList[i].Price + " " + YiFuList[i].Color + " " + YiFuList[i].PinPai, 8));
                string xiaci = YiFuList[i].XiaCi;
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
            lines.Add(new PrintLine("交易总额：" + sumMoney + "元", 10));
            lines.Add(new PrintLine("折扣：" + ticket.ZheKou + "折", 10));
            lines.Add(new PrintLine("--------------------------------------------------", 8));
            lines.Add(new PrintLine("实际应收：" + ticket.Price, 14));
            lines.Add(new PrintLine("付款状态：" + ticket.MoneyState, 10));
            lines.Add(new PrintLine("                                        ", 8));
            if (!string.IsNullOrEmpty(ticket.UserID))
            {
                User user = new User();
                user.UserID = ticket.UserID;
                user = UccRuntime.Dop.SelectSingle(user) as User;

                lines.Add(new PrintLine("卡上余额：" + user.Money + "元", 12));
            }
            
            lines.Add(new PrintLine("仿皮、皮草、地毯、单烫等不打折", 8));
            lines.Add(new PrintLine("本店地址: " + UccRuntime.StoreInfo.Address, 8));
            lines.Add(new PrintLine("服务热线：" + UccRuntime.StoreInfo.PhoneNo, 8));
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
