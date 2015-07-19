using System.Web.Mvc;
using System;

namespace FreeRoo.Controllers
{
    public class SiteEditorController : Controller
    {
        public ActionResult Index()
        {
            return View(TemplateDataHelper.GetSiteInfo());
        }
        public ActionResult SetSite(SiteInfo siteInfo)
        {
            Runtime.SiteInfo = siteInfo;
            Runtime.SiteInfo.Save();
            return Content("操作成功！");
        }
    }
}
