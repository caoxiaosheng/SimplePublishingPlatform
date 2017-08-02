using System.Web.Mvc;

namespace SimplePublishingPlatform.Controllers
{
    public class PublishController : Controller
    {
        // GET: Publish
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string repertoryName)
        {
            var result = new {success = true, reason = "重复了"};
            return Json(result);
        }
    }
}