using ICom.Web.Areas.Admin.Controllers.UserAdmin.InputModels;

namespace ICom.Web.Areas.Admin.Controllers.UserAdmin.ViewModels {
    public class CreateViewModel {
        public CreateUserInputModel InputModel { get; set; }
        public CreateViewModel() {
            InputModel = new CreateUserInputModel();
        }
    }
}