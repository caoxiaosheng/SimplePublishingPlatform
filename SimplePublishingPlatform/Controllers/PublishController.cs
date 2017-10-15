using System;
using System.IO;
using System.Web.Mvc;
using SimplePublishingPlatform.Extensions;
using SimplePublishingPlatform.Models;
using SimplePublishingPlatform.Services;

namespace SimplePublishingPlatform.Controllers
{
    public class PublishController : Controller
    {
        private readonly SoftwareVersionService _service=new SoftwareVersionService();
        
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
            if (Directory.Exists(repertoryNamePath)||_service.IsVersionExist(repertoryName))
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
            if (_service.IsVersionExist(repertoryName))
            {
                result = new { success = false, reason = "版本已存在"};
            }
            else
            {
                try
                {
                    string path = repertoryName.GetDetailHtmlFilePath(Server);
                    using (StreamWriter streamWriter = new StreamWriter(path, false))
                    {
                        streamWriter.Write(detail);
                    }
                    _service.AddSoftwareVersion(new SoftwareVersion() { Description = description, DetailPath = path, VersionName = repertoryName,PublishTime = DateTime.Now});
                    result = new { success = true, reason = "你真棒" };
                }
                catch (Exception e)
                {
                    result = new { success = false, reason = "存储文件错误，" + e.Message };
                }
            }
            return Json(result);
        }
    }
}