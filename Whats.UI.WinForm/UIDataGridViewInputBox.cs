using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Whats.UI.WinForm
{
    public class UIDataGridViewInputBox : UIControl
    {
        private UIButton rightButton;
        private TextBox textBox;
        public UIDataGridViewInputBox()
        {
            this.Dock = DockStyle.Fill;
            this.textBox = new TextBox();
            this.textBox.Multiline = true;
            this.rightButton = new UIButton();
            this.rightButton.Size = new Size(20, 20);
            this.rightButton.Click += rightButton_Click;
            this.Controls.Add(this.textBox);
            this.Controls.Add(rightButton);
        }
        public event EventHandler SelectButtonClick;
        void rightButton_Click(object sender, EventArgs e)
        {
            if (SelectButtonClick != null)
                SelectButtonClick(this, new EventArgs());
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if((this.Width-this.rightButton.Width)>0)
            rightButton.Left = this.Width - this.rightButton.Width;
            rightButton.Top = 0;
            rightButton.Height = this.Height;
            this.textBox.Width = this.Width - this.rightButton.Width;
            this.textBox.Height = this.Height;
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (SelectButtonClick != null)
                SelectButtonClick(this, new EventArgs());
        }
    }
}
