using CrossOutCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossOutCommunity.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        CCDbContext context;

        public MessageRepository(CCDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Message> GetAllMessages()
        {
            return context.Messages;
        }

        public Message AddMessage(Message mess)
        {
            context.Messages.Add(mess);
            return mess;
        }
    }
}
