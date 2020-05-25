using Microsoft.EntityFrameworkCore;

namespace GlowServices.Models
{
    public class FeedingItemContext : DbContext
    {
        public FeedingItemContext(DbContextOptions<FeedingItemContext> options)
            : base(options)
        {
        }

        public DbSet<FeedingItem> Feedings { get; set; }
    }
}