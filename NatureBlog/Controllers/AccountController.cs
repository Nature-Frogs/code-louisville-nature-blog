using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Services;
using NatureBlog.Web.Models;
using System.Security.Claims;

namespace NatureBlog.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserAuthenticationService _authSvc;
        public AccountController(IUserAuthenticationService authSvc)
        {
            _authSvc = authSvc;
        }
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

            if(await _authSvc.IsUserAuthentic(model.UserName, model.Password))
            {
                await MakeClaims();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        private async Task MakeClaims()
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim(ClaimTypes.Name, "The Adminstrator")
                };

            var identity = new ClaimsIdentity(claims, AppConstants.COOKIE_AUTH_SCHEME_NAME);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(AppConstants.COOKIE_AUTH_SCHEME_NAME, principal);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
