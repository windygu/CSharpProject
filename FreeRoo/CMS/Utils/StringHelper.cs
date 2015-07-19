using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FreeRoo
{
    /// <summary>
    /// 字符串操作类
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// 移除文本中的所有Html标签
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveHtmlTag(string input)
        {
            return RemoveHtmlTag(input, "<.*?>");
        }
        public static string RemoveHtmlTag(string input, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.Replace(input, "");
        }
        public static string SubString(string input,int start,int length)
        {
            if (input.Length > length)
                return input.Substring(start, length);
            else
                return input;
        }
    }
}
