using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Whats.UI.WinForm
{
    public class UIListView<T> : ListView
    {
        public UIListView()
        {
            this.View = View.Details;
            this.FullRowSelect = true;
            this.Scrollable = true;
        }
        private List<T> _Data;
        public List<T> Data { get { return _Data; } }
        public void Bind(List<T> data)
        {
            this.Columns.Clear();
            this.Items.Clear();
            this.Columns.Add("序号");
            foreach (var item in data[0].GetType().GetProperties())
            {
                var attrs = item.GetCustomAttributes(false);
                if (attrs.Length > 0)
                {
                    foreach(var a in attrs)
                    {
                        bool flag = false;
                        if(a is Roo.Data.DataFieldAttribute)
                        {
                            flag = true;
                        }
                        if(flag)
                        {
                            var current = attrs[0] as Roo.Data.DataFieldAttribute;
                            this.Columns.Add(current.Description);
                        }
                        else
                        {
                            this.Columns.Add(item.Name);
                        }
                        
                    }
                    
                }
                else
                    this.Columns.Add(item.Name);
            }
            this._Data = data;
            for (int i = 0; i < data.Count; i++)
            {
                var item = data[i];
                PropertyInfo[] properties = item.GetType().GetProperties();
                ListViewItem lvi = new ListViewItem(i.ToString());
                foreach (var property in properties)
                {
                    var value = property.GetValue(item, null);
                    if (value != null)
                    {
                        if(property.PropertyType.FullName==typeof(DateTime).FullName)
                        {
                            lvi.SubItems.Add(((DateTime)value).ToString("yy年MM月dd日"));
                        }
                        else
                        {
                            lvi.SubItems.Add(value.ToString());
                        }
                    }
                    else
                        lvi.SubItems.Add("");
                }
                this.Items.Add(lvi);
            }
            for (int i = 0; i < this.Columns.Count; i++)
            {
                this.Columns[i].Width = -2;
            }
        }
        public void Bind(List<T> data, string[] name)
        {
            if (data.Count <= 0 || name.Length <= 0)
                return;
            this.Columns.Clear();
            this.Items.Clear();
            this.Columns.Add(" ");
            for (int i = 0; i < name.Length; i++)
            {
                PropertyInfo property = data[0].GetType().GetProperty(name[i]);
                if (property != null)
                {
                    var att = property.GetCustomAttributes(false)[0] as Roo.Data.DataFieldAttribute;
                    this.Columns.Add(att.Description);
                }
            }
            this._Data = data;
            for (int i = 0; i < data.Count; i++)
            {
                var item = data[i];
                PropertyInfo[] properties = item.GetType().GetProperties();
                ListViewItem lvi = new ListViewItem(i.ToString());
                foreach (var property in properties)
                {
                    foreach (var n in name)
                    {
                        if (n == property.Name)
                            lvi.SubItems.Add(property.GetValue(item, null).ToString());
                    }
                }
                this.Items.Add(lvi);
            }
            for (int i = 0; i < this.Columns.Count; i++)
            {
                this.Columns[i].Width = -2;
            }
        }
        public void Remove(int index)
        {
            this._Data.RemoveAt(index);
            this.Items.RemoveAt(index);
        }
        public T Edit(int index)
        {
            return this._Data[index];
        }
    }
}
