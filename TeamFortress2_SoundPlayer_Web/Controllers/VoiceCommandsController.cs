using Microsoft.AspNetCore.Mvc;
using TeamFortress2_SoundPlayer_Web.Data;

namespace TeamFortress2_SoundPlayer_Web.Controllers
{
    public class VoiceCommandsController : Controller
    {
        //Making an instance of the DataBase
        private readonly VoiceLinesDbContext DB;
        public VoiceCommandsController(VoiceLinesDbContext db)
        {
            DB = db;
        }

        //If someone only tries to reach the "localhost/VoiceCommands" page, they will be redirected to the main page.
        [Route("VoiceCommands", Name = "Voice")]
        public IActionResult VoiceCommand()
        {
            return RedirectToRoute("HomePage");
        }

        //Configuring the rout for the class VoiceCommands page
        //Depending on the passed paramater, the right table will be loaded.
        [Route("VoiceCommands/{mercenary}", Name = "VoiceCommand")]
        public IActionResult VoiceCommands(string mercenary)
        {
            //The model had to be made "dynamic" since I HAVE to tell the view what type of object it gets, but tall table has its own object
            dynamic model = null;
            switch (mercenary)
            {
                case "Scout":
                    model = DB.Scout_VoiceCommands.ToList();
                    break;
                case "Soldier":
                    model = DB.Soldier_VoiceCommands.ToList();
                    break;
                case "Pyro":
                    model = DB.Pyro_VoiceCommands.ToList();
                    break;
                case "Demoman":
                    model = DB.Demoman_VoiceCommands.ToList();
                    break;
                case "Heavy":
                    model = DB.Heavy_VoiceCommands.ToList();
                    break;
                case "Engineer":
                    model = DB.Engineer_VoiceCommands.ToList();
                    break;
                case "Medic":
                    model = DB.Medic_VoiceCommands.ToList();
                    break;
                case "Sniper":
                    model = DB.Sniper_VoiceCommands.ToList();
                    break;
                case "Spy":
                    model = DB.Spy_VoiceCommands.ToList();
                    break;
            }

            return View(model);
        }
    }
}
