using Microsoft.AspNetCore.Mvc;

namespace Sportrs_Streaming_platform.Controllers
{
    public class LiveScreenController : Controller
    {
        public IActionResult LiveScreen()
        {
            return View();

        }
    }
}
