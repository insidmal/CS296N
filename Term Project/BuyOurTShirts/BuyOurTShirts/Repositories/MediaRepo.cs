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
            if (!context.Media.Any())
            {
                context.Media.Add(new Media { name = "High on the Mountain Preview", description = "A Sneak Preview of our Single High on the Mountain", mediaType = MediaType.Audio, resourceLink = "<iframe width=\"100%\" height=\"300\" scrolling=\"no\" frameborder=\"no\" allow=\"autoplay\" src=\"https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/416390931&color=%23ff5500&auto_play=true&hide_related=false&show_comments=true&show_user=true&show_reposts=false&show_teaser=true&visual=true\"></iframe>", CollectionName = "Retold EP" });
                context.Media.Add(new Media { name = "High on the Mountain Preview", description = "A Sneak Preview of our Single High on the Mountain", mediaType = MediaType.Video, resourceLink = "<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/sV038VleAGU?rel=0\" frameborder=\"0\" allow=\"autoplay; encrypted-media\" allowfullscreen></iframe>", CollectionName = "Retold EP" });
                context.Media.Add(new Media { name = "Buy Our T-Shirts", description = "Logo for Buy Our T-Shirts, Eugene Oregon Rock", mediaType = MediaType.Image, resourceLink = "/images/logo.png" });
                context.SaveChanges();
            }
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