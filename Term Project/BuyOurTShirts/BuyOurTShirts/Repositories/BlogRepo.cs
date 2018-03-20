using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuyOurTShirts.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BuyOurTShirts.Repositories
{
    public class BlogRepo : IBlogRepository
    {


        private readonly BotsDbContext context;

        public BlogRepo(BotsDbContext ctx)
        {
            context = ctx;
        }

        public int Add(Blog blog)
        {
            context.Blog.Add(blog);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            Blog b = context.Blog.FirstOrDefault(a => a.ID == id);
            context.Blog.Remove(b);
            return context.SaveChanges();
        }

        public int Edit(Blog blog)
        {
            context.Blog.Update(blog);
            return context.SaveChanges();
        }

        public List<Blog> GetAllPosts()
        {
            List<Blog> blog = context.Blog.ToList();
            foreach (Blog sh in blog) sh.account = GetBlogAccount(sh.AccountId);
            return blog;
        }

        public Blog GetPostById(int id)
        {
            var bl = context.Blog.FirstOrDefault(a => a.ID == id);
            bl.account = GetBlogAccount(bl.AccountId);
            return bl;
        }

        public Blog GetLatestPost() => context.Blog.LastOrDefault();
        

        private Account GetBlogAccount(string id) => context.Account.FirstOrDefault(a => a.Id == id);




    }
}