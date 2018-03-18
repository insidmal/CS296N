
using Microsoft.AspNetCore.Identity;

namespace BOTSwebsite.Models
{
    public class Account : IdentityUser
    {
         public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImgUrl { get; set; }
        public string Bio { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}