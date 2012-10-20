using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ICom.Web.Controllers.Users.InputModels {
    public class PasswordInputModel {
        [Required(ErrorMessage = "Ni måste ange ett lösenord!")]
        [MinLength(8, ErrorMessage = "Lösenordet måste vara minst 8 tecken!")]
        [DisplayName("Nytt lösenord")]
        public string Password { get; set; }

        [DisplayName("Repitera lösenord")]
        public string PasswordRepeat { get; set; }
    }
}