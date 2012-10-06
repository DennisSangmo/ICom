using System.Web.Mvc;
using ICom.Core.Services;

namespace ICom.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
