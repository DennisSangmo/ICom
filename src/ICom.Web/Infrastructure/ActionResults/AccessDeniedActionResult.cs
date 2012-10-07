using System.Web.Mvc;

namespace ICom.Web.Infrastructure.ActionResults {
    public class AccessDeniedActionResult : ViewResult {
        public AccessDeniedActionResult() {
            ViewName = "AccessDenied";
        }
    }
}