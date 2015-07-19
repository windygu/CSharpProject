using System.Text;
using System.Web.Mvc;
using Roo.Utils;
using Whats.Web.SoftWare.Models;

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
            StringBuilder sb = new StringBuilder();
            sb.Append("标题：" + m.Title + "<br>");
            sb.Append("内容：" + m.Content + "<br>");
            sb.Append("Email:" + m.Email + "<br>");
            sb.Append("电话：" + m.Phone + "<br>");
            sb.Append("姓名" + m.Name + "<br>");
            if (EmailHelper.SendEmail("us@freeroo.software", m.Title, sb.ToString()))
            {
                ViewBag.Message = "操作成功！我们的业务员会及时的联系您！";
            }
            else
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
