using GlowServices.Models.Sleep;
using Microsoft.EntityFrameworkCore;

namespace GlowServices.Models
{
    public class SleepItemContext : DbContext
    {
        public SleepItemContext(DbContextOptions<SleepItemContext> options)
            : base(options)
        {
        }

        public DbSet<SleepItem> SleepList { get; set; }
    }
}