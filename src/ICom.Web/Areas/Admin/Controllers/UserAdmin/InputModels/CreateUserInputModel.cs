using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ICom.Core.Entities.UserEntity;

namespace ICom.Web.Areas.Admin.Controllers.UserAdmin.InputModels {
    public class CreateUserInputModel {
        [DisplayName("Namn")]
        [Required(ErrorMessage = "Ni måste ange ett namn!")]
        public string Name { get; set; }

        [DisplayName("Användartyp")]
        [Required(ErrorMessage = "Ni måste ange en användartyp!")]
        public UserType Type { get; set; }
    }
}