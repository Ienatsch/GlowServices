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
        public DateTime Time { get; set; }
        public int Oz { get; set; }
        public DateTime TimeSinceLastFeed { get; set; }

    }
}
