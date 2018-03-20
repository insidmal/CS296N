using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
            context.Database.EnsureCreated();
            //seed admin account and test account

            if (!context.Account.Any())
            {
                userManager.CreateAsync(new Account { FirstName = "John", LastName = "Bell", Email = "contact@conquest-marketing.com", UserName = "insidmal"}, "testpass");
                userManager.CreateAsync(new Account { FirstName = "Test", LastName = "Band", Email = "bandmember@email.com", UserName = "bandmember" }, "bandmember");
                userManager.CreateAsync(new Account { FirstName = "Test", LastName = "Member", Email = "member@email.com", UserName = "member" }, "member");

            }
            //assign roles to new accounts
            if (!context.Roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("Administrator"));
                roleManager.CreateAsync(new IdentityRole("Band Member"));
                userManager.AddToRolesAsync(userManager.FindByEmailAsync("contact@conquest-marketing.com").Result, new List<string> { "Administrator", "Band Member" });
                userManager.AddToRoleAsync(userManager.FindByEmailAsync("contact@conquest-marketing.com").Result, "Band Member");
            }
            //add venue
            if (!context.Venue.Any())
            {
                context.Venue.Add(new Venue { name = "W.O.W. Hall", address = "291 W 8th Ave", city = "Eugene", state = "Oregon", description = "The W.O.W. Hall is a performing arts venue in Eugene, Oregon, United States. It was formerly a Woodmen of the World lodge. The W.O.W. Hall was listed on the National Register of Historic Places in 1996.", wazeNav = "https://www.waze.com/livemap?zoom=17&lat=44.05128&lon=-123.09708", googleNav = "https://www.google.com/maps/place/291+W+8th+Ave,+Eugene,+OR+97401/@44.0511031,-123.0992632,17z/data=!3m1!4b1!4m5!3m4!1s0x54c11e6ce9f47a7f:0x343f151172bdd64e!8m2!3d44.0511031!4d-123.0970745" });
                context.SaveChanges();
            }
            //add show
            if (!context.Show.Any())
            {
                context.Show.Add(new Show { name = "The Super Awesome Show", date = DateTime.Parse("4/20/2018 4:20PM"), cost = 1, minAge = 18, type = ShowType.Private, VenueID = context.Venue.First().ID, description = "This show really will be the best, that is why it is the super awsome show." });
                context.SaveChanges();
            }
            //add blog
            if (!context.Blog.Any())
            {
                context.Blog.Add(new Blog { title = "This is a Blog Post", summary = "A summary of the most recent blog posted is listed on the home page, you can click it's title to view the full post.", content = "This is the actual blog post, here is some text.  It really doesn't mean anything, yet here it is anyway!", AccountId = userManager.FindByEmailAsync("contact@conquest-marketing.com").Result.Id });
                context.SaveChanges();
            }
            //add media
            if (!context.Media.Any())
            {
                context.Media.Add(new Media { name = "High on the Mountain Preview", description = "A Sneak Preview of our Single High on the Mountain", mediaType = MediaType.Audio, resourceLink = "<iframe width=\"100%\" height=\"300\" scrolling=\"no\" frameborder=\"no\" allow=\"autoplay\" src=\"https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/416390931&color=%23ff5500&auto_play=true&hide_related=false&show_comments=true&show_user=true&show_reposts=false&show_teaser=true&visual=true\"></iframe>", CollectionName = "Retold EP" });
                context.Media.Add(new Media { name = "High on the Mountain Preview", description = "A Sneak Preview of our Single High on the Mountain", mediaType = MediaType.Video, resourceLink = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/sV038VleAGU?rel=0\" frameborder=\"0\" allow=\"autoplay; encrypted-media\" allowfullscreen></iframe>", CollectionName = "Retold EP" });
                context.Media.Add(new Media { name = "Buy Our T-Shirts", description = "Logo for Buy Our T-Shirts, Eugene Oregon Rock", mediaType = MediaType.Image, resourceLink = "//images/logo.png" });
                context.SaveChanges();
            }
        }
    }
}