using Microsoft.AspNetCore.Mvc;

namespace NatureBlog.Web.Controllers
{
    public class AboutMeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
