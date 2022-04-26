using Microsoft.AspNetCore.Mvc;
using PasswordGenerator_Web.Models;
using PasswordGeneratorLibrary;
using System.Diagnostics;

namespace PasswordGenerator_Web.Controllers
{
    public class HomeController : Controller
    {
        // Creating the necessary variables.
        PasswordGeneratorModel PWL = new PasswordGeneratorModel();

        // Changing the route of the page, and returning the associated view.
        [Route("", Name = "HomePage")]
        public IActionResult Index()
        {
            return View();
        }

        // After a successful post, the number of numbers, letters, symbols are saved into the correspondent property,
        // from the "PasswordGeneratorLibrary".
        // Following that the password is generated and saved into a session variable, which is deleted after 10 seconds.
        [HttpPost, Route("", Name = "HomePage")]
        public IActionResult Index(PasswordModel obj)
        {
            PWL.letters = obj.NumberOfLetters;
            PWL.numbers = obj.NumberOfNumbers;
            PWL.symbols = obj.NumberOfSymbols;
            HttpContext.Session.SetString("result", PWL.PasswordMixer());

            return RedirectToRoute("ResultPage");
        }

        // Returning to the HomePage if the session variable is empty, otherwise returning to the ResultPage
        [Route("Result", Name = "ResultPage")]
        public IActionResult Result()
        {
            if (HttpContext.Session.GetString("result") != null)
                return View();

            return RedirectToRoute("HomePage");
        }
    }
}