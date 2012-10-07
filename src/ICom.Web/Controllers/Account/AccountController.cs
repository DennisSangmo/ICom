using System.Web.Mvc;
using ICom.Core.Entities.UserEntity;
using ICom.Core.Services;
using ICom.Web.Controllers.Account.InputModels;
using ICom.Web.Controllers.Account.ViewModels;
using ICom.Web.Infrastructure.ActionFilters;
using ICom.Web.Infrastructure.Authorization.Storage;

namespace ICom.Web.Controllers.Account {
    [Transactional]
    public class AccountController : Controller {
        private readonly UserService _userService;
        private readonly IStorage<User> _storage;

        public AccountController(UserService userService, IStorage<User> storage) {
            _userService = userService;
            _storage = storage;
        }

        public ActionResult Login() {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginInputModel inputmodel, string returnUrl) {
            var user = _userService.Login(inputmodel.UserName, inputmodel.Password);

            if(user == null) {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return Login();
            }

            _storage.Store(SessionKeys.User, user);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout() {
            _storage.Remove(SessionKeys.User);

            return RedirectToAction("Index", "Home");
        }
    }
}
