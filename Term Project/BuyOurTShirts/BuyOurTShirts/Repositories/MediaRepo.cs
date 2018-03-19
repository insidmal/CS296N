using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuyOurTShirts.Models;
using Microsoft.EntityFrameworkCore;

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
            var media = context.Media.First(a => a.ID == id);
            context.Media.Remove(media);
            return context.SaveChanges();
        }

        public int Edit(Media media)
        {
            context.Media.Update(media);
            return context.SaveChanges();
        }

        public List<Media> GetAllMedia()
        {
            List<Media> meds = context.Media.ToList();
            foreach (Media me in meds) me.Acct = GetMediaAccount(me.AccountId);
            return meds;
        }

        public List<Media> GetAllMediaByType(MediaType mt)
        {
            List<Media> meds = context.Media.Include(a=>a.mediaType==mt).ToList();
            foreach (Media me in meds) me.Acct = GetMediaAccount(me.AccountId);
            return meds;
        }

        public Media GetMediaById(int id)
        {
            var meds = context.Media.First(a => a.ID == id);
            meds.Acct = GetMediaAccount(meds.AccountId);
            return meds;

        }

        private Account GetMediaAccount(string i)
        {
            return context.Account.First(a => a.Id == i);
        }
    }
}