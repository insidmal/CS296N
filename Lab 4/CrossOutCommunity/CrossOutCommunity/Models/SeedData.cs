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

        public static void Initialize(CCDbContext context)
        {

            // Look for any movies.
            if (context.Messages.Local.Count()>=1)
            {
                return;   // DB has been seeded
            }

            context.Messages.AddRange(
                new Message { ContactMessage = "Test Message A", ContactUser = new User { Name = "Name A", EmailAddress = "A@Email.com" } },
                new Message { ContactMessage = "Test Message B", ContactUser = new User { Name = "Name B", EmailAddress = "B@Email.com" } },
                new Message { ContactMessage = "Test Message C", ContactUser = new User { Name = "Name C", EmailAddress = "C@Email.com" } },
                new Message { ContactMessage = "Test Message D", ContactUser = new User { Name = "Name D", EmailAddress = "D@Email.com" } },
                new Message { ContactMessage = "Test Message E", ContactUser = new User { Name = "Name E", EmailAddress = "E@Email.com" } });

            context.SaveChanges();
        }
    }

}
