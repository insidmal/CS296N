using CrossOutCommunity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrossOutCommunity.Repositories
{
    public class CCDbContext : IdentityDbContext
    {
        public CCDbContext(DbContextOptions<CCDbContext> options)
        : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Message> Messages { get; set; }

         public DbSet<Account> Accounts { get; set; }

    }
}
