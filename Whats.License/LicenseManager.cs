using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roo.Data;
using Roo.Security;

namespace Whats.License
{
    public class LicenseManager
    {
        private const string PUBLIC_KEY = "CLEANER1";
        public static License Create(string certificate)
        {
            return Create(certificate, GetSecretKey());
        }
        public static string DeCreate(string license)
        {
            return DeCreate(license, GetSecretKey());
        }
        public static License Create(string certificate,string secretKey)
        {
            License license = new License();
            license.Key = Encryptor.DesEncrypt(certificate, PUBLIC_KEY, secretKey);
            return license;
        }
        public static string DeCreate(string license, string secretKey)
        {
            string key = PUBLIC_KEY + "_" + secretKey;
            string result = Encryptor.DesDecrypt(license, PUBLIC_KEY, secretKey);
            return result;
        }
        public static void Save(License license, string phone)
        {
            string keyPath = AppDomain.CurrentDomain.BaseDirectory + "config/key.license";
            string phoneJsonPath = AppDomain.CurrentDomain.BaseDirectory + "config/phone.no";

            FileInfo fileInfo = new FileInfo(keyPath);
            if (!fileInfo.Directory.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);
            File.WriteAllText(keyPath, DataConverter.RenderJson(DataConverter.ObjectToJson(license)), Encoding.Default);

            File.WriteAllText(phoneJsonPath, phone, Encoding.Default);
        }
        public static bool Register(string license, string phone)
        {
            try
            {
                Save(new License { Key = license }, phone);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string GetSecretKey()
        {
            return "FREEROO1";
        }
        public enum RegisterType
        {
            None,
            Free,
            Certificate
        }
        public static bool CheckRegister(string license,string phone)
        {
            try
            {
                if (DeCreate(license) == phone)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsRegister()
        {
            string keyPath = AppDomain.CurrentDomain.BaseDirectory + "config/key.license";
            if(File.Exists(keyPath))
            {
                string phoneJsonPath = AppDomain.CurrentDomain.BaseDirectory + "config/phone.no";
                if(File.Exists(phoneJsonPath))
                {
                    string phone = File.ReadAllText(phoneJsonPath, Encoding.Default);
                    if (DeCreate(File.ReadAllText(keyPath, Encoding.Default)) == phone)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
