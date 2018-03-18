using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOTSwebsite.Models
{
    public class Comment
    {
         public int parentId { get; set; }
        public ParentType parentType { get; set; }
        public Account account { get; set; }
        public DateTime date { get; set; }
        public string comment { get; set; }
    }

    public enum ParentType
    {
        Media=1,
        Show=2,
        Venue=3,
        Blog=4
    }
}