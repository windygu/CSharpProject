using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Qiniu.IO;
using Qiniu.RS;
using System.Web;
using System.Net;
using System.IO;
using Qiniu.RSF;

namespace Cleaner.Core
{
     public class QiNiuBackupHelper
    {
         public static string Domain = "http://7xja01.com1.z0.glb.clouddn.com";
         public static string Bucket = "cleaner-backup";
         public static string Server = "http://data.freeroo.xyz";
         //public static string Server = "http://localhost:17669";
         static QiNiuBackupHelper()
         {
             Qiniu.Conf.Config.ACCESS_KEY = "d__z80SkcAJ5DQJKEGKrnJ3dqI-zt6QehAMUUXkr";
             Qiniu.Conf.Config.SECRET_KEY = "xzlotG1VWSR41v0wB9t9L4oFotvphcsvYiVX6u17";
         }
         public static void Backup()
         {
             var policy = new PutPolicy(Bucket, 3600);
             string upToken = policy.Token();
             PutExtra extra = new PutExtra();
             IOClient client = new IOClient();

             string name = "db_" + System.Environment.MachineName + "_" +
                 Roo.Utils.StringBuilderHelper.GenerateStringID() + ".dbb";

             PutRet ret = client.PutFile(upToken, name, Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "/CleanerData/db.db", extra);

             //WebRequest request = WebRequest.Create(Server + "/DataBackup/Backup?store=" + System.Environment.MachineName + "&name=" + name);
             //WebResponse response = request.GetResponse();
             //StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
             //string json = reader.ReadToEnd();
             //BackUpInfo info = Roo.Data.DataConverter.JsonToObject<BackUpInfo>(json);
             //response.Close();
         }
         public static void Restore()
         {
             //WebRequest request = WebRequest.Create(Server + "/DataBackup/GetLatest?store=" + System.Environment.MachineName);
             
             //WebResponse response = request.GetResponse();
             //Stream stream = response.GetResponseStream();
             //StreamReader reader = new StreamReader(stream, Encoding.UTF8);
             //string url = reader.ReadToEnd();
             //WebClient client = new WebClient();
             //string local = AppDomain.CurrentDomain.BaseDirectory + "db.db";
             //if (File.Exists(local))
             //    File.Delete(local);
             //client.DownloadFile(url, local);
             //response.Close();
         }
    }
}
