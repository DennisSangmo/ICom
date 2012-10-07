using System.Web.Mvc;
using ICom.Core.Entities;
using ICom.Core.Entities.UserEntity;
using ICom.Core.Services;
using ICom.Web.Infrastructure.Authorization.Storage;
using StructureMap;

namespace ICom.Web.Infrastructure.ActionFilters
{
    public class RetrieveUserAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var userStorage = ObjectFactory.GetInstance<IStorage<User>>();
            var sessionUser = userStorage.Get(SessionKeys.User);

            if (sessionUser == null && filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var userService = ObjectFactory.GetInstance<UserService>();
                var user = userService.Get(filterContext.HttpContext.User.Identity.Name);
                userStorage.Store(SessionKeys.User, user);
            }
        }
    }
}