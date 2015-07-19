using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Roo.Utils
{
    public class StringBuilderHelper
    {
        public static string GenerateStringID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        public static long GenerateIntID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
        /// <summary>
        /// 合成小括号逗号组成的类似于包含两边小括号的函数参数列表
        /// </summary>
        /// <param name="args"></param>
        /// <param name="left"></param>
        /// <param name="split"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string CompressParenthesesArgs(string[] args, bool ifCRLF, bool ifTab, string left = "(", string split = ",", string right = ")")
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                if (i == 0 && i != args.Length - 1)
                    sb.Append(string.Format("{0}{1}{2}{3}", left, ifCRLF ? "\r\n" : " ", ifTab ? "\t" : " ", args[i]));
                else if (i > 0 && i != args.Length - 1)
                    sb.Append(string.Format("{0}{1}{2}{3}", split, ifCRLF ? "\r\n" : " ", ifTab ? "\t" : "", args[i]));
                else if (i > 0 && i == args.Length - 1)
                    sb.Append(string.Format("{0}{1}{2}{3}{4}{5}", split, ifCRLF ? "\r\n" : " ",
                        ifTab ? "\t" : "", args[i], ifCRLF ? "\r\n" : " ", right));
            }
            return sb.ToString();
        }

        public static string RenderSqlResult(DataSet ds)
        {
            StringBuilder sb = new StringBuilder();
            int length = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                var array = ds.Tables[0].Rows[i].ItemArray;
                string line = string.Join("\t", array);
                line.TrimEnd(' ');
                sb.Append(line + "\r\n");
                length = length < line.Length ? line.Length : length;
            }
            string result = WhiteSpace(length) + "\r\n" + sb.ToString() + WhiteSpace(length) + "\r\n";

            return result;
        }
        public static string WhiteSpace(int count)
        {
            return CopyString(" ", count);
        }
        public static string CopyString(string copy,int count)
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<count;i++)
            {
                sb.Append(copy);
            }
            return sb.ToString();
        }
    }
}
