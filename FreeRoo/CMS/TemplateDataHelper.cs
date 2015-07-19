using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Roo.Data;

namespace FreeRoo
{
    public class TemplateDataHelper
    {
        public static List<Category> Categories { get; set; }
        public static List<ArticleTag> ArticleTags { get; set; }
        public static List<LoveLink> LoveLinks { get; set; }
        public static Dictionary<string, string> RuntimeInfo { get; set; }
        public static SiteInfo SiteInfo { get; set; }
        public static Dictionary<string,string> GetRuntimeInfo()
        {
            if (RuntimeInfo != null)
                return RuntimeInfo;

            RuntimeInfo = new Dictionary<string, string>();
            var runtime=new FreeRoo.RuntimeInfo();
            foreach (var property in runtime.GetType().GetProperties())
            {
                if (property.GetCustomAttributes(typeof(DataFieldAttribute), false).Length > 0)
                {
                    var attribute = property.GetCustomAttributes(typeof(DataFieldAttribute), false)[0] as DataFieldAttribute;
                    RuntimeInfo.Add(attribute.Description, property.GetValue(runtime).ToString());
                }

                
            }
            return RuntimeInfo;
        }
        public static SiteInfo GetSiteInfo()
        {
            if (SiteInfo != null)
                return SiteInfo;

            string path=AppDomain.CurrentDomain.BaseDirectory + "/Configs/SiteInfo.config";
            if (File.Exists(path))
                SiteInfo = DataConverter.JsonToObject<SiteInfo>(File.ReadAllText(path, Encoding.UTF8));
            else
                SiteInfo = new SiteInfo();
            return SiteInfo;
        }
        public static List<Category> GetCategories()
        {
            if (Categories != null)
                return Categories;

            List<Category> list = new List<Category>();
            Category category = new Category();
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            var result = dop.Select(category, "CategoryName<>'recycle' and CategoryName<>'root'", "", 0, 0);
            foreach (var item in result)
            {
                list.Add(item as Category);
            }

            Categories = list;
            return list;
        }
        public static Category GetCategory(string categoryName)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            Category category = new Category();
            category.CategoryName = categoryName;
            category = dop.SelectSingle(category) as Category;
            return category;
        }
        public static List<ArticleTag> GetArticleTags()
        {
            if (ArticleTags != null)
                return ArticleTags;

            List<ArticleTag> list = new List<ArticleTag>();
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            var result = dop.SelectAll(new ArticleTag());
            foreach(var item in result)
            {
                list.Add(item as ArticleTag);
            }
            ArticleTags = list;
            return list;
        }
        public static List<LoveLink> GetLoveLinks()
        {
            if (LoveLinks != null)
                return LoveLinks;

            List<LoveLink> list = new List<LoveLink>();
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            var result = dop.SelectAll(new LoveLink());
            foreach (var item in result)
            {
                list.Add(item as LoveLink);
            }
            LoveLinks = list;
            return list;
        }
        public static List<Article> GetIndexArticles()
        {
            List<Article> list = new List<Article>();
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            var result = dop.Select<Article>(new Article(), "", "ATime DESC", 10, 0);
            foreach(var item in result)
            {
                list.Add(item);
            }
            return list;
        }
        public static List<Article> GetCategoryArticles(string categoryName)
        {
            List<Article> list = new List<Article>();
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            var result = dop.Select<Article>(new Article(), "ACategoryName='" + categoryName + "'", "ATime DESC", 10, 0);
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }
        public static Article GetArticle(string articleName)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);

            Article article = dop.SelectSingle<Article>("AName='" + articleName + "'");
            return article;
        }
        public static PluginInfo GetPlugins()
        {
            PluginInfo plugin = PluginInfo.Load("~/Configs/plugins.config");
            return plugin;
        }
    }
}