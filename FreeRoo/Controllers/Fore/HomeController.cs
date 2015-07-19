using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roo.Data;

namespace FreeRoo.Controllers
{
    [PerformanceActionAttributeFilter(Message = "controller")] 
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [PerformanceActionAttributeFilter(Message = "action")] 
        public ActionResult Index()
        {
            return View();
        }
        [PerformanceActionAttributeFilter(Message = "action")] 
        public ActionResult Category(string categoryName)
        {
            return View();
        }
        [PerformanceActionAttributeFilter(Message = "action")]
        public ActionResult Article(string categoryName, string articleName)
        {
            DataOperator dop = new DataOperator(Runtime.SqlConfig);
            Article item = new FreeRoo.Article();
            item.AName = articleName;
            item = dop.SelectSingle(item) as Article;
            return View(item);
        }
    }
}
