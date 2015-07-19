using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roo.Data;

namespace Whats.Updater
{
    public class UpdateConfig
    {
        public string Domain { get; set; }
        public string RemoteUrl { get; set; }
        public string LocalDir { get; set; }
        public static UpdateConfig FromeFile(string path)
        {
            return DataConverter.JsonToObject<UpdateConfig>(File.ReadAllText(path, Encoding.UTF8));
        }
        public void Save(string path)
        {
            File.WriteAllText(path, DataConverter.RenderJson(DataConverter.ObjectToJson(this)), Encoding.UTF8);
        }
    }
}
