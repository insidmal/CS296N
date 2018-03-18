using BOTSwebsite.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyOurTShirts.Models
{
    public class AccountRole
    {
        public IdentityRole Role { get; set; }
        public List<Account> Members { get; set; }
        public List<Account> NonMembers { get; set; }
    }
}
