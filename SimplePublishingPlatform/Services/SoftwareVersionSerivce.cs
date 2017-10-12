﻿using System;
using System.Linq;
using SimplePublishingPlatform.DAL;
using SimplePublishingPlatform.Models;

namespace SimplePublishingPlatform.Services
{
    public class SoftwareVersionService:IDisposable
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

        public SoftwareVersion FindLastSoftwareVersion()
        {
            return _softwareVersionContext.Versions.OrderByDescending(item => item.PublishTime).FirstOrDefault();
        }

        public void Dispose()
        {
            _softwareVersionContext.Dispose();
        }
    }
}