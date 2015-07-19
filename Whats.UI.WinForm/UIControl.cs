using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Whats.UI.WinForm
{
    public class UIControl : Control
    {
        public UIControl()
        {
            SetStyles();
            this.BackColor = Color.FromArgb(238, 238, 242);
        }
        void SetStyles()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
    }
}
