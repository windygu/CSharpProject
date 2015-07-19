using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whats.Updater
{
    public class VersionDescription
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string MD5 { get; set; }
        public bool IsFile { get; set; }
        public VersionType UpdateType { get; set; }
        public enum VersionType
        {
            NewVersion,
            Create,
            Delete,
            None
        }
    }
}
