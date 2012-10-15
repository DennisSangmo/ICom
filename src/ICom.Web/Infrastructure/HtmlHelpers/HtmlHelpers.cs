using System.Web.Mvc;
using System.Linq;

namespace ICom.Web.Infrastructure.HtmlHelpers {
    public static class HtmlHelpers {
        public static MvcHtmlString RenderFlash(this HtmlHelper helper) {
            if (helper.ViewContext.TempData.Keys.All(x => x != "FlashClass"))
                return MvcHtmlString.Empty;

            var @class = helper.ViewContext.TempData["FlashClass"] as string;
            var message = helper.ViewContext.TempData["FlashMessage"] as string;
            var tb = new TagBuilder("div");

            tb.Attributes.Add("class", "flash " + @class);

            tb.SetInnerText(message);

            return MvcHtmlString.Create(tb.ToString());
        }
    }
}