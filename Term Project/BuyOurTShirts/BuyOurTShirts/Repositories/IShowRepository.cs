using BuyOurTShirts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuyOurTShirts.Repositories
{
    public interface IShowRepository
    {
        List<Show> GetAllShows();
        List<ShowType> GetAllShowTypes();
        List<Show> GetShowsByVenue(int iD);
        Show GetShowById(int id);
        int Add(Show show);
        int Edit(Show show);
        int Delete(int id);
    }
}