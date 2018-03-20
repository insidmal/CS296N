using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BuyOurTShirts.Models
{
    public class AccountRole
    {
        public IdentityRole Role { get; set; }
        public List<Account> Members { get; set; }
        public List<Account> NonMembers { get; set; }
    }
}
