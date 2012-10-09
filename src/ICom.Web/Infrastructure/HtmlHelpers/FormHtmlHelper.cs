using System.Web.Mvc;

namespace ICom.Web.Infrastructure.HtmlHelpers {
    public static class FormHtmlHelper {
        /// <summary>
        /// Submit button (<button type ="submit"></button>)
        /// </summary>
        public static MvcHtmlString Submit(this HtmlHelper helper, string text, string @class = "", string id = "") {
            var button = new TagBuilder("button");
            button.Attributes.Add("type", "submit");
            button.SetInnerText(text);

            if (!string.IsNullOrEmpty(@class))
                button.Attributes.Add("class", @class);

            if(!string.IsNullOrEmpty(id))
                button.Attributes.Add("id", id);

            return MvcHtmlString.Create(button.ToString());
        }
    }
}