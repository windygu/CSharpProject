using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whats.Updater
{
    public class UpdateDescription
    {
        public int Version { get; set; }
        public List<VersionDescription> Descriptions { get; set; }
    }
}
