using Microsoft.AspNetCore.Mvc;
using NatureBlog.Web.Models;
using System.Diagnostics;
using NatureBlog.Services;

namespace NatureBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostService _blogPostService;

        public HomeController(ILogger<HomeController> logger, IBlogPostService blogPostService)
        {
            _logger = logger;
            _blogPostService = blogPostService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _blogPostService.GetBlogPosts();
            return View(posts);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}