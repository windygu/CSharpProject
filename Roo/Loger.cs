using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roo.Loger
{
    public class Loger
    {
        public static int LogSize = 5 * 1024;
        public static void Event(string m)
        {
            Log(m, LogType.Event);
        }
        public static void Error(string m)
        {
            Log(m, LogType.Error);
        }
        public static void Warning(string m)
        {
            Log(m, LogType.Warning);
        }
        public enum LogType
        {
            Error,
            Warning,
            Event
        }
        public static void Log(string m, LogType type)
        {
            try
            {
                string result = (type.ToString() + " : " + m).PadRight(50) +
                    "    Time : " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                DirectoryInfo info = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "logs");
                if (!Directory.Exists(info.FullName))
                    Directory.CreateDirectory(info.FullName);
                FileInfo current;
                var list = info.GetFiles();
                if(list.Length>0)
                {
                    current = list[0];
                    for (int i = 1; i < list.Length; i++)
                    {
                        if (list[i].CreationTime > current.CreationTime)
                        {
                            current = list[i];
                        }
                    }
                    if (current.Length >= LogSize)
                        current = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + 
                            "logs/log_" + Roo.Utils.StringBuilderHelper.GenerateStringID() + ".ini");
                }
                else
                {
                    current = new FileInfo(AppDomain.CurrentDomain.BaseDirectory +
                            "logs/log_" + Roo.Utils.StringBuilderHelper.GenerateStringID() + ".ini");
                }
                FileStream fs = new FileStream(current.FullName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                writer.WriteLine(result);
                writer.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

    }
}
