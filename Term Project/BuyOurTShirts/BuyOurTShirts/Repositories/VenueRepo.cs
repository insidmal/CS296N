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
            return context.SaveChanges();
        }

        public int Edit(Venue venue)
        {
            throw new NotImplementedException();
        }

        public List<Venue> GetAllVenues()
        {
            throw new NotImplementedException();
        }

        public Venue GetVenueById(int id)
        {
            throw new NotImplementedException();
        }
    }
}