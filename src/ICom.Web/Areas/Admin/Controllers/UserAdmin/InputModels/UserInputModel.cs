using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ICom.Core.Entities.UserEntity;

namespace ICom.Web.Areas.Admin.Controllers.UserAdmin.InputModels {
    public class UserInputModel {
        [Required(ErrorMessage = "Ni m�ste ange ett namn!")]
        [DisplayName("Namn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ni m�ste ange ett anv�ndarnamn!")]
        [DisplayName("Anv�ndarnamn")]
        public string Username { get; set; }

        public UserInputModel() {}

        public UserInputModel(User user) {
            Name = user.Name;
            Username = user.Username;
        }
    }
}