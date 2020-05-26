using System;
using System.ComponentModel.DataAnnotations;

namespace GlowServices.Models
{
    public class FeedingItem
    {
        [Key]
        public Guid FeedingId { get; set; }
        public Guid ChildId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int Oz { get; set; }
        public TimeSpan TimeSinceLastFeed { get; set; }

    }
}
