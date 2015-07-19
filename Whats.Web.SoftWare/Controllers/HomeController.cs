using System.Text;
using System.Web.Mvc;
using Roo.Utils;
using Whats.Web.SoftWare.Models;
using Roo.Data;
using System;

namespace Whats.Web.SoftWare.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Message(ContactMessage m)
        {
            SqlConfig config = new SqlConfig(DataDriverType.Sqlite, "SoftWare_", "", "~/App_Data/db.db");
            DataOperator dop = new DataOperator(config);
            
            try
            {
                m.CMID = DateTime.Now.ToString("yyyyMMdd") + dop.Count<ContactMessage>();
                dop.Insert(m);
                dop.Commit();
                ViewBag.Message = "操作成功！我们的业务员会及时的联系您！";
            }
            catch
            {
                ViewBag.Message = "操作失败！试试换种方式和我们联系吧！";
            }
            return View();
        }
        public ActionResult Price()
        {
            return View();
        }
    }
}
