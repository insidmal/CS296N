using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOTSwebsite.Models
{
    public class Blog
    {
        public Account account { get; set; }
        public Media media { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string content { get; set; }
    }
}