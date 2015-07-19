using System;
using System.Web;
using Roo.Data;

namespace FreeRoo
{
    public class RuntimeInfo
    {
        [DataField(Description = "服务器名：")]
        public string MACHINE_NAME { get; set; }
        [DataField(Description = "IP")]
        public string LOCAL_ADDR { get; set; }
        [DataField(Description = "域名")]
        public string SERVER_NAME { get; set; }
        [DataField(Description = "端口")]
        public string SERVER_PORT { get; set; }
        [DataField(Description = "时间")]
        public string TIME_NOW { get; set; }
        [DataField(Description = "语言")]
        public string LANGUAGE { get; set; }
        [DataField(Description = "CPU数量")]
        public string NUMBER_OF_PROCESSORS { get; set; }
        [DataField(Description = "CPU架构")]
        public string PROCESSOR_ARCHITECTURE { get; set; }
        [DataField(Description = "操作系统")]
        public string OS_VERSION { get; set; }
        [DataField(Description = ".NET版本")]
        public string NET_VERSION { get; set; }
        [DataField(Description = "用户名")]
        public string USER_NAME { get; set; }
        [DataField(Description = "系统目录")]
        public string SYS_DIR { get; set; }
        [DataField(Description = "临时目录")]
        public string SYS_TEMP { get; set; }
        [DataField(Description = "内存占用")]
        public string MEMORY { get; set; }
        [DataField(Description = "所在域")]
        public string USER_DOMAIN { get; set; }
        [DataField(Description = "SSL")]
        public string SSL { get; set; }
        [DataField(Description = "CGI")]
        public string CGI { get; set; }
        [DataField(Description = "服务器软件")]
        public string SERVER_SOFTWARE { get; set; }
        [DataField(Description = "脚本超时")]
        public string SCRIPT_TIMEOUT { get; set; }
        [DataField(Description = "系统运行时间")]
        public string RUNNINT_TIME { get; set; }
        [DataField(Description = "程序所在目录")]
        public string APP_PHYSICAL_PATH { get; set; }
        [DataField(Description = "当前程序所在路径")]
        public string PATH_TRANSLATED { get; set; }

        public RuntimeInfo()
        {
            this.MACHINE_NAME = HttpContext.Current.Server.MachineName;
            this.LOCAL_ADDR = HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"];
            this.SERVER_NAME = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            this.SERVER_PORT = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            this.TIME_NOW = DateTime.Now.ToString();
            this.LANGUAGE = HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
            this.NUMBER_OF_PROCESSORS = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");
            this.PROCESSOR_ARCHITECTURE = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            this.OS_VERSION = Environment.OSVersion.ToString();
            this.NET_VERSION = ".NET CLR " + Environment.Version.ToString();

            this.USER_NAME = Environment.UserName;
            this.SYS_DIR = Environment.GetEnvironmentVariable("windir");
            this.SYS_TEMP = Environment.GetEnvironmentVariable("TEMP");
            this.MEMORY = (Environment.WorkingSet / 1024 / 1024).ToString() + " MB";
            this.USER_DOMAIN = Environment.GetEnvironmentVariable("USERDOMAIN");


            this.SSL = HttpContext.Current.Request.ServerVariables["HTTPS"];
            this.CGI = HttpContext.Current.Request.ServerVariables["GATEWAY_INTERFACE"];
            this.SERVER_SOFTWARE = HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"];
            this.SCRIPT_TIMEOUT = HttpContext.Current.Server.ScriptTimeout.ToString();
            this.RUNNINT_TIME = Math.Round((decimal)(Environment.TickCount / 600 / 60)) / 100 + " 小时";
            this.APP_PHYSICAL_PATH = HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
            this.PATH_TRANSLATED = HttpContext.Current.Request.ServerVariables["PATH_TRANSLATED"];

        }
    }
}