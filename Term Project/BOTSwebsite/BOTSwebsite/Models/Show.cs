﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOTSwebsite.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int venueId { get; set; }
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