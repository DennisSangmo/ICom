﻿using System.Web.Mvc;
using ICom.Core.AuthSecurity;
using ICom.Core.Services;
using ICom.Web.Areas.Admin.Controllers.UserAdmin.InputModels;
using ICom.Web.Areas.Admin.Controllers.UserAdmin.ViewModels;

namespace ICom.Web.Areas.Admin.Controllers.UserAdmin {
    public class UserAdminController : BaseAdminController {
        private readonly UserService _userService;

        public UserAdminController(UserService userService) {
            _userService = userService;
        }

        public ActionResult Index() {
            var users = _userService.GetAll();
            return View(new IndexViewModel(users));
        }

        public ActionResult Settings(int id) {
            var user = _userService.Get(id);
            return View("Settings", new SettingsViewModel(user));
        }

        [HttpPost]
        public ActionResult Settings(int id, UserInputModel inputModel) {
            if (!ModelState.IsValid)
                return Settings(id);

            var user = _userService.Get(id);

            user.Name = inputModel.Name;
            user.Username = inputModel.Username;

            return RedirectToAction("Settings", new {id});
        }

        [HttpPost]
        public ActionResult ChangePassword(int id, PasswordInputModel passwordInputModel) {
            if(passwordInputModel.Password != passwordInputModel.PasswordRepeat)
                ModelState.AddModelError("passwordInputModel.PasswordRepeat", "Det repiterade lösenordet skiljer sig!");

            if (!ModelState.IsValid)
                return Settings(id);

            var user = _userService.Get(id);
            user.Password = Encrypter.Encrypt(passwordInputModel.Password);

            return RedirectToAction("Settings", new {id});
        }
    }
}