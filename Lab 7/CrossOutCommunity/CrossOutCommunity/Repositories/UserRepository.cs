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
        private List<Message> messages = new List<Message>();
        public List<Message> Messages { get { return messages; } }



        public UserRepository(CCDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.User.Include(m => m.Messages).ToList().Reverse<User>().ToList();
        }

        public User GetUserByName(string user)
        {
            return context.User.First(b => b.Name == user);
        }

  
        public User AddUser(User user)
        {

            context.User.Add(user);
            context.SaveChanges();


            return user;
        }

        public int Update(User user)
        {
            context.User.Update(user);
            return context.SaveChanges();
        }
    }
}