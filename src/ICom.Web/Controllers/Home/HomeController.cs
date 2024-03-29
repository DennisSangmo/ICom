using System.Web.Mvc;

namespace ICom.Web.Controllers.Home {
    public class HomeController : BaseController {
        public ActionResult Index() {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
