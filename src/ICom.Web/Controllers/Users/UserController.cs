using System.Web.Mvc;
using ICom.Core.AuthSecurity;
using ICom.Core.Entities.UserEntity;
using ICom.Core.Entities.UserInfoEntity;
using ICom.Core.Services;
using ICom.Web.Controllers.Users.InputModels;
using ICom.Web.Controllers.Users.ViewModels;
using ICom.Web.Infrastructure.Authorization.Storage;

namespace ICom.Web.Controllers.Users {
    public class UserController : BaseController {
        private readonly UserService _userService;
        private readonly IStorage<User> _storage;

        public UserController(UserService userService, IStorage<User> storage)
        {
            _userService = userService;
            _storage = storage;
        }

        public ActionResult Settings()
        {
            return View("Settings", new UserSettingsViewModel(User));
        }

        [HttpPost]
        public ActionResult Settings(User user)
        {
            if (!ModelState.IsValid)
                return Settings();

            var existingUser = _userService.Get(User.Id);

            if(User.IsAdmin)
                existingUser.BigUpdate(user);
            else
                existingUser.SmallUpdate(user);

            _storage.Store(SessionKeys.User, existingUser);

            FlashSuccess("Dina inställningar har uppdaterats!");
            return RedirectToAction("Settings");
        }

        [HttpPost]
        public ActionResult ChangePassword(PasswordInputModel passwordInputModel) {
            if (passwordInputModel.Password != passwordInputModel.PasswordRepeat)
                ModelState.AddModelError("passwordInputModel.PasswordRepeat", "Det repiterade lösenordet skiljer sig!");

            if (!ModelState.IsValid)
                return Settings();

            var existingUser = _userService.Get(User.Id);
            existingUser.Password = Encrypter.Encrypt(passwordInputModel.Password);

            _storage.Store(SessionKeys.User, existingUser);

            FlashSuccess("Lösenordet har uppdaterats!");
            return RedirectToAction("Settings");
        }

        [HttpPost]
        public ActionResult CreateInfo(UserInfo newUserInfo)
        {
            if (!ModelState.IsValid)
                return Settings();

            var existingUser = _userService.Get(User.Id);
            existingUser.AddInfo(newUserInfo);

            _storage.Store(SessionKeys.User, existingUser);

            FlashSuccess("Informationen har lagts till!");
            return RedirectToAction("Settings");
        }
    }
}