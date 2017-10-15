using System;
using System.ComponentModel.DataAnnotations;

namespace SimplePublishingPlatform.Models
{
    public class ProblemInfo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string VersionOfOccurrence { get; set; }
        [Required]
        [MaxLength(50)]
        public string Customer { get; set; }
        [Required]
        [MaxLength(1000)]
        public string ProblemDetail { get; set; }
        [Required]
        [MaxLength(50)]
        public string Submitter { get; set; }
        public ProblemState ProblemState { get; set; }
        public DateTime SubmitTime { get; set; }
    }

    public enum ProblemState
    {
        待接收,
        已接收,
        打回,
        已分配版本
    }
}