using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOTSwebsite.Models
{
    public class Show
    {
        public string name { get; set; }
        public string description { get; set; }
        public Venue venue { get; set; }
        public DateTime date { get; set; }
        public float cost { get; set; }
        public int minAge { get; set; }
        public ShowType type { get; set; }
    }

    public enum ShowType
    {
       Public=1,
       Private=2
    }
}