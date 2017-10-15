using System.Collections.Generic;
using System.Linq;
using SimplePublishingPlatform.DAL;
using SimplePublishingPlatform.Models;

namespace SimplePublishingPlatform.Services
{
    public class ProblemInfoService
    {
        private readonly PublishingPlatformContext _softwareVersionContext = new PublishingPlatformContext();

        public void AddProblemInfo(ProblemInfo problemInfo)
        {
            _softwareVersionContext.ProblemInfos.Add(problemInfo);
            _softwareVersionContext.SaveChanges();
        }

        public List<ProblemInfo> GetHistoryProblemInfos()
        {
            return _softwareVersionContext.ProblemInfos.OrderByDescending(item => item.SubmitTime).ToList();
        }
    }
}