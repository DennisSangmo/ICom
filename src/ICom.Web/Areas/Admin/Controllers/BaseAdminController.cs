using ICom.Web.Controllers;
using ICom.Web.Infrastructure.ActionFilters;

namespace ICom.Web.Areas.Admin.Controllers {
    [AdminsOnly]
    public class BaseAdminController : BaseController {
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