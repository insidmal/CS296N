using BuyOurTShirts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyOurTShirts.Repositories
{
    public interface IVenueRepository
    {
        List<Venue> GetAllVenues();
        Venue GetVenueById(int id);
        int Add(Venue venue);
        int Edit(Venue venue);
        int Delete(int id);
    }
}