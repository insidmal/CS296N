using System.Collections.Generic;
using System.Linq;
using CrossOutCommunity.Models;
using Microsoft.EntityFrameworkCore;
using CrossOutCommunity.Repositories;

namespace BookInfo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CCDbContext context;

        public UserRepository(CCDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList<User>();
        }

        public User GetUserByName(string user)
        {
            return context.Users.First(b => b.Name == user);
        }

  
        public User AddUser(User user)
        {
            context.Users.Add(user);
            return user;
        }

        public int Update(User user)
        {
            context.Users.Update(user);
            return context.SaveChanges();
        }
    }
}