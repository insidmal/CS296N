using BuyOurTShirts.Controllers;
using BuyOurTShirts.Models;
using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Xunit;

namespace BuyOurTShirts.Tests
{
    public class BlogRepoTests
    {
        IBlogRepository repo;
        BlogController controller;
        private UserManager<Account> userManager;
        public BlogRepoTests()
        {
            repo = new TestBlogRepo();
            controller = new BlogController(repo, userManager);
        }

        [Fact]
        public void AddBlogTest()
        {
            var count = repo.GetAllPosts().Count;
            count++;
                Blog b = new Blog { title = "blah", content = "blah2", summary="blah3"};
            repo.Add(b);
            Assert.Equal(count,repo.GetAllPosts().Count);
        }

        [Fact]
        public void GetLatestBlogTest()
        {
            repo.Add(new Blog { title = "new post", content = "blah2", summary = "blah3" });
            Assert.Equal("new post",repo.GetLatestPost().title);
        }

        [Fact] 
        public void TestDeleteBlog()
        {
            var count = repo.GetAllPosts().Count;
            count++;
            Blog b = new Blog { title = "post to delete", content = "blah2", summary = "blah3" };
            repo.Add(b);
            Assert.Equal(count, repo.GetAllPosts().Count);
            repo.Delete(repo.GetLatestPost().ID);
            count--;
            Assert.Equal(count, repo.GetAllPosts().Count);
        }

        [Fact]
        public void GetPostByIdTest()
        {
            repo.Add(new Blog { title = "get id test", content = "blah2", summary = "blah3" });
            Assert.Equal("get id test", repo.GetPostById(repo.GetLatestPost().ID).title);
        }

    }
}
