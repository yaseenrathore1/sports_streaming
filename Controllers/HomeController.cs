using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Sportrs_Streaming_platform.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Sportrs_Streaming_platform.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult tbl()
        {
             return View();
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User_Session");
            return RedirectToAction("Login", "Access"); 
        }   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
