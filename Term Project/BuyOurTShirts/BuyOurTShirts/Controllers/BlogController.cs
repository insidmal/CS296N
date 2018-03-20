using BuyOurTShirts.Models;
using BuyOurTShirts.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuyOurTShirts.Controllers
{
    public class BlogController : Controller
    {

        private IBlogRepository blogRepo;
        private UserManager<Account> userManager;



        public BlogController(IBlogRepository bR, UserManager<Account> uM)
        {
            blogRepo = bR;

        }

        // GET: Blog
        public IActionResult Index() =>View(blogRepo.GetAllPosts());
        public IActionResult Post(int id) => View(blogRepo.GetPostById(id));
        [Authorize(Roles = "Band Member")]
        public IActionResult Create() => View();
        [Authorize(Roles = "Band Member")]
        public IActionResult Edit(int id) => View(blogRepo.GetPostById(id));

        [Authorize(Roles = "Band Member")]
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            blog.AccountId = GetCurrentUserId();
            blogRepo.Add(blog);
            return View("Post", blog);
        }
        [Authorize(Roles = "Band Member")]
        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            blog.AccountId = GetCurrentUserId();
            blogRepo.Edit(blog);
            return View("Post", blog);
        }

        [Authorize(Roles = "Band Member")]
        public IActionResult Delete(int id)
        {
            var blog = blogRepo.GetPostById(id);
            blogRepo.Delete(id);
            return View("Index", blogRepo.GetAllPosts());
        }



        public string GetCurrentUserId() => userManager.GetUserAsync(HttpContext.User).Result.Id ?? userManager.FindByEmailAsync("contact@conquest-marketing.com").Result.Id;


    }
}