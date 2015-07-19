using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeRoo
{
    /// <summary>
    /// 静态文件生成器
    /// </summary>
    public class HtmlCreator
    {
        public HtmlCreator()
        {

        }

        /// <summary>
        /// 创建静态文件，已知文件名，文件内容，所在栏目
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Content"></param>
        /// <param name="category"></param>
        public void Create(string name,string Content,Category category)
        {

        }
        /// <summary>
        /// 创建静态文件，为目录页面文件，一直目录和内容
        /// </summary>
        /// <param name="category"></param>
        /// <param name="Content"></param>
        public void Create(Category category,string Content)
        {

        }
        /// <summary>
        /// 创建静态文件，已知路径和内容
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Content"></param>
        public void Create(string path,string Content)
        {
            System.IO.File.WriteAllText(path, Content,Encoding.Default);
        }
        /// <summary>
        /// 新建一个静态文件生成器
        /// </summary>
        /// <returns></returns>
        public static HtmlCreator Create()
        {
            return new HtmlCreator();
        }
    }
}
