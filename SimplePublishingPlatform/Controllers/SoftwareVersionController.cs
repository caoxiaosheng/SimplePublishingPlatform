using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimplePublishingPlatform.Extensions;
using SimplePublishingPlatform.Services;

namespace SimplePublishingPlatform.Controllers
{
    public class SoftwareVersionController : Controller
    {
        private readonly SoftwareVersionService _service=new SoftwareVersionService();

        // GET: SoftwareVersion
        public ActionResult Index(string versionName)
        {
            ViewBag.VersionName = versionName;
            var path = versionName.GetDetailHtmlFilePath(Server);
            var detailHtml = "未找到文件";
            if (System.IO.File.Exists(path))
            {
                detailHtml = System.IO.File.ReadAllText(path);
            }
            ViewBag.DetailHtml = detailHtml;
            return View();
        }

        public ActionResult HistoryVersions()
        {
            var historySoftwareVersions = _service.GetHistorySoftwareVersions();
            return View(historySoftwareVersions);
        }
    }
}