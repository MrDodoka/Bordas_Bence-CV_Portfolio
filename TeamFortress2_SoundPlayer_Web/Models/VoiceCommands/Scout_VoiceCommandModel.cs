using System.ComponentModel.DataAnnotations;

namespace TeamFortress2_SoundPlayer_Web.Models.VoiceCommands
{
    public class Scout_VoiceCommandModel
    {
        [Key] public int Id { get; set; }

        [Required] public string Chategory { get; set; }

        [Required] public string SubChategory { get; set; }

        [Required] public string SubSubChategory { get; set; }

        [Required] public string Line { get; set; }

        [Required] public string Path { get; set; }
    }
}
