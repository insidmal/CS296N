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
                context.Users.Add(use);
                context.SaveChanges();
                Message mess = new Message { ContactMessage = "Test Message Y", UserID = use.UserID };
                context.Messages.Add(mess);
                use.Messages.Add(mess);


                use = new User { Name = "Test User2", EmailAddress = "User2@Gmail.com" };
                context.Users.Add(use);
                context.SaveChanges();
                mess = new Message { ContactMessage = "Test Message X", UserID = use.UserID };
                context.Messages.Add(mess);
                use.Messages.Add(mess);


                use = new User { Name = "Test User3", EmailAddress = "User3@Gmail.com" };
                context.Users.Add(use);
                context.SaveChanges();
                mess = new Message { ContactMessage = "Test Message Z", UserID = use.UserID };
                context.Messages.Add(mess);
                use.Messages.Add(mess);
                context.SaveChanges();

            }

            //    context.Messages.AddRange(
            //        new Message { ContactMessage = "Test Message A", ContactUser = new User { Name = "Name A", EmailAddress = "A@Email.com" } },
            //        new Message { ContactMessage = "Test Message B", ContactUser = new User { Name = "Name B", EmailAddress = "B@Email.com" } },
            //        new Message { ContactMessage = "Test Message C", ContactUser = new User { Name = "Name C", EmailAddress = "C@Email.com" } },
            //        new Message { ContactMessage = "Test Message D", ContactUser = new User { Name = "Name D", EmailAddress = "D@Email.com" } },
            //        new Message { ContactMessage = "Test Message E", ContactUser = new User { Name = "Name E", EmailAddress = "E@Email.com" } });

            //    context.SaveChanges();
        }
        }

}
