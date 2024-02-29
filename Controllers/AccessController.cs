using Microsoft.AspNetCore.Mvc;
using Sportrs_Streaming_platform.Data;
using Sportrs_Streaming_platform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Sportrs_Streaming_platform.Controllers
{
    public class AccessController : Controller
    {
        private readonly MyApplicationDb context;

        public AccessController(MyApplicationDb context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    
        [HttpPost]
        public async Task<IActionResult> Login(User modelLogin)
        {
            // Assuming you have an instance of MyApplicationDb called 'context'
            var user = context.Admin.FirstOrDefault(u => u.UserName == modelLogin.UserName);

            if (user != null && modelLogin.Password == user.Password)
            {
                List<Claim> claims = new List<Claim>()
        {
                    
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("OtherProperties", "Example Role")
        };

                ClaimsIdentity claimIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLogin
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimIdentity), properties);

                return RedirectToAction("Index", "Home");
            }

            // Incorrect username or password
            ViewBag.Message = "Incorrect UserName or Password";

            return View();
        }



    }
}
