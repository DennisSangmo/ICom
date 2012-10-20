using ICom.Core.Entities.UserEntity;
using ICom.Web.Areas.Admin.Controllers.UserAdmin.InputModels;

namespace ICom.Web.Areas.Admin.Controllers.UserAdmin.ViewModels {
    public class SettingsViewModel {
        public User User { get; set; }

        public PasswordInputModel PasswordInputModel { get; set; }

        public SettingsViewModel(User user) {
            User = user;

            PasswordInputModel = new PasswordInputModel();
        }

    }
}