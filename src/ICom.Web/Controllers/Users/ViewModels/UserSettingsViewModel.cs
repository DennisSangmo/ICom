using ICom.Core.Entities.UserEntity;

namespace ICom.Web.Controllers.Users.ViewModels
{
    public class UserSettingsViewModel
    {
        public User User { get; set; }

        public UserSettingsViewModel(User user)
        {
            User = user;
        }
    }
}