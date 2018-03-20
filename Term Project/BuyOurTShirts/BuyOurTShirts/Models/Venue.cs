using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyOurTShirts.Models
{
    public class Venue
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string wazeNav { get; set; }
        public string googleNav { get; set; }
        public List<Show> Shows { get; set; }
    }
}