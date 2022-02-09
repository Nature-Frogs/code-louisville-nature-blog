using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Web.Models;
using System.Security.Claims;

namespace NatureBlog.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid == false)
            {
                return View("Index", model);
            }

            if(model.UserName == "admin" && model.Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim(ClaimTypes.Name, "The Adminstrator")
                };

                var identity = new ClaimsIdentity(claims, AppConstants.COOKIE_AUTH_SCHEME_NAME);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(AppConstants.COOKIE_AUTH_SCHEME_NAME, principal);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
