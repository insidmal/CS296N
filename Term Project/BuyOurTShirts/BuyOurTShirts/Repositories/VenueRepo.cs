using BuyOurTShirts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyOurTShirts.Repositories
{
    public class VenueRepo : IVenueRepository
    {
        private readonly BotsDbContext context;

        public VenueRepo(BotsDbContext ctx)
        {
            context = ctx;
        }

        public int Add(Venue venue)
        {
            context.Venue.Add(venue);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var venue = context.Venue.First(a => a.ID == id);
            context.Venue.Remove(venue);
            return context.SaveChanges();
        }

        public int Edit(Venue venue)
        {
            context.Venue.Update(venue);
            return context.SaveChanges();
        }

        public List<Venue> GetAllVenues() => context.Venue.ToList();
        

        public Venue GetVenueById(int id) => context.Venue.First(a => a.ID == id);
        
    }
}