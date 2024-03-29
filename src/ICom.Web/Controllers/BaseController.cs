﻿using System.Web.Mvc;
using ICom.Core.Entities.UserEntity;
using ICom.Web.Infrastructure.ActionFilters;
using ICom.Web.Infrastructure.Authorization.Storage;

namespace ICom.Web.Controllers {
    [Transactional]
    [Authorize]
    [RetrieveUser]
    public class BaseController : Controller {
        public IStorage<User> UserStorage { get; set; }

        private User _cacheUser;
        public new User User { get { return _cacheUser ?? (_cacheUser = UserStorage.Get(SessionKeys.User)); } }

        protected override void OnResultExecuting(ResultExecutingContext filterContext) {
            filterContext.Controller.ViewBag.User = User;
        }

        public void FlashSuccess(string message) {
            TempData.Add("FlashClass", "success");
            TempData.Add("FlashMessage", message);
        }

        public void FlashWarning(string message) {
            TempData.Add("FlashClass", "warning");
            TempData.Add("FlashMessage", message);
        }

        public void FlashError(string message) {
            TempData.Add("FlashClass", "error");
            TempData.Add("FlashMessage", message);
        }
    }
}
