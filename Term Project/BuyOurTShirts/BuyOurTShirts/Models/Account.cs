
using Microsoft.AspNetCore.Identity;

namespace BOTSwebsite.Models
{
    public class Account : IdentityUser
    {
         public string firstName { get; set; }
        public string lastName { get; set; }
        public string imgUrl { get; set; }
        public string bio { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}