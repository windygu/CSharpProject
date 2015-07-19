using System;
using System.Web.Mvc;
using Roo.Data;
using System.Collections;
using System.Collections.Generic;

namespace FreeRoo.Controllers
{
    public class ArticleEditorController : Controller
    {
        public ActionResult Manager(string key, string pageIndex)
        {
            ViewBag.Key = key;
            ViewBag.PageIndex = pageIndex;
            List<Article> list = new List<Article>();

            key = string.IsNullOrEmpty(key) ? "" : key;
            pageIndex = string.IsNullOrEmpty(pageIndex) ? "1" : pageIndex;

            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            Article article = new Article();
            article.ATitle = key;
            list = dop.Select<Article>(article, "", "ATime DESC", 10, (int.Parse(pageIndex) - 1) * 10);

            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult Delete(string ArticleID)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            Article article = new Article();
            article.ArticleID = ArticleID;
            article = dop.SelectSingle(article) as Article;
            return View(article);
        }
        [ValidateInput(false)]
        public ActionResult Update(string ArticleID)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            Article article = new Article();
            article.ArticleID = ArticleID;
            article = dop.SelectSingle(article) as Article;
            return View(article);
        }
        public ActionResult Move(string articleIDs)
        {
            return Content("");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DoAdd(Article article)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            article.ArticleID = Guid.NewGuid().ToString();
            article.ATime = DateTime.Now;
            article.AR = 0;
            dop.Insert(article);
            dop.Commit();
            return Redirect("/Admin/Success.do");
        }
        [ValidateInput(false)]
        public ActionResult DoDelete(Article article)
        {
            article.ACategoryName = "recycle";
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            dop.Update(article);
            return Redirect("/Admin/Success.do");
        }
        [ValidateInput(false)]
        public ActionResult DoUpdate(Article article)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            article.ATime = DateTime.Now;
            dop.Update(article);
            return Redirect("/Admin/Success.do");
        }
    }
}
