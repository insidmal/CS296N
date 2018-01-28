using CrossOutCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossOutCommunity.Repositories
{
    interface IMessageRepository
    {
        IQueryable<Message> GetAllMessages();
        void AddMessage(Message m);
    }
}
