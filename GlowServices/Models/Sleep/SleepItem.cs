using System;
using System.ComponentModel.DataAnnotations;

namespace GlowServices.Models.Sleep
{
    public class SleepItem
    {
        [Key]
        public Guid? SleepId { get; set; }
        public Guid ChildId { get; set; }
        public DateTime? SleepDate { get; set; }
        public string SleepStartTime { get; set; }
        public string SleepEndTime { get; set; }
        public TimeSpan? TimeSinceLastSleep { get; set; }
    }
}
