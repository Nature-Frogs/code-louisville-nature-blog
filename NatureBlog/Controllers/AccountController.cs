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
            if (ModelState.IsValid == false)
            {
                return View("Index", model);
            }

            var authenticationResult = await _authSvc.RequestAuthenticatedUser(model.UserName, model.Password);
            if (authenticationResult.IsUserAuthenticated)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, AppConstants.DEFAULT_ROLE),
                    new Claim(ClaimTypes.Name, authenticationResult.UserName),
                    new Claim(ClaimTypes.Sid, authenticationResult.Userid.ToString())
                };

                var identity = new ClaimsIdentity(claims, AppConstants.COOKIE_AUTH_SCHEME_NAME);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(AppConstants.COOKIE_AUTH_SCHEME_NAME, principal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Invalid", "Invalid Username / Password.");
                return View("Index", model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
