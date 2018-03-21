using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuyOurTShirts.Models;

namespace BuyOurTShirts.Repositories
{
    public class ShowRepo : IShowRepository
    {

        private readonly BotsDbContext context;

        public ShowRepo(BotsDbContext ctx)
        {
            context = ctx;
            if(!context.Show.Any())
            {
                if(!context.Venue.Any())
                {
                    context.Venue.Add(new Venue { name = "W.O.W. Hall", address = "291 W 8th Ave", city = "Eugene", state = "Oregon", description = "The W.O.W. Hall is a performing arts venue in Eugene, Oregon, United States. It was formerly a Woodmen of the World lodge. The W.O.W. Hall was listed on the National Register of Historic Places in 1996.", wazeNav = "https://www.waze.com/livemap?zoom=17&lat=44.05128&lon=-123.09708", googleNav = "https://www.google.com/maps/place/291+W+8th+Ave,+Eugene,+OR+97401/@44.0511031,-123.0992632,17z/data=!3m1!4b1!4m5!3m4!1s0x54c11e6ce9f47a7f:0x343f151172bdd64e!8m2!3d44.0511031!4d-123.0970745" });
                    context.SaveChanges();
                }
                context.Show.Add(new Show { name = "The Super Awesome Show", date = DateTime.Parse("4/20/2018 4:20PM"), cost = 1, minAge = 18, type = ShowType.Public, VenueID = context.Venue.First().ID, description = "This show really will be the best, that is why it is the super awsome show." });
                context.SaveChanges();
            }
        }

        public int Add(Show show)
        {
            context.Show.Add(show);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var show = context.Show.FirstOrDefault(a => a.ID == id);
            context.Show.Remove(show);
            return context.SaveChanges();
        }

       public int Edit(Show show)
        {
            context.Show.Update(show);
            return context.SaveChanges();
        }

        public List<Show> GetAllShows()
        {
            List<Show> shows = context.Show.Where(a=>a.date>DateTime.Now).ToList();
             foreach (Show sh in shows) sh.venue = GetShowVenue(sh.VenueID);
            return shows;
        }
        public List<ShowType> GetAllShowTypes() => new List<ShowType> { ShowType.Private, ShowType.Public };

        public Show GetShowById(int id) {
            var show = context.Show.FirstOrDefault(a => a.ID == id);
            show.venue = GetShowVenue(show.VenueID);
            return show;
         }

        public List<Show> GetShowsByVenue(int id) => context.Show.Where(a => a.VenueID == id && a.date>DateTime.Now).ToList();
        

        private Venue GetShowVenue(int id) => context.Venue.FirstOrDefault(a => a.ID == id);
        
    }
}