using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using TeamFortress2_SoundPlayer_Web.Data;
using TeamFortress2_SoundPlayer_Web.Models;

namespace TeamFortress2_SoundPlayer_Web.Controllers
{
    public class ResponsesController : Controller
    {
        //Making an instance of the DataBase
        private readonly VoiceLinesDbContext DB;
        public ResponsesController(VoiceLinesDbContext db)
        {
            DB = db;
        }

        //If someone only tries to reach the "localhost/Response" page, they will be redirected to the main page.
        [Route("Response", Name = "Resp")]
        public IActionResult Resp()
        {
            return RedirectToRoute("HomePage");
        }

        //Configuring the rout for the class Response page
        //Depending on the passed paramater, the right table will be loaded.
        [Route("Response/{mercenary}", Name = "Response")]
        public IActionResult Responses(string mercenary)
        {
            //The model had to be made "dynamic" since I HAVE to tell the view what type of object it gets, but tall table has its own object
            dynamic model = null;
            switch (mercenary)
            {
                case "Scout":
                    model = DB.Scout_Responses.ToList();
                    break;
                case "Soldier":
                    model = DB.Soldier_Responses.ToList();
                    break;
                case "Pyro":
                    model = DB.Pyro_Responses.ToList();
                    break;
                case "Demoman":
                    model = DB.Demoman_Responses.ToList();
                    break;
                case "Heavy":
                    model = DB.Heavy_Responses.ToList();
                    break;
                case "Engineer":
                    model = DB.Engineer_Responses.ToList();
                    break;
                case "Medic":
                    model = DB.Medic_Responses.ToList();
                    break;
                case "Sniper":
                    model = DB.Sniper_Responses.ToList();
                    break;
                case "Spy":
                    model = DB.Spy_Responses.ToList();
                    break;
                case "Administrator":
                    model = DB.Administrator_Responses.ToList();
                    break;
                case "Halloween_Bosses":
                    model = DB.HalloweenBosses_Responses.ToList();
                    break;
                case "Wheatley":
                    model = DB.Wheatley_Responses.ToList();
                    break;
                case "Miss_Pauling":
                    model = DB.MissPauling_Responses.ToList();
                    break;
            }

            return View(model);
        }
    }
}
