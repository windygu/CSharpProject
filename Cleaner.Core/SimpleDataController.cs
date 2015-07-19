using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace Cleaner.Core
{
    public class SimpleDataController
    {
        const char EOF = (char)0;
        
        public static DataTable Get(string dataPath)
        {
            DataTable dt = new DataTable("dt");
            StreamReader sr = new StreamReader(dataPath, Encoding.Default);
            string current = sr.ReadLine();

            while (true)
            {
                if (string.IsNullOrEmpty(current))
                    break;
                if (current.StartsWith("\r") || current.StartsWith("\n"))
                {
                    current = sr.ReadLine();
                    continue;
                }
                if (current == EOF.ToString())
                    break;

                if (current.StartsWith("#"))
                {
                    string header = current.Replace("#", "");
                    string[] array = header.Split('|');
                    foreach (var item in array)
                    {
                        dt.Columns.Add(item);
                    }
                    current = sr.ReadLine();
                    continue;
                }
                
                string[] data = current.Split('|');
                dt.Rows.Add(data);

                current = sr.ReadLine();
            }
            return dt;
        }
    }
}
