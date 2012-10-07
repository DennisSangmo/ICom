using System.Web.Mvc;
using ICom.Core.Entities.UserEntity;
using ICom.Web.Infrastructure.ActionResults;
using ICom.Web.Infrastructure.Authorization.Storage;
using StructureMap;

namespace ICom.Web.Infrastructure.ActionFilters {
    public class AdminsOnlyAttribute : ActionFilterAttribute {

        private readonly IStorage<User> _storeage;

        public AdminsOnlyAttribute() {
            _storeage = ObjectFactory.GetInstance<IStorage<User>>();
            Order = 5;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var user = _storeage.Get(SessionKeys.User);

            if (user.Type < UserType.Administrator) {
                filterContext.Result = new AccessDeniedActionResult();
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}