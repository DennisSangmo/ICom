using ICom.Core.Entities.UserEntity;

namespace ICom.Web.Areas.Admin.Controllers.UserAdmin.ViewModels {
    public class CreateViewModel {
        public User User { get; set; }
        public CreateViewModel() {
            User = new User();
        }
    }
}