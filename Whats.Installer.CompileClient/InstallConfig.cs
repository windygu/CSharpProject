using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Whats.Installer.CompileClient
{
    public class InstallConfig
    {
        public string InstallDir { get; set; }
        public string DataDir { get; set; }
        public string DataBackupDir { get; set; }
        public string LinkName { get; set; }
        public string LinkTitle { get; set; }
        public string AppName { get; set; }
        public string AppTitle { get; set; }
    }
}
