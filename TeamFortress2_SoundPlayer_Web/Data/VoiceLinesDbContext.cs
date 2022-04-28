using Microsoft.EntityFrameworkCore;
using TeamFortress2_SoundPlayer_Web.Models;
using TeamFortress2_SoundPlayer_Web.Models.Responses;
using TeamFortress2_SoundPlayer_Web.Models.VoiceCommands;

namespace TeamFortress2_SoundPlayer_Web.Data
{
    public class VoiceLinesDbContext : DbContext
    {
        public VoiceLinesDbContext(DbContextOptions<VoiceLinesDbContext> options) : base(options)
        {

        }

        public DbSet<Scout_ResponseModel> Scout_Responses { get; set; }
        public DbSet<Soldier_ResponseModel> Soldier_Responses { get; set; }
        public DbSet<Pyro_ResponseModel> Pyro_Responses { get; set; }
        public DbSet<Demoman_ResponseModel> Demoman_Responses { get; set; }
        public DbSet<Heavy_ResponseModel> Heavy_Responses { get; set; }
        public DbSet<Engineer_ResponseModel> Engineer_Responses { get; set; }
        public DbSet<Medic_ResponseModel> Medic_Responses { get; set; }
        public DbSet<Sniper_ResponseModel> Sniper_Responses { get; set; }
        public DbSet<Spy_ResponseModel> Spy_Responses { get; set; }

        public DbSet<Administrator_ResponseModel> Administrator_Responses { get; set; }
        public DbSet<HalloweenBosses_ResponseModel> HalloweenBosses_Responses { get; set; }
        public DbSet<Wheatley_ResponseModel> Wheatley_Responses { get; set; }
        public DbSet<MissPauling_ResponseModel> MissPauling_Responses { get; set; }
        public DbSet<DavyJones_ResponseModel> DavyJones_Responses { get; set; }


        public DbSet<Scout_VoiceCommandModel> Scout_VoiceCommands { get; set; }
        public DbSet<Soldier_VoiceCommandModel> Soldier_VoiceCommands { get; set; }
        public DbSet<Pyro_VoiceCommandModel> Pyro_VoiceCommands { get; set; }
        public DbSet<Demoman_VoiceCommandModel> Demoman_VoiceCommands { get; set; }
        public DbSet<Heavy_VoiceCommandModel> Heavy_VoiceCommands { get; set; }
        public DbSet<Engineer_VoiceCommandModel> Engineer_VoiceCommands { get; set; }
        public DbSet<Medic_VoiceCommandModel> Medic_VoiceCommands { get; set; }
        public DbSet<Sniper_VoiceCommandModel> Sniper_VoiceCommands { get; set; }
        public DbSet<Spy_VoiceCommandModel> Spy_VoiceCommands { get; set; }
    }
}
