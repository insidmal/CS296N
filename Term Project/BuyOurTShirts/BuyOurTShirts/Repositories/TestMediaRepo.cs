using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuyOurTShirts.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BuyOurTShirts.Controllers;

namespace BuyOurTShirts.Repositories
{
    public class TestMediaRepo : IMediaRepository
    {


        public List<Media> MediaList = new List<Media>();




        public int Add(Media media)
        {
            MediaList.Add(media);
            return 1;
        }

        public int Delete(int id)
        {
            var media = MediaList.FirstOrDefault(a => a.ID == id);
            MediaList.Remove(media);
            return 1;
        }

        public int Edit(Media media)
        {
            return 1;
        }

        public List<Media> GetAllMedia() => MediaList.ToList();
        public List<Media> GetAllMediaByType(MediaType mt) => MediaList.Where(a => a.mediaType == mt).ToList();

        public Media GetMediaById(int id) => MediaList.FirstOrDefault(a => a.ID == id);
        public List<MediaType> GetAllMediaTypes() => new List<MediaType> { MediaType.Audio, MediaType.Image, MediaType.Video };

    }
}