using BOTSwebsite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOTSwebsite.Repositories
{
    public class ICommentRepository
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Show> Show { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Comment> Comment { get; set; }




    }
}