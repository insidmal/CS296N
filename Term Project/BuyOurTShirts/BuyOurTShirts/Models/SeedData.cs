using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BuyOurTShirts.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider services)
        {
            UserManager<Account> userManager = services.GetRequiredService<UserManager<Account>>();
            RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            BotsDbContext context = services.GetRequiredService<BotsDbContext>();
            var userStore = new UserStore<Account>(context);
            context.Database.EnsureCreated();
            //seed admin account and test account


            if (!context.Account.Any()) {

                string[] roles = new string[] { "Administrator", "Band Member" };

                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var Nrole = new IdentityRole();
                    if (!context.Roles.Any(r => r.Name == role))
                    {

                        Nrole = new IdentityRole(role);
                        Nrole.NormalizedName = role.ToUpper();
                        roleStore.CreateAsync(Nrole);
                    }
                }

                var admin = new Account { FirstName = "John", LastName = "Bell", Email = "contact@conquest-marketing.com", UserName = "insidmal", EmailConfirmed = true, LockoutEnabled = false, SecurityStamp = Guid.NewGuid().ToString("D") };
                var password = new PasswordHasher<Account>();
                var hashed = password.HashPassword(admin, "testpass");
                admin.PasswordHash = hashed;
                admin.NormalizedUserName = "INSIDMAL";
                admin.NormalizedEmail = ("contact@conquest-marketing.com").ToUpper();
                userStore.CreateAsync(admin);

                var bM = new Account { FirstName = "Test", LastName = "Bandmember", Email = "bandmember@email.com", UserName = "bandmember", EmailConfirmed = true, LockoutEnabled = false, SecurityStamp = Guid.NewGuid().ToString("D") };
                hashed = password.HashPassword(admin, "testpass");
                bM.PasswordHash = hashed;
                bM.NormalizedUserName = "BANDMEMBER";
                bM.NormalizedEmail = ("bandmember@email.com").ToUpper();
                userStore.CreateAsync(bM);



                var M = new Account { FirstName = "Test", LastName = "Member", Email = "member@email.com", UserName = "member", EmailConfirmed = true, LockoutEnabled = false, SecurityStamp = Guid.NewGuid().ToString("D") };
                hashed = password.HashPassword(admin, "testpass");
                M.PasswordHash = hashed;
                M.NormalizedUserName = "MEMBER";
                M.NormalizedEmail = ("member@email.com").ToUpper();
                userStore.CreateAsync(M);


                userManager.AddToRoleAsync(bM, "Band Member");
                userManager.AddToRoleAsync(admin, "Band Member");
                userManager.AddToRoleAsync(admin, "Administrator");

                context.SaveChanges();
                

            }
        }
    }
}
