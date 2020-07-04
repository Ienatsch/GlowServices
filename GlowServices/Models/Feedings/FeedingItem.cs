using System;
using System.ComponentModel.DataAnnotations;

namespace GlowServices.Models
{
    public class FeedingItem
    {
        [Key]
        public Guid? FeedingId { get; set; }
        public Guid ChildId { get; set; }
        public DateTime? FeedingDate { get; set; }
        public string FeedingStartTime { get; set; }
        public string FeedingEndTime { get; set; }
        public int Oz { get; set; }
        public TimeSpan? TimeSinceLastFeed { get; set; }

    }
}
