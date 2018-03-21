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

            if (!context.Blog.Any())
            {
                context.Blog.Add(new Blog { title = "This is a Blog Post", summary = "A summary of the most recent blog posted is listed on the home page, you can click it's title to view the full post.", content = "This is the actual blog post, here is some text.  It really doesn't mean anything, yet here it is anyway!" });
                context.SaveChanges();
            }
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