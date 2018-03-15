using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossOutCommunity.Models
{
    public class AccountRole
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<Account> Members { get; set; }
        public IEnumerable<Account> NonMembers { get; set; }
    }
}
