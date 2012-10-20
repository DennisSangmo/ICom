using System.Web.Mvc;
using ICom.Core.AuthSecurity;
using ICom.Core.Entities.UserEntity;
using ICom.Core.Services;
using ICom.Web.Controllers.Users.InputModels;
using ICom.Web.Controllers.Users.ViewModels;

namespace ICom.Web.Controllers.Users {
    public class UserController : BaseController {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult Settings(int id)
        {
            var user = _userService.Get(id);
            return View("Settings", new UserSettingsViewModel(user));
        }

        [HttpPost]
        public ActionResult Settings(int id, User user)
        {
            if (!ModelState.IsValid)
                return Settings(id);

            var existingUser = _userService.Get(id);

            if(User.IsAdmin)
                existingUser.BigUpdate(user);
            else
                existingUser.SmallUpdate(user);

            FlashSuccess("Dina inställningar har uppdaterats!");
            return RedirectToAction("Settings", new {id});
        }

        [HttpPost]
        public ActionResult ChangePassword(int id, PasswordInputModel passwordInputModel) {
            if (passwordInputModel.Password != passwordInputModel.PasswordRepeat)
                ModelState.AddModelError("passwordInputModel.PasswordRepeat", "Det repiterade lösenordet skiljer sig!");

            if (!ModelState.IsValid)
                return Settings(id);

            var user = _userService.Get(id);
            user.Password = Encrypter.Encrypt(passwordInputModel.Password);

            FlashSuccess("Lösenordet har uppdaterats!");
            return RedirectToAction("Settings", new { id });
        }
    }
}