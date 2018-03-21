using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuyOurTShirts.Models;

namespace BuyOurTShirts.Repositories
{
    public class TestShowRepo : IShowRepository
    {

        public List<Show> ShowList;



        public int Add(Show show)
        {
            ShowList.Add(show);
            return 1;
        }

        public int Delete(int id)
        {
            var show = ShowList.FirstOrDefault(a => a.ID == id);
            ShowList.Remove(show);
            return 1;
        }

        public int Edit(Show show)
        {
                     return 1;
        }

        public List<Show> GetAllShows()
        {
            List<Show> shows = ShowList.Where(a => a.date > DateTime.Now).ToList();
            return shows;
        }
        public List<ShowType> GetAllShowTypes() => new List<ShowType> { ShowType.Private, ShowType.Public };

        public Show GetShowById(int id)
        {
            var show = ShowList.FirstOrDefault(a => a.ID == id);
            return show;
        }

        public List<Show> GetShowsByVenue(int id) => ShowList.Where(a => a.VenueID == id && a.date > DateTime.Now).ToList();



    }
}