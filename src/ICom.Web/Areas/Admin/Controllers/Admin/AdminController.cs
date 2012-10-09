using System.Web.Mvc;

namespace ICom.Web.Areas.Admin.Controllers.Admin {
    public class AdminController : BaseAdminController {
        public ActionResult Index() {
            return View();
        }
    }
}