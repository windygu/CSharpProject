using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Whats.Installer.CompileClient
{
    public class Helper
    {
        public static void Kill()
        {
            int count = 3;
            while (count > 0)
            {
                try
                {
                    var cleaner = Process.GetProcessesByName("Cleaner");

                    foreach (var item in cleaner)
                    {
                        item.Kill();
                    }
                    var updater = Process.GetProcessesByName("Updater");
                    foreach (var item in updater)
                    {
                        item.Kill();
                    }
                    var dataBackuper = Process.GetProcessesByName("DataBackuper");
                    foreach (var item in dataBackuper)
                    {
                        item.Kill();
                    }

                }
                catch { }
                count--;
            }
        }
    }
}
