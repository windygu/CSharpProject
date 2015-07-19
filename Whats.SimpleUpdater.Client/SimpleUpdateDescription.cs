using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whats.App;

namespace Whats.SimpleUpdater.Client
{
    public class SimpleUpdateDescription
    {
        public int Version { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        public SimpleUpdateDescription()
        {
            this.Version = 1;
            this.Description = "本软件的第一个版本。";
            this.FileUrl = "http://update.freeroo.xyz/" + AppRuntime.AppInfo.AppName + "/version.json";
        }
    }
}
