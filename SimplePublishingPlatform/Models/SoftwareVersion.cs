using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplePublishingPlatform.Models
{
    public class SoftwareVersion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string VersionName { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public string DetailPath { get; set; }
        public DateTime PublishTime { get; set; }
    }
}