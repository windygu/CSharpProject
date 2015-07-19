using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Roo.Data;

namespace Whats.Updater
{
    public class Updater
    {
        public List<string> Ignore { get; set; }
        public UpdateConfig Config { get; set; }

        WebClient client = new WebClient();
        
        public Updater()
        {
            this.Ignore = new List<string>();
            this.Ignore.Add("update");
            this.Ignore.Add("web.config");
            this.Ignore.Add("update.json");
            this.Ignore.Add("Updater.exe");
            this.Ignore.Add("db.db");
            this.Ignore.Add("Roo.dll");
            this.Ignore.Add("Whats.Updater");
            this.Ignore.Add("Newtonsoft.Json.dll");
            this.Config = new UpdateConfig();
        }
        public bool HasNewVersion
        {
            get
            {
                var localUpdateDesciption = GetLocalDescription();

                var remoteUpdateDescription = GetRemoteDescription();

                if (remoteUpdateDescription.Version > localUpdateDesciption.Version)
                    return true;
                else
                    return false;
            }

        }
        public UpdateDescription GetLocalDescription()
        {
            UpdateDescription local;
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/update/version.json"))
                local = DataConverter.JsonToObject<UpdateDescription>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/update/version.json", Encoding.Default));
            else
                local = new UpdateDescription() { Version = 0 };
            local.Descriptions = CreateLocalList();
            return local;
        }
        public void Operator(List<VersionDescription> list)
        {
            foreach (var item in list)
            {
                if (item.UpdateType == VersionDescription.VersionType.NewVersion || item.UpdateType == VersionDescription.VersionType.Create)
                {
                    string source = item.Path.Replace("~", this.Config.Domain);
                    string target = item.Path.Replace("~", AppDomain.CurrentDomain.BaseDirectory + "/update/");
                    if (item.IsFile)
                    {
                        FileInfo targetInfo = new FileInfo(target);
                        if (!Directory.Exists(targetInfo.Directory.FullName))
                            Directory.CreateDirectory(targetInfo.Directory.FullName);
                        client.DownloadFile(source, target);

                        File.Copy(target, item.Path.Replace("~", AppDomain.CurrentDomain.BaseDirectory), true);

                    }
                    else
                        Directory.CreateDirectory(item.Path.Replace("~", AppDomain.CurrentDomain.BaseDirectory));
                }
            }
        }
        public List<VersionDescription> GetUpdateList()
        {
            List<VersionDescription> list = new List<VersionDescription>();
            var remoteUpdateDescription = GetRemoteDescription();
            var localUpdateDesciption = GetLocalDescription();
            foreach (VersionDescription item in remoteUpdateDescription.Descriptions)
            {
                var localItem = FindLocal(item, localUpdateDesciption.Descriptions);
                if (localItem != null)
                {
                    if (localItem.IsFile)
                    {
                        if (localItem.MD5 != item.MD5)
                        {
                            localItem.UpdateType = VersionDescription.VersionType.NewVersion;
                            list.Add(localItem);
                        }

                    }
                }
                else
                {
                    item.UpdateType = VersionDescription.VersionType.Create;
                    list.Add(item);
                }

            }
            return list;
        }
        public VersionDescription FindRemote(VersionDescription vd, List<VersionDescription> remote)
        {
            foreach (var item in remote)
            {
                if (vd.Name == item.Name)
                    return item;
            }
            return null;
        }
        public VersionDescription FindLocal(VersionDescription vd, List<VersionDescription> local)
        {
            foreach (var item in local)
            {
                if (vd.Name == item.Name)
                    return item;
            }
            return null;
        }
        public void Update()
        {
            List<VersionDescription> list = GetUpdateList();
            this.Operator(list);
        }
        public void CreateNewVersionDescription(string path)
        {
            int version = 1;
            if (File.Exists(path))
                version = DataConverter.JsonToObject<UpdateDescription>(File.ReadAllText(path)).Version;
            
            var description = new UpdateDescription();
            description.Version = version + 1;
            description.Descriptions = this.CreateLocalList();
            FileInfo info = new FileInfo(path);
            if (!info.Directory.Exists)
                Directory.CreateDirectory(info.Directory.FullName);
            File.WriteAllText(path, DataConverter.RenderJson(DataConverter.ObjectToJson(description)), Encoding.Default);
        }
        public List<VersionDescription> CreateLocalList()
        {
            List<VersionDescription> list = new List<VersionDescription>();
            var dirInfo = new DirectoryInfo(this.Config.LocalDir);
            var fs = dirInfo.GetFileSystemInfos("*", SearchOption.AllDirectories);
            foreach (var item in fs)
            {
                bool ignore=IsIgnore(item.FullName);
                if (ignore)
                    continue;
                VersionDescription vd = new VersionDescription();
                vd.Name = item.Name;
                vd.Path = item.FullName.Replace(this.Config.LocalDir, "~");
                vd.Path = vd.Path.Replace("\\","/");
                vd.MD5 = string.IsNullOrEmpty(item.Extension) ? "" : GetMD5HashFromFile(item.FullName);
                vd.IsFile = !string.IsNullOrEmpty(item.Extension) ? true : false;
                vd.UpdateType = VersionDescription.VersionType.None;
                list.Add(vd);
            }
            return list;
        }
        public bool IsIgnore(string path)
        {
            foreach(var item in this.Ignore)
            {
                if (path.IndexOf(item) > -1)
                    return true;
            }
            return false;
        }
        public UpdateDescription GetRemoteDescription()
        {
            WebRequest request = WebRequest.Create(this.Config.RemoteUrl);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string json = reader.ReadToEnd();
            var update = DataConverter.JsonToObject<UpdateDescription>(json);
            return update;

            //var path = this.Config.RemoteUrl;
            //var localtmpPath = this.Config.LocalDir + "/update_tmp/";
            //if (Directory.Exists(localtmpPath))
            //    Directory.Delete(localtmpPath, true);
            //Directory.CreateDirectory(localtmpPath);
            //if (File.Exists(localtmpPath + "update_remote.json"))
            //    File.Delete(localtmpPath + "update_remote.json");
            //client.DownloadFile(new Uri(path), localtmpPath + "update_remote.json");
            
        }
        /// <summary>  
        /// 获取文件的MD5码  
        /// </summary>  
        /// <param name="fileName">传入的文件名（含路径及后缀名）</param>  
        /// <returns></returns>  
        public string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, System.IO.FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }
    }
}
