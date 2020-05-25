using Microsoft.EntityFrameworkCore;
using GlowServices.Models.user;
using GlowServices.Models.child;
using GlowServices.Models;

namespace GlowServices.Data
{
    public class GlowServicesContext : DbContext
    {
        public GlowServicesContext (DbContextOptions<GlowServicesContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Child> Children { get; set; }

        public DbSet<FeedingItem> FeedingItems { get; set; }
    }
}
