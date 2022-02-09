using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NatureBlog.Web.Controllers
{
    [Authorize(Policy = AppConstants.BLOG_ENTRY_POLICY_NAME)]
    public class AddEntry : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
