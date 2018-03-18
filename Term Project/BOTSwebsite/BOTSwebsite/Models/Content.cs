using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOTSwebsite.Models
{
    public class Content
    {
        public int id { get; set; }
        public int authorId { get; set; }
        public int mediaId { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string content { get; set; }
    }
}