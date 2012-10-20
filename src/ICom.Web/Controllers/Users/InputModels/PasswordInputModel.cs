using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ICom.Web.Controllers.Users.InputModels {
    public class PasswordInputModel {
        [Required(ErrorMessage = "Ni m�ste ange ett l�senord!")]
        [MinLength(8, ErrorMessage = "L�senordet m�ste vara minst 8 tecken!")]
        [DisplayName("Nytt l�senord")]
        public string Password { get; set; }

        [DisplayName("Repitera l�senord")]
        public string PasswordRepeat { get; set; }
    }
}