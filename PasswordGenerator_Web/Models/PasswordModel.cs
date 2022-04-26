using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PasswordGenerator_Web.Models
{
    // This model used for the form, the submited results will be saved to an object based on this model.
    public class PasswordModel
    {
        [Required, DisplayName("Length of the password")]
        public int LengthOfPassword { get; set; }
        [DisplayName("Number of letters")]
        public int NumberOfLetters { get; set; }
        [DisplayName("Number of numbers")]
        public int NumberOfNumbers { get; set; }
        [DisplayName("Number of symbols")]
        public int NumberOfSymbols { get; set; }
    }
}
