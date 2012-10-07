using System.Web.Mvc;
using ICom.Core.Domain;

namespace ICom.Web.Infrastructure.HtmlHelpers
{
    public static class HtmlHelperExtenssion
    {
        public static User User(this HtmlHelper helper) {
            return helper.ViewBag.User as User;
        }
    }
}