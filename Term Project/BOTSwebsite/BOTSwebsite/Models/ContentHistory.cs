using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOTSwebsite.Models
{
    public class ContentHistory
    {
        public int id { get; set; }
        public int pageId { get; set; }
        public string pageName { get; set; }
        public string content { get; set; }
        public int authorId { get; set; }
        public DateTime updateDate { get; set; }
    }
}