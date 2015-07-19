using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roo.Utils
{
    public class Version
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Last { get; set; }
        /// <summary>
        /// 第一个参数表示主版本号，第二个表示更新的功能版本号，第三个表示细节更新版本号
        /// </summary>
        /// <param name="first"></param>
        /// <param name="sec"></param>
        /// <param name="last"></param>
        public Version(int first, int sec, int last)
        {
            this.First = first;
            this.Second = sec;
            this.Last = last;
        }
        public int ToInt()
        {
            return int.Parse(this.First.ToString() + this.Second.ToString() + this.Last.ToString());
        }
    }
}
