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
    public class MediaRepo : IMediaRepository
    {

        private readonly BotsDbContext context;

        public MediaRepo(BotsDbContext ctx)
        {
            context = ctx;
        }

        public int Add(Media media)
        {
            context.Media.Add(media);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var media = context.Media.FirstOrDefault(a => a.ID == id);
            context.Media.Remove(media);
            return context.SaveChanges();
        }

        public int Edit(Media media)
        {
            context.Media.Update(media);
            return context.SaveChanges();
        }

        public List<Media> GetAllMedia() => context.Media.ToList();
        public List<Media> GetAllMediaByType(MediaType mt) => context.Media.Where(a=>a.mediaType == mt).ToList();

        public Media GetMediaById(int id) =>context.Media.FirstOrDefault(a => a.ID == id);
        public List<MediaType> GetAllMediaTypes() => new List<MediaType> { MediaType.Audio, MediaType.Image, MediaType.Video };

    }
}