﻿using BuyOurTShirts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyOurTShirts.Repositories
{
    public interface IMediaRepository
    {
        int Add(Media media);
        int Edit(Media media);
        int Delete(int id);

        List<Media> GetAllMedia();
        List<Media> GetAllMediaByType(MediaType mt);
        Media GetMediaById(int id);
        List<MediaType> GetAllMediaTypes();
    }
}