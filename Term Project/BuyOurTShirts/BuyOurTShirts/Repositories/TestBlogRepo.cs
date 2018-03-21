using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuyOurTShirts.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BuyOurTShirts.Repositories
{
    public class TestBlogRepo : IBlogRepository
    {
        public List<Blog> BlogList = new List<Blog>();



        public int Add(Blog blog)
        {
            BlogList.Add(blog);
            return 1;
        }

        public int Delete(int id)
        {
            Blog b = BlogList.FirstOrDefault(a => a.ID == id);
            BlogList.Remove(b);
            return 1;
        }

        public int Edit(Blog blog)
        {
            return 1;
        }

        public List<Blog> GetAllPosts()
        {
            List<Blog> blog = BlogList.ToList();
            return blog;
        }

        public Blog GetPostById(int id)
        {
            var bl = BlogList.FirstOrDefault(a => a.ID == id);
            return bl;
        }

        public Blog GetLatestPost() => BlogList.LastOrDefault();
        





    }
}