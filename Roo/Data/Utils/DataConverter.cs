using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Roo.Data
{
    public class DataConverter
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string json)
        {
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(json);
            JsonTextReader reader=new JsonTextReader(tr);
            return serializer.Deserialize<T>(reader);
        }
        /// <summary>
        /// 渲染json
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string RenderJson(string json)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(json);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return json;
            }     
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjectToJson(object o)
        {
            JsonSerializer serializer = new JsonSerializer();
            StringWriter sw = new StringWriter();
            JsonTextWriter jtr = new JsonTextWriter(sw);
            serializer.Serialize(jtr, o);
            return sw.ToString();
        }

        public static string ObjectPropertyToContent(object o,
            string format = "#{PropertyDescription}<br>\r\n#{PropertyValue}\r\n")
        {
            StringBuilder sb = new StringBuilder();
            var properties = o.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.GetCustomAttributes(typeof(DataFieldAttribute), false).Length > 0)
                {
                    var attribute = property.GetCustomAttributes(typeof(DataFieldAttribute), false)[0] as DataFieldAttribute;
                    string temp = format;
                    temp = temp.Replace("#{PropertyName}", property.Name);
                    temp = temp.Replace("#{PropertyDescription}", attribute.Description);
                    temp = temp.Replace("#{PropertyValue}", property.GetValue(o, null).ToString());
                    sb.Append(temp);
                }
            }
            return sb.ToString();
        }
        public static string ObjectFieldToContent(object o,
            string format = "<tr><td>#{FieldDescription}</td><td>#{FieldValue}</td></tr>")
        {
            StringBuilder sb = new StringBuilder();
            var fields = o.GetType().GetFields();

            foreach (var item in fields)
            {
                if (item.GetCustomAttributes(typeof(DataFieldAttribute), false).Length > 0)
                {
                    var attribute = item.GetCustomAttributes(typeof(DataFieldAttribute), false)[0] as DataFieldAttribute;
                    string temp = format;
                    temp = temp.Replace("#{FieldName}", item.Name);
                    temp = temp.Replace("#{FieldDescription}", attribute.Description);
                    temp = temp.Replace("#{FieldValue}", item.GetValue(o).ToString());
                    sb.Append(temp);
                }
            }
            return sb.ToString();
        }
    }
}
