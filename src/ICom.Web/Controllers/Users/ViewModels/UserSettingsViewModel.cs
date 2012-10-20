using ICom.Core.Entities.UserEntity;
using ICom.Web.Controllers.Users.InputModels;

namespace ICom.Web.Controllers.Users.ViewModels
{
    public class UserSettingsViewModel
    {
        public User User { get; set; }

        public PasswordInputModel PasswordInputModel { get; set; }

        public UserSettingsViewModel(User user)
        {
            User = user;
            PasswordInputModel = new PasswordInputModel();
        }
    }
}