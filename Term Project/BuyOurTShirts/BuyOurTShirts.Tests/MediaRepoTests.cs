using BuyOurTShirts.Controllers;
using BuyOurTShirts.Models;
using BuyOurTShirts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BuyOurTShirts.Tests
{
    public class MediaRepoTests
    {
        IMediaRepository repo;
        MediaController controller;

        public MediaRepoTests()
        {
            repo = new TestMediaRepo();
            controller = new MediaController(repo);
        }


        [Fact]
    public void AddMediaTest()
    {
        Assert.Empty(repo.GetAllMedia());
            repo.Add(new Media { name = "High on the Mountain Preview", description = "A Sneak Preview of our Single High on the Mountain", mediaType = MediaType.Audio, resourceLink = "<iframe width=\"100%\" height=\"300\" scrolling=\"no\" frameborder=\"no\" allow=\"autoplay\" src=\"https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/416390931&color=%23ff5500&auto_play=true&hide_related=false&show_comments=true&show_user=true&show_reposts=false&show_teaser=true&visual=true\"></iframe>", CollectionName = "Retold EP" });
        Assert.Single(repo.GetAllMedia());

    }
    [Fact]
    public void DeleteMediaTest()
    {
            Assert.Empty(repo.GetAllMedia());
            repo.Add(new Media { name = "High on the Mountain Preview", description = "A Sneak Preview of our Single High on the Mountain", mediaType = MediaType.Audio, resourceLink = "<iframe width=\"100%\" height=\"300\" scrolling=\"no\" frameborder=\"no\" allow=\"autoplay\" src=\"https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/416390931&color=%23ff5500&auto_play=true&hide_related=false&show_comments=true&show_user=true&show_reposts=false&show_teaser=true&visual=true\"></iframe>", CollectionName = "Retold EP" });
            Assert.Single(repo.GetAllMedia());
            repo.Delete(repo.GetAllMedia()[0].ID);
            Assert.Empty(repo.GetAllMedia());

        }
        [Fact]
    public void GetAllMediaTest()
    {
            Assert.Empty(repo.GetAllMedia());
            repo.Add(new Media { name = "High on the Mountain Preview", description = "A Sneak Preview of our Single High on the Mountain", mediaType = MediaType.Audio, resourceLink = "<iframe width=\"100%\" height=\"300\" scrolling=\"no\" frameborder=\"no\" allow=\"autoplay\" src=\"https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/416390931&color=%23ff5500&auto_play=true&hide_related=false&show_comments=true&show_user=true&show_reposts=false&show_teaser=true&visual=true\"></iframe>", CollectionName = "Retold EP" });
            Assert.Single(repo.GetAllMedia());

        }

    }

}
