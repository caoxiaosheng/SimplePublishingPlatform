using System;
using System.Web.Mvc;
using AutoMapper;
using SimplePublishingPlatform.Models;
using SimplePublishingPlatform.Services;
using SimplePublishingPlatform.ViewModels;

namespace SimplePublishingPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly SoftwareVersionService _service= new SoftwareVersionService();

        public ActionResult Index()
        {
            var lastSoft = _service.FindLastSoftwareVersion();
            if (lastSoft == null)
            {
                lastSoft=new SoftwareVersion
                {
                    Description = "喵喵喵",
                    DetailPath = "#",
                    PublishTime = DateTime.MinValue,
                    Id = -1,
                    VersionName = "喵喵喵"
                };
            }
            return View(Mapper.Map<SoftwareVersion,SoftwareVersionViewModel>(lastSoft));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}