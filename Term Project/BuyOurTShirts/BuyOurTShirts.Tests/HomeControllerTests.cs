using BuyOurTShirts.Controllers;
using BuyOurTShirts.Models;
using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BuyOurTShirts.Tests
{
    public class HomeControllerTests
    {
        public HomeController hC = new HomeController(new TestBlogRepo());

        [Fact]
        public void IndexTest()
        {
            Assert.IsType<ViewResult>(hC.Index());

        }
    }
}
