using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplePublishingPlatform.Models
{
    public class SoftwareVersion
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string VersionName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string DetailPath { get; set; }
    }
}