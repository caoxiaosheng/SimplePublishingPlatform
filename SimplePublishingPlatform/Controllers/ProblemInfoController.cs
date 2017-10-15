using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using SimplePublishingPlatform.Models;
using SimplePublishingPlatform.Services;

namespace SimplePublishingPlatform.Controllers
{
    public class ProblemInfoController : Controller
    {
        private readonly ProblemInfoService _service=new ProblemInfoService();
        
        public ActionResult SubmitProblem()
        {
            return View();
        }

        public ActionResult HistoryProblems()
        {
            var historyProblemInfos = _service.GetHistoryProblemInfos();
            return View(historyProblemInfos);
        }

        [HttpPost]
        public void Add()
        {
            var versionOfOccurrence = Request["versionOfOccurrence"];
            var customer = Request["customer"];
            var problemDetail = Request["problemDetail"];
            var submitter = Request["submitter"];
            _service.AddProblemInfo(new ProblemInfo
            {
                VersionOfOccurrence = versionOfOccurrence,
                Customer = customer,
                ProblemState = ProblemState.待接收,
                ProblemDetail = problemDetail,
                Submitter = submitter,
                SubmitTime = DateTime.Now
            });
        }
    }
}
