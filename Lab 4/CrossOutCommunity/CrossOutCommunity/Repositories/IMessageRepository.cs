using CrossOutCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossOutCommunity.Repositories
{
    public interface IMessageRepository
    {
        //IQueryable<Message> GetAllMessages();
        List<Message> GetAllMessages();
        Message AddMessage(Message m);
    }
}
