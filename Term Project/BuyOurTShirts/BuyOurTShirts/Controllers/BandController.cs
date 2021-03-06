﻿using BuyOurTShirts.Models;
using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyOurTShirts.Controllers
{
    [Authorize(Roles = "Band Member")]
    public class BandController : Controller
    {
        // GET: Band

        private IVenueRepository venueRepo;
        private IShowRepository showRepo;
        private IMediaRepository mediaRepo;

 
        public BandController(IVenueRepository vR, IShowRepository sR, IMediaRepository mR) {
            venueRepo = vR;
            showRepo = sR;
            mediaRepo = mR;

        }

        #region Media
        public IActionResult MediaCreate()
        {
            ViewBag.ListOfTypes = mediaRepo.GetAllMediaTypes();
            return View();
        }
        public IActionResult MediaList() => View(mediaRepo.GetAllMedia());
        public IActionResult MediaEdit(int id)
        {
            ViewBag.ListOfTypes = mediaRepo.GetAllMediaTypes();
            return View(mediaRepo.GetMediaById(id));
        }

        [HttpPost]
        public IActionResult MediaCreate(Media media)
        {
            mediaRepo.Add(media);
            ViewData["Message"] = "Media Added!";
            ViewBag.ListOfTypes = mediaRepo.GetAllMediaTypes();
            return View("MediaList", mediaRepo.GetAllMedia());
        }

        [HttpPost]
        public IActionResult MediaEdit(Media media)
        {
            mediaRepo.Edit(media);
            ViewData["Message"] = "Media Updated!";
            ViewBag.ListOfTypes = mediaRepo.GetAllMediaTypes();
            return View("MediaEdit", media);
        }


        [HttpPost]
        public IActionResult MediaDelete(Media media)
        {
            mediaRepo.Delete(media.ID);
            ViewData["Message"] = "Media Deleted";
            return View("MediaList", mediaRepo.GetAllMedia());
        }

        #endregion



        #region Shows
        public IActionResult ShowList() => View(showRepo.GetAllShows());
        public IActionResult ShowEdit(int id)
        {
            ViewBag.ListOfVenues = venueRepo.GetAllVenues();
            ViewBag.ListOfTypes = showRepo.GetAllShowTypes();

            return View(showRepo.GetShowById(id));
        }
        [HttpGet]
        public IActionResult ShowCreate()
        {
             ViewBag.ListOfVenues = venueRepo.GetAllVenues();
            ViewBag.ListOfTypes = showRepo.GetAllShowTypes();
            return View();
        }
        

        [HttpPost]
        public IActionResult ShowCreate(Show show)
        {
            showRepo.Add(show);
            ViewData["Message"] = "Show Added!";
            return View("ShowList", showRepo.GetAllShows());
        }

        [HttpPost]
        public IActionResult ShowEdit(Show show)
        {
            showRepo.Edit(show);
            ViewData["Message"] = "Show Updated!";
            ViewBag.ListOfVenues = venueRepo.GetAllVenues();
            ViewBag.ListOfTypes = showRepo.GetAllShowTypes();
            return View("ShowEdit", show);
        }


        [HttpPost]
        public IActionResult ShowDelete(Show show)
        {
            showRepo.Delete(show.ID);
            ViewData["Message"] = "Show Deleted";
            return View("ShowList", showRepo.GetAllShows());
        }
        #endregion


        #region Venue
        public IActionResult VenueList() => View(venueRepo.GetAllVenues());
        
        public IActionResult VenueEdit(int id) => View(venueRepo.GetVenueById(id));
        [HttpGet]
        public IActionResult VenueCreate() => View();
        [HttpPost]
        public IActionResult VenueCreate(Venue venue)
        {
            venueRepo.Add(venue);
            ViewData["Message"] = "Venue Added!";
            return View("VenueList", venueRepo.GetAllVenues());
        }

        [HttpPost]
        public IActionResult VenueEdit(Venue venue)
        {
            venueRepo.Edit(venue);
            ViewData["Message"] = "Venue Updated!";
            return View("VenueEdit",venue);
        }


        [HttpPost]
        public IActionResult VenueDelete(Venue venue)
        {
            venueRepo.Delete(venue.ID);
            ViewData["Message"] = "Venue Deleted";
            return View("VenueList", venueRepo.GetAllVenues());
        }

        #endregion



    }
}