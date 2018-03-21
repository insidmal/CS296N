using BuyOurTShirts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyOurTShirts.Repositories
{
    public class TestVenueRepo : IVenueRepository
    {
        public List<Venue> VenueList = new List<Venue>();

     

        public int Add(Venue venue)
        {
            VenueList.Add(venue);
            return 1;
        }

        public int Delete(int id)
        {
            var venue = VenueList.FirstOrDefault(a => a.ID == id);
            VenueList.Remove(venue);
            return 1;
        }

        public int Edit(Venue venue)
        {
            
            return 1;
        }

        public List<Venue> GetAllVenues() => VenueList.ToList();
        public Venue GetVenueById(int id) => VenueList.FirstOrDefault(a => a.ID == id);
    }
}