using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roo.Data;

namespace FreeRoo.Controllers
{
    public class ArticleTagController : Controller
    {
        //
        // GET: /ArticleTag/

        public ActionResult Index()
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            List<ArticleTag> list = new List<ArticleTag>();
            list = dop.Select<ArticleTag>();
            return View(list);
        }
        public ActionResult DoUpdate(string Tags)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            string[] array = Tags.Split(',');
            List<ArticleTag> list = new List<ArticleTag>();
            foreach(var item in array)
            {
                ArticleTag tag = new ArticleTag();
                tag.TagName = item;
                tag.TagTitle = item;
                if (dop.SelectSingle(tag) == null)
                    dop.Update<ArticleTag>(tag);
            }
            return Redirect("/Admin/Success.do");
        }
    }
}
