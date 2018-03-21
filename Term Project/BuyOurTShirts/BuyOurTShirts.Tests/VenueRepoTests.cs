using BuyOurTShirts.Controllers;
using BuyOurTShirts.Models;
using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Xunit;

namespace BuyOurTShirts.Tests
{



   public class VenueRepoTests
    {
        IVenueRepository repo;
        VenueController controller;
        public VenueRepoTests()
        {
            repo = new TestVenueRepo();
            controller = new VenueController(repo, new TestShowRepo());
        }

        [Fact]
        public void AddVenueTest()
        {
            repo.Add(new Venue { name = "W.O.W. Hall", address = "291 W 8th Ave", city = "Eugene", state = "Oregon", description = "The W.O.W. Hall is a performing arts venue in Eugene, Oregon, United States. It was formerly a Woodmen of the World lodge. The W.O.W. Hall was listed on the National Register of Historic Places in 1996.", wazeNav = "https://www.waze.com/livemap?zoom=17&lat=44.05128&lon=-123.09708", googleNav = "https://www.google.com/maps/place/291+W+8th+Ave,+Eugene,+OR+97401/@44.0511031,-123.0992632,17z/data=!3m1!4b1!4m5!3m4!1s0x54c11e6ce9f47a7f:0x343f151172bdd64e!8m2!3d44.0511031!4d-123.0970745" });

            var count = repo.GetAllVenues().Count;
            count++;
            repo.Add(new Venue { name = "W.O.W. Hall", address = "291 W 8th Ave", city = "Eugene", state = "Oregon", description = "The W.O.W. Hall is a performing arts venue in Eugene, Oregon, United States. It was formerly a Woodmen of the World lodge. The W.O.W. Hall was listed on the National Register of Historic Places in 1996.", wazeNav = "https://www.waze.com/livemap?zoom=17&lat=44.05128&lon=-123.09708", googleNav = "https://www.google.com/maps/place/291+W+8th+Ave,+Eugene,+OR+97401/@44.0511031,-123.0992632,17z/data=!3m1!4b1!4m5!3m4!1s0x54c11e6ce9f47a7f:0x343f151172bdd64e!8m2!3d44.0511031!4d-123.0970745" });
            Assert.Equal(count, repo.GetAllVenues().Count);

        }

        [Fact]
        public void DeleteVenueTest()
        {
            repo.Add(new Venue { name = "W.O.W. Hall", address = "291 W 8th Ave", city = "Eugene", state = "Oregon", description = "The W.O.W. Hall is a performing arts venue in Eugene, Oregon, United States. It was formerly a Woodmen of the World lodge. The W.O.W. Hall was listed on the National Register of Historic Places in 1996.", wazeNav = "https://www.waze.com/livemap?zoom=17&lat=44.05128&lon=-123.09708", googleNav = "https://www.google.com/maps/place/291+W+8th+Ave,+Eugene,+OR+97401/@44.0511031,-123.0992632,17z/data=!3m1!4b1!4m5!3m4!1s0x54c11e6ce9f47a7f:0x343f151172bdd64e!8m2!3d44.0511031!4d-123.0970745" });

            var count = repo.GetAllVenues().Count;
            count++;
            repo.Add(new Venue { name = "W.O.W. Hall", address = "291 W 8th Ave", city = "Eugene", state = "Oregon", description = "The W.O.W. Hall is a performing arts venue in Eugene, Oregon, United States. It was formerly a Woodmen of the World lodge. The W.O.W. Hall was listed on the National Register of Historic Places in 1996.", wazeNav = "https://www.waze.com/livemap?zoom=17&lat=44.05128&lon=-123.09708", googleNav = "https://www.google.com/maps/place/291+W+8th+Ave,+Eugene,+OR+97401/@44.0511031,-123.0992632,17z/data=!3m1!4b1!4m5!3m4!1s0x54c11e6ce9f47a7f:0x343f151172bdd64e!8m2!3d44.0511031!4d-123.0970745" });
            Assert.Equal(count, repo.GetAllVenues().Count);
            count--;
            repo.Delete(repo.GetAllVenues()[0].ID);
            Assert.Equal(count, repo.GetAllVenues().Count);

        }
        [Fact]
        public void GetAllVenuesTest()
        {

            Assert.Empty(repo.GetAllVenues());

            repo.Add(new Venue { name = "W.O.W. Hall", address = "291 W 8th Ave", city = "Eugene", state = "Oregon", description = "The W.O.W. Hall is a performing arts venue in Eugene, Oregon, United States. It was formerly a Woodmen of the World lodge. The W.O.W. Hall was listed on the National Register of Historic Places in 1996.", wazeNav = "https://www.waze.com/livemap?zoom=17&lat=44.05128&lon=-123.09708", googleNav = "https://www.google.com/maps/place/291+W+8th+Ave,+Eugene,+OR+97401/@44.0511031,-123.0992632,17z/data=!3m1!4b1!4m5!3m4!1s0x54c11e6ce9f47a7f:0x343f151172bdd64e!8m2!3d44.0511031!4d-123.0970745" });

            Assert.Single(repo.GetAllVenues());
        }

    }
}
