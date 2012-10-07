using ICom.Web.Controllers;
using ICom.Web.Infrastructure.ActionFilters;

namespace ICom.Web.Areas.Admin.Controllers {
    [AdminsOnly]
    public class BaseAdminController : BaseController {}
}