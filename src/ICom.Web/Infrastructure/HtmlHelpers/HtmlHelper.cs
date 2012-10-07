using System.Web.Mvc;
using ICom.Core.Entities.UserEntity;

namespace ICom.Web.Infrastructure.HtmlHelpers
{
    public static class UserHtmlHelperExt
    {
        public static User User(this HtmlHelper helper) {
            return helper.ViewBag.User as User;
        }

        public static bool IsAdmin(this HtmlHelper helper) {
            return User(helper).Type >= UserType.Administrator;
        }
    }
}