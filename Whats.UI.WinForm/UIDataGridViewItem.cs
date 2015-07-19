using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whats.UI.WinForm
{
    public class UIDataGridViewItem : UIControl
    {
        private List<UIDataGridViewCell> _Cols;
        public List<UIDataGridViewCell> Cols
        {
            get
            {
                return this._Cols;
            }
        }
        public void AddCol(UIDataGridViewCell col)
        {
            this._Cols.Add(col);
            this.Controls.Add(col);
        }
        public bool SelectMode { get; set; }
        public UIDataGridViewItem()
        {
            this.SelectMode = false;
            this._Cols = new List<UIDataGridViewCell>();
        }
        public event EventHandler Editing;
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.IsEditing = true;
            foreach(var item in this._Cols)
            {
                item.IsEditing = true;
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
                if (Editing != null)
                    Editing(this, new EventArgs());
            }
        }
    }
}
