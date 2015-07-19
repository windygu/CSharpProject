using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Whats.UI.WinForm
{
    public class UIDataGridViewHeader : UIControl
    {
        public UIDataGridViewHeader()
        {
            this.Text = "";
            this.Width = 50;
        }
        public event EventHandler Editing;
        public UIDataGridViewHeader(string text)
        {
            this.Text = text;
            this.Width = 50;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(this.Text, this.Font, Brushes.Black, this.ClientRectangle, sf);
        }
    }
}
