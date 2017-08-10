using System;
using System.IO;
using System.Threading;
using System.Web.Mvc;
using SimplePublishingPlatform.Extensions;

namespace SimplePublishingPlatform.Controllers
{
    public class PublishController : Controller
    {
        // GET: Publish
        public ActionResult Index(string repertoryName)
        {
            ViewBag.RepertoryName = repertoryName;
            return View("Index");
        }

        [HttpPost]
        public ActionResult Add(string repertoryName)
        {
            string repertoryNamePath = repertoryName.GetRepertoryNameMapPath(Server);
            object result;
            if (Directory.Exists(repertoryNamePath))
            {
                result = new { success = false, reason = "仓库名已存在" };
            }
            else
            {
                Directory.CreateDirectory(repertoryNamePath);
                result = new { success = true, reason = "你真棒" };
            }
            return Json(result);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult PublishVersion()
        {
            var repertoryName = Request["repertoryName"];
            var description = Request["description"];
            var detail = Request["detail"];
            object result;
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(repertoryName.GetDetailHtmlFilePath(Server), false))
                {
                    streamWriter.Write(detail);
                }
                result = new { success = true, reason = "你真棒" };
            }
            catch (Exception e)
            {
                result = new { success = false, reason = "存储文件错误，"+ e.Message};
            }
            return Json(result);
        }
    }
}