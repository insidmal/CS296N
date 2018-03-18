using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOTSwebsite.Models
{
    public class Comment
    {
        public string id { get; set; }
        public int parentId { get; set; }
        public int parentType { get; set; }
        public int authorId { get; set; }
        public DateTime date { get; set; }
        public string comment { get; set; }
    }
}