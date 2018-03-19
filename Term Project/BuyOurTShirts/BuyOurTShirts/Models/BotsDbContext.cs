using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BuyOurTShirts.Models
{
    public class BotsDbContext : IdentityDbContext
    {
        public BotsDbContext(DbContextOptions<BotsDbContext> options)
        : base(options) { }

        public DbSet<Account> Account { get; set; }
        public DbSet<Show> Show { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Comment> Comment { get; set; }

    }
}