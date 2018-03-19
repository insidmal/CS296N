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
            var newVen = GetVenueById(venue.ID);
            newVen.name = venue.name ?? newVen.name;
            newVen.address = venue.address ?? newVen.address;
            newVen.city = venue.city ?? newVen.city;
            newVen.state = venue.state ?? newVen.state;
            newVen.description = venue.description ?? newVen.description;
            newVen.wazeNav = venue.wazeNav ?? newVen.wazeNav;
            newVen.googleNav = venue.googleNav ?? newVen.googleNav;

            context.Venue.Update(newVen);
            return context.SaveChanges();
        }

        public List<Venue> GetAllVenues() => context.Venue.ToList<Venue>();
        

        public Venue GetVenueById(int id) => context.Venue.First(a => a.ID == id);
        
    }
}