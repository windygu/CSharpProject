using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Whats.UI.WinForm
{
    public class UIDataGridViewCell : UIControl
    {
        private UIDataGridViewInputBox _InputBox;
        public UIDataGridViewCell(string text)
        {
            this.Text = text;
            this.Dock = DockStyle.Fill;
            this.Controls.Add(_InputBox);
            this._InputBox = new UIDataGridViewInputBox();
            this._InputBox.SelectButtonClick += _InputBox_SelectButtonClick;
        }
        public UIDataGridViewCell()
        {
            this.Dock = DockStyle.Fill;
            this.Controls.Add(_InputBox);
            this._InputBox = new UIDataGridViewInputBox();
            this._InputBox.SelectButtonClick += _InputBox_SelectButtonClick;
        }

        void _InputBox_SelectButtonClick(object sender, EventArgs e)
        {
            if (Editing != null)
                Editing(this, new EventArgs());
        }
        public event EventHandler Editing;
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this._InputBox.Text = value;
            }
        }
        private bool _IsEditing = false;
        public bool IsEditing
        {
            get
            {
                return this._IsEditing;
            }
            set
            {
                this._IsEditing = value;
                if (value)
                    this._InputBox.Visible = true;
                else
                    this._InputBox.Visible = false;
            }
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
