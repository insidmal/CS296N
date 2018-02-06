using CrossOutCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossOutCommunity.Repositories
{
    public class TestMessageRepository : IMessageRepository
    {
        private List<Message> messages= new List<Message>();

        public TestMessageRepository()
        {
            messages.Add(new Message { ContactMessage = "This is a contact message.", ContactUser = new User { Name = "John", EmailAddress = "contact@conquest-marketing.com" } });
                messages.Add(new Message { ContactMessage = "This is also contact message.", ContactUser = new User { Name = "Frederick", EmailAddress = "freddy@krueger.com" } });
        }

        public List<Message> GetAllMessages()
        {
            return messages.ToList<Message>();
        }

        public Message AddMessage(Message mess)
        {
            messages.Add(mess);
            return mess;
        }


    }
}
