using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qiniu.RSF;

namespace Whats.Cloud.QiniuFileManager.ConsoleClient
{
    class Program
    {
        const string ACCESS_KEY = "d__z80SkcAJ5DQJKEGKrnJ3dqI-zt6QehAMUUXkr";
        const string SECRET_KEY = "xzlotG1VWSR41v0wB9t9L4oFotvphcsvYiVX6u17";
        static void Main(string[] args)
        {
            while(true)
            {
                var current = Console.ReadLine();
                //list <bucket>
                //download <bucket> <key>
                string[] lineDatas = current.Split(' ');
                switch(lineDatas[0])
                {
                    case "list":
                        RSFClient rsf = new RSFClient(lineDatas[1]);
                        DumpRet ret = rsf.ListPrefix(lineDatas[1]);
                        if(ret!=null)
                            foreach (var item in ret.Items)
                            {

                            }
                        break;
                }
            }
        }
    }
}
