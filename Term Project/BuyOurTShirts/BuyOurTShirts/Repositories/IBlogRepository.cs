using BuyOurTShirts.Models;
using System.Collections.Generic;

namespace BuyOurTShirts.Repositories
{
    public interface IBlogRepository
    {
        List<Blog> GetAllPosts();
        Blog GetPostById(int id);
        int Add(Blog blog);
        int Edit(Blog blog);
        int Delete(int id);
       Blog GetLatestPost();
    }
}