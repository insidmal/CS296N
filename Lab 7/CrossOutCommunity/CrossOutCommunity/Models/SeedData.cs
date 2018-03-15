using CrossOutCommunity.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossOutCommunity.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider services)
        {

            CCDbContext context = services.GetRequiredService<CCDbContext>();
            context.Database.EnsureCreated();
            

            if (!context.Messages.Any())
            {
                User use = new User { Name = "Test User1", EmailAddress="User1@Gmail.com" };
                context.User.Add(use);
                context.SaveChanges();
                Message mess = new Message { ContactMessage = "Test Message Y", UserID = use.UserID };
                context.Messages.Add(mess);
                use.Messages.Add(mess);

                use = new User { Name = "Test User2", EmailAddress = "User2@Gmail.com" };
                context.User.Add(use);
                context.SaveChanges();
                mess = new Message { ContactMessage = "Test Message X", UserID = use.UserID };
                context.Messages.Add(mess);
                use.Messages.Add(mess);

                use = new User { Name = "Test User3", EmailAddress = "User3@Gmail.com" };
                context.User.Add(use);
                context.SaveChanges();
                mess = new Message { ContactMessage = "Test Message Z", UserID = use.UserID };
                context.Messages.Add(mess);
                use.Messages.Add(mess);
                context.SaveChanges();

            }
        }
    }

}
