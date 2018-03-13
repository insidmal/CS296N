using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrossOutCommunity.Models
{
    public class User
    {
        private List<Message> messages = new List<Message>();
        public List<Message> Messages { get { return messages; } }



        public int UserID { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}