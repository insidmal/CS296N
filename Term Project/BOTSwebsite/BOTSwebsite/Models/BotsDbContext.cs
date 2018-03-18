using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BOTSwebsite.Models
{
    public class BotsDbContext : IdentityDbContext
    {
        public BotsDbContext(DbContextOptions<BotsDbContext> options)
        : base(options) { }
    }
}