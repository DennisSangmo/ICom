using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ICom.Core.Entities.UserEntity;

namespace ICom.Web.Areas.Admin.Controllers.UserAdmin.InputModels {
    public class CreateUserInputModel {
        [DisplayName("Namn")]
        [Required(ErrorMessage = "Ni m�ste ange ett namn!")]
        public string Name { get; set; }

        [DisplayName("Anv�ndartyp")]
        [Required(ErrorMessage = "Ni m�ste ange en anv�ndartyp!")]
        public UserType Type { get; set; }
    }
}