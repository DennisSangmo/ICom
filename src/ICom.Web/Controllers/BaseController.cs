using System.Web.Mvc;
using ICom.Core.Entities.UserEntity;
using ICom.Web.Infrastructure.ActionFilters;
using ICom.Web.Infrastructure.Authorization.Storage;

namespace ICom.Web.Controllers
{
    [Authorize]
    [RetrieveUser]
    [Transactional]
    public class BaseController : Controller
    {
        public IStorage<User> UserStorage { get; set; }

        private User _cacheUser;
        public new User User { get { return _cacheUser ?? (_cacheUser = UserStorage.Get(SessionKeys.User)); } }

        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
            filterContext.Controller.ViewBag.User = User;
            base.OnActionExecuting(filterContext);
        }
    }
}
