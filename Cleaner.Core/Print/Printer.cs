using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cleaner.Core
{
    public class Printer
    {
        public List<PrintLine> Lines;      //打印内容行
        private bool HasQRCode = true;
        public void Print(List<PrintLine> lines, bool hasQRCode = true)
        {
            this.HasQRCode = hasQRCode;
            if (!this.HasQRCode)
                this.PageHeight = 350;
            this.Lines = lines;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += pd_PrintPage;
            //设置边距

            Margins margin = new Margins(20, 20, 20, 20);

            pd.DefaultPageSettings.Margins = margin;
            //纸张设置默认
            PaperSize pageSize = new PaperSize("自定义纸张", 228, (int)MessureHeight(lines) + 150);
            pd.DefaultPageSettings.PaperSize = pageSize;

            pd.Print();
        }
        public float MessureHeight(List<PrintLine> lines)
        {
            float height = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                Graphics e = Graphics.FromImage(new Bitmap(1, 1));
                SizeF s = e.MeasureString(line.Line, new Font("宋体", line.FontSize));
                height += s.Height;
            }
            return height;
        }
        public int PageWidth = 228;
        public int PageHeight = 600;
        public void PreView(List<PrintLine> lines, bool hasQRCode = true)
        {
            this.HasQRCode = hasQRCode;
            if (!this.HasQRCode)
                this.PageHeight = 350;
            this.Lines = lines;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += pd_PrintPage;
            //设置边距

            Margins margin = new Margins(10, 10, 10, 10);

            pd.DefaultPageSettings.Margins = margin;
            //纸张设置默认
            PaperSize pageSize = new PaperSize("自定义纸张", 228, (int)MessureHeight(lines) + 150);
            pd.DefaultPageSettings.PaperSize = pageSize;

            PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.Document = pd;
            dialog.ShowDialog();
        }
        public Printer()
        {

        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            int pos = 0;
            foreach (var line in this.Lines)
            {
                sf.Alignment = line.StringAlignment;
                SizeF s = e.Graphics.MeasureString(line.Line, new Font("宋体", line.FontSize));

                e.Graphics.DrawString(line.Line, new Font("宋体", line.FontSize), Brushes.Black, new RectangleF(0, pos, PageWidth, s.Height), sf);

                pos += (int)s.Height;
            }
            if (HasQRCode)
            {
                if(File.Exists( UccRuntime.StoreInfo.QRCode))
                {
                    Image qrCode = Image.FromFile(UccRuntime.StoreInfo.QRCode);
                    e.Graphics.DrawImage(qrCode, (PageWidth - 86) / 2, pos, 86, 86);
                }
            }

            //var pd = (PrintDocument)sender;
            //pd.DefaultPageSettings.PaperSize = new PaperSize("自定义纸张", 228, pos + 20);
        }
    }
}
