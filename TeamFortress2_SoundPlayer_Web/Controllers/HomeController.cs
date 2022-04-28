using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TeamFortress2_SoundPlayer_Web.Controllers
{
    public class HomeController : Controller
    {
        //Routing the Index page
        [Route("", Name = "HomePage")]
        public IActionResult Index()
        {
            return View();
        }

        //Routing the About page
        [Route("About", Name = "About")]
        public IActionResult About()
        {
            return View();
        }
    }
}