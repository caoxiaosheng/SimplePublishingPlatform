using System.IO;
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
            string repertoryNamePath = Server.MapPath(repertoryName.GetRepertoryNamePath());
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
            result = new { success = true, reason = "你真棒" };
            return Json(result);
        }
    }
}