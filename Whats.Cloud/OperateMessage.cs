using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whats.Cloud
{
    public class OperateMessage
    {
        public bool IsSuccess { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        public OperateMessage(bool isSuccess, string content)
        {
            this.IsSuccess = IsSuccess;
            this.Content = content;
        }
    }
}
