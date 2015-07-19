using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roo.Utils
{
    public class ProductionInfo
    {
        public Version Version { get; set; }
        public string Name { get; set; }
        public string Home { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public ProductionInfo()
        {
            this.Name = "Roo";
            this.Home = "FreeRoo.com";
            this.Author = "Roo";
            this.Description = "Roo.ProductionInfo";
            this.Version = new Version(1, 0, 0);
        }
        public ProductionInfo(string name,string author,string home,string description)
        {
            this.Name = name;
            this.Author = author;
            this.Home = home;
            this.Description = description;
        }
    }
}
