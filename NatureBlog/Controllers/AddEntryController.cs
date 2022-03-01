using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Services;
using NatureBlog.Web.Models;
using NatureBlog.Web.Utilities;
using System.Security.Claims;

namespace NatureBlog.Web.Controllers
{
    [Authorize(Policy = AppConstants.BLOG_ENTRY_POLICY_NAME)]
    public class AddEntryController : Controller
    {
        IBlogPostService _blogPostSvc;
        public AddEntryController(IBlogPostService blogPostService)
        {
            _blogPostSvc = blogPostService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(BlogEntryViewModel vm)
        {
            if (!ModelState.IsValid)
                return View("Index", vm);

            var svcResult = await _blogPostSvc.AddEntry(vm.Title, vm.Content, User.GetUserIdFromClaims());

            if (!svcResult.IsSuccessful && svcResult.ServiceException != null)
            {
                throw svcResult.ServiceException;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
