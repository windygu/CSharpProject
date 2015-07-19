using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FreeRoo
{
    /// <summary>
    /// 系统接口函数
    /// </summary>
    public class SystemTool
    {
        /// <summary>
        /// 系统是否安装
        /// </summary>
        /// <returns></returns>
        public static bool HasInstalled
        {
            get
            {
                return File.Exists(AppDomain.CurrentDomain.BaseDirectory
                + SystemCoreStrings.FILE_CORE_INSTALL_LOCK);
            }
        }

        /// <summary>
        /// 校验Function的参数
        /// </summary>
        /// <param name="functionName">函数名</param>
        /// <param name="count">期待的数量（正确的数量）</param>
        /// <param name="args">实际参数数组</param>
        /// <returns></returns>
        public static bool CheckArgs(string functionName, int count, object[] args)
        {
            if (count != args.Length)
                throw new Exception("函数参数数量不符合" + functionName);
            else
                return true;
        }
        
    }
}
