using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SimplePublishingPlatform.ViewModels
{
    public class SoftwareVersionViewModel
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string VersionName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string DetailPath { get; set; }
        public DateTime PublishTime { get; set; }
    }
}