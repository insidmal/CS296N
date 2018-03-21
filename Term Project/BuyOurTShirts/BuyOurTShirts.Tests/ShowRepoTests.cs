using BuyOurTShirts.Controllers;
using BuyOurTShirts.Models;
using BuyOurTShirts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BuyOurTShirts.Tests
{
   public class ShowRepoTests
    {
        IShowRepository repo;
        ShowController controller;

        public ShowRepoTests()
        {
            repo = new TestShowRepo();
            controller = new ShowController(repo);
        }

        [Fact]
        public void AddShowTest()
        {
            Assert.Empty(repo.GetAllShows());
            repo.Add(new Show { name = "The Super Awesome Show", date = DateTime.Parse("4/20/2018 4:20PM"), cost = 1, minAge = 18, type = ShowType.Public, description = "This show really will be the best, that is why it is the super awsome show." });
            Assert.Single(repo.GetAllShows());

        }
        [Fact]
        public void DeleteShowTest()
        {
            Assert.Empty(repo.GetAllShows());
            repo.Add(new Show { name = "The Super Awesome Show", date = DateTime.Parse("4/20/2018 4:20PM"), cost = 1, minAge = 18, type = ShowType.Public, description = "This show really will be the best, that is why it is the super awsome show." });
            Assert.Single(repo.GetAllShows());
            repo.Delete(repo.GetAllShows()[0].ID);
            Assert.Empty(repo.GetAllShows());

        }
        [Fact]
        public void GetAllShowsTest()
        {
            Assert.Empty(repo.GetAllShows());
            repo.Add(new Show { name = "The Super Awesome Show", date = DateTime.Parse("4/20/2018 4:20PM"), cost = 1, minAge = 18, type = ShowType.Public, description = "This show really will be the best, that is why it is the super awsome show." });
            Assert.Single(repo.GetAllShows());

        }

    }
}
