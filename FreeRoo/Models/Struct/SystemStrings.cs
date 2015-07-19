using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeRoo
{
    public class SystemStrings
    {
        //目录路径
        public string DIR_PRIVATE { get; set; }
        public string DIR_PRIVATE_CACHE { get; set; }
        public string DIR_PRIVATE_DATA { get; set; }
        public string DIR_PRIVATE_FILE { get; set; }
        public string DIR_PRIVATE_DOWNLOAD { get; set; }
        public string DIR_PRIVATE_UPLOAD { get; set; }
        public string DIR_PRIVATE_PLUGIN { get; set; }
        public string DIR_PRIVATE_TEMPLATE { get; set; }
        public string DIR_PRIVATE_TEMPLATE_FORE_CURRENT { get; set; }
        public string DIR_PRIVATE_TEMPLATE_FORE_DEFAULT { get; set; }
        public string DIR_PRIVATE_TEMPLATE_SYSTEM { get; set; }
        public string DIR_PUBLIC { get; set; }
        public string DIR_PUBLIC_BOOTSTRAP { get; set; }
        public string DIR_PUBLIC_BOOTSTRAP_CSS { get; set; }
        public string DIR_PUBLIC_CSS { get; set; }
        public string DIR_PUBLIC_IMAGE { get; set; }
        public string DIR_PUBLIC_JS { get; set; }

        //文件路径
        public string FILE_PUBLIC_JS_JQUERY { get; set; }
        public string FILE_PUBLIC_BOOTSTRAP_CSS { get; set; }
        public string FILE_PUBLIC_BOOTSTRAP_JS { get; set; }

        
        //值
        public string VALUE_DATA_PREFIX { get; set; }


        public SystemStrings()
        {
            
        }

    }
}
