using System.Collections.Generic;
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

        public static MvcHtmlString HardDrawDropDown(this HtmlHelper helper, string name, IEnumerable<SelectListItem> items)
        {
            var select = new TagBuilder("select");
            select.Attributes.Add("name", name);
            select.GenerateId(name);

            foreach (var listItem in items)
            {
                var option = new TagBuilder("option");
                option.SetInnerText(listItem.Text);
                option.Attributes.Add("value", listItem.Value);
                if(listItem.Selected)
                    option.Attributes.Add("selected", "selected");

                select.InnerHtml += option.ToString();
            }

            return MvcHtmlString.Create(select.ToString());
        }
    }
}