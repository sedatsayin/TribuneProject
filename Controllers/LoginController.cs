using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Boreass.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Boreass.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login login)
        {
            if (LoginUser(login.Username, login.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Username)
            };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        private bool LoginUser(string username, string password)
        {
            if (username == "sedat" && password == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}