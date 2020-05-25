using GlowServices.Models.child;
using Microsoft.EntityFrameworkCore;

namespace GlowServices.Models
{
    public class ChildContext : DbContext
    {
        public ChildContext(DbContextOptions<ChildContext> options)
            : base(options)
        {
        }

        public DbSet<Child> Child { get; set; }
    }
}