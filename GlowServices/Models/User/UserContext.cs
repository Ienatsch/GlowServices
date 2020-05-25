using GlowServices.Models.user;
using Microsoft.EntityFrameworkCore;

namespace GlowServices.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}