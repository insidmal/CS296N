using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossOutCommunity.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string ContactMessage { get; set; }
        public User ContactUser { get; set; }
    }
}
