using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whats.UI.WinForm
{
    public class UITabControl : TabControl
    {
        #region Properties
        #endregion

        #region Initiates
        public UITabControl()
        {
            this.ItemSize = new Size(100, 50);
            setStyles();
            this.Font = new Font("宋体", 12);
        }

        #endregion

        private void setStyles()
        {
            base.SetStyle(
                 ControlStyles.UserPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor,
                 true);
            base.UpdateStyles();
        }
        #region Paint Override
        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                Rectangle ableRect = new Rectangle(this.GetTabRect(i).X, this.GetTabRect(i).Y, this.GetTabRect(i).Width - 5, this.GetTabRect(i).Height);

                if (this.SelectedIndex == i)
                    e.Graphics.DrawImage(UIResource.TabButtonBackground, this.GetTabRect(i));

                SizeF textSize
                    = e.Graphics.MeasureString(this.TabPages[i].Text, this.Font);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                e.Graphics.DrawString(
                    this.TabPages[i].Text,
                    this.Font,
                    Brushes.Black, ableRect, sf);
            }

        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            this.SelectedIndex = this.TabCount - 2;
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            this.SelectedTab = e.Control as TabPage;
            for(int i=0;i<e.Control.Controls.Count;i++)
            {
                var item = e.Control.Controls[i];
                item.Dock = DockStyle.Fill;
            }
        }
        #endregion
    }
}
