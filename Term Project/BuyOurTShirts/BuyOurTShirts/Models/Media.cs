using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyOurTShirts.Models
{
    public class Media
    {
        public int ID { get; set; }
        public string resourceLink { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Account account { get; set; }
        public MediaType mediaType { get; set; }
    }

    public enum MediaType
    {

        Image = 1,
        Video = 2,
        Audio = 3
   }
}