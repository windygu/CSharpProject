using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roo.Data;
using Whats.Cloud;

namespace Whats.Cloud.Web.Controllers
{
    public class DataBackupController : Controller
    {
        //
        // GET: /DataBackup/
        public ActionResult Index()
        {
            return View();
        }
        SqlConfig config = new SqlConfig(DataDriverType.Sqlite, "Data_", "", "~/App_Data/db.db");
        public ActionResult Backup(string store, string name)
        {
            
            DataOperator dop = new DataOperator(config);
            BackUpInfo info = new BackUpInfo();
            info.BackUpID = Roo.Utils.StringBuilderHelper.GenerateStringID();
            info.BackUpTime = DateTime.Now;
            info.FileName = name;
            info.StoreName = store;
            dop.Insert(info);
            dop.Commit();
            OperateMessage m = new OperateMessage(true, "操作成功！");
            return Json(m, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLatest(string store)
        {
            DataOperator dop = new DataOperator(config);
            var result = dop.Select<BackUpInfo>(new BackUpInfo(), "", "BackUpTime DESC", 1, 0);
            if (result != null && result.Count > 0)
            {
                var latest = result[0];
                return Content(latest.FileName);
            }
            return Content("");
        }
    }
}