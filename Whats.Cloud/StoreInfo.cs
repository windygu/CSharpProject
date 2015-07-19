using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whats.Cloud
{
    public class StoreInfo
    {
        public StoreInfo()
        {
            this.Name = "ucc_jinping";
            this.Address = "上海市闵行区金平路19号";
            this.Phone = "13761561263";
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
