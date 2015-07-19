using Roo.Data;
using System;
using System.Web.Mvc;

namespace FreeRoo.Controllers
{
    public class CategoryEditorController :Controller
    {
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Delete(string categoryName)
        {
            return View();
        }
        public ActionResult Update(string categoryName)
        {
            DataOperator dop=new DataOperator(Runtime.SqlConfig);
            Category category = new Category();
            category.CategoryName = categoryName;
            category = dop.SelectSingle(category) as Category;
            return View(category);
        }
        public ActionResult Manager()
        {
            return View();
        }
        public ActionResult DoAdd(Category category)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            dop.Insert(category);
            dop.Commit();
            TemplateDataHelper.Categories = null;
            return Redirect("/Admin/Success.do");
        }
        public ActionResult DoDelete(string categoryName)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            dop.Delete(categoryName);
            Article mArticle = new Article();
            mArticle.ACategoryName = categoryName;
            var list = dop.Select(mArticle, "", "", 10, 0);     //cms系统要改
            foreach(var item in list)
            {
                var article = item as Article;
                article.ACategoryName = "0";
                dop.Update(article);
            }
            TemplateDataHelper.Categories = null;
            return Redirect("/Admin/Success.do");
        }
        public ActionResult DoUpdate(Category category)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            dop.Update(category);
            TemplateDataHelper.Categories = null;
            return Redirect("/Admin/Success.do");
        }
    }
}
