using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Whats.UI.WinForm
{
    public class UIDataGridView : UIControl
    {
        private UIDataGridViewItem _SelectedItem;
        public UIDataGridViewItem SelectedItem { get { return this._SelectedItem; } }

        private List<UIDataGridViewItem> _SelectedItems = new List<UIDataGridViewItem>();
        public List<UIDataGridViewItem> SelectedItems { get { return this._SelectedItems; } }

        private bool _SelectMode = false;
        public bool SelectMode
        {
            get
            {
                return _SelectMode;
            }
            set
            {
                _SelectMode = value;
                for (int i = 0; i < this._Items.Count; i++)
                {
                    this._Items[i].SelectMode = this._SelectMode;
                }
            }
        }

        private int _ItemHeight = 30;
        public int ItemHeight
        {
            get
            {
                return this._ItemHeight;
            }
            set
            {
                this._ItemHeight = value;
                for (int i = 0; i < this._Items.Count; i++)
                {
                    this._Items[i].Height = value;
                }
            }
        }
        private int _HeaderHeight = 30;
        public int HeaderHeight
        {
            get
            {
                return this._HeaderHeight;
            }
            set
            {
                this._HeaderHeight = value;
                for (int i = 0; i < this._Header.Count; i++)
                {
                    this._Header[i].Height = value;
                }
            }
        }

        private List<UIDataGridViewItem> _Items = new List<UIDataGridViewItem>();
        public List<UIDataGridViewItem> Items { get { return this._Items; } }


        private List<UIDataGridViewHeader> _Header = new List<UIDataGridViewHeader>();
        public List<UIDataGridViewHeader> Header { get { return _Header; } }

        public UIDataGridView()
        {
            this.Size = new Size(200, 200);
            this.SelectMode = false;
        }
        public void AddHeader(string text)
        {
            UIDataGridViewHeader header = new UIDataGridViewHeader(text);
            this._Header.Add(header);
            this.Controls.Add(header);
        }
        public void AddItem(UIDataGridViewItem item)
        {
            this._Items.Add(item);
            this.Controls.Add(item);
            if (this._SelectMode)
                this._SelectedItems.Add(item);
            else
                this._SelectedItem = item;
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            RenderSize();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            RenderSize();
        }
        public void RenderSize()
        {
            if (this._Header.Count <= 0)
                return;
            int headerWidth = this.Width / this._Header.Count;
            for (int i = 0; i < this._Header.Count; i++)
            {
                var item = this._Header[i];
                item.Width = headerWidth;
                item.Left = i * headerWidth;
                item.Top = 0;
            }
            for (int i = 0; i < this._Items.Count; i++)
            {
                var item = this.Controls[i];
                item.Height = this.ItemHeight;
                item.Width = this.Width;
                item.Left = 0;
                item.Top = this.HeaderHeight + i * this.ItemHeight;
            }
        }
    }
}
