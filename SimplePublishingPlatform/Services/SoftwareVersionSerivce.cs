using System;
using System.Linq;
using SimplePublishingPlatform.DAL;
using SimplePublishingPlatform.Models;

namespace SimplePublishingPlatform.Services
{
    public class SoftwareVersionSerivce:IDisposable
    {
        private readonly SoftwareVersionContext _softwareVersionContext=new SoftwareVersionContext();

        public void AddSoftwareVersion(SoftwareVersion softwareVersion)
        {
            _softwareVersionContext.Versions.Add(softwareVersion);
            _softwareVersionContext.SaveChanges();
        }

        public bool IsVersionExist(string versionName)
        {
            return _softwareVersionContext.Versions.Any(item => item.VersionName == versionName);
        }

        public void Dispose()
        {
            _softwareVersionContext.Dispose();
        }
    }
}