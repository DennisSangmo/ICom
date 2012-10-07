using System.Web.Mvc;
using ICom.Core.Entities.UserEntity;
using ICom.Core.Services;
using ICom.Web.Infrastructure.Authorization.Storage;
using StructureMap;

namespace ICom.Web.Infrastructure.ActionFilters {
    public class RetrieveUserAttribute : ActionFilterAttribute {
        public RetrieveUserAttribute() {
            Order = 2;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var userStorage = ObjectFactory.GetInstance<IStorage<User>>();
            var sessionUser = userStorage.Get(SessionKeys.User);

            if (sessionUser == null && filterContext.HttpContext.User.Identity.IsAuthenticated) {
                var userService = ObjectFactory.GetInstance<UserService>();
                var user = userService.Get(filterContext.HttpContext.User.Identity.Name);
                userStorage.Store(SessionKeys.User, user);
            }
        }
    }
}