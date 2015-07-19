using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roo.Data;

namespace FreeRoo.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/

        public ActionResult Index(string sql)
        {
            if(string.IsNullOrEmpty(sql))
            {
                ViewBag.Sql = "";
            }
            else
            {
                try
                {
                    DataOperator dop = new DataOperator(Runtime.SqlConfig);
                    dop.DataDriver.ExecuteNonQuery(sql);
                    ViewBag.Sql = sql;
                    ViewBag.Message = "操作成功！";
                }
                catch(Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }
    }
}
