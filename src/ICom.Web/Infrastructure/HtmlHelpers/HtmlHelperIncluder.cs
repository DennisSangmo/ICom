using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ICom.Core.Entities.UserEntity;
using ICom.Core.Extensions.Collections;
using ICom.Core.Extensions;

namespace ICom.Web.Infrastructure.HtmlHelpers {
    public static class HtmlHelperIncluder {
        public static UserHelper UserHelper(this HtmlHelper helper) {
            return new UserHelper(helper);
        }
    }

    public class UserHelper {
        public HtmlHelper Helper { get; set; }

        public UserHelper(HtmlHelper helper) {
            Helper = helper;
        }

        public IEnumerable<SelectListItem> TypeDropDown(string dummyText = "", UserType selected = UserType.Normal) {
            var types = Enum.GetValues(typeof (UserType)).Cast<UserType>().ToSelectList(x => x.GetDescription(), x => ((int)x).ToString(), x => x == selected);

            if (dummyText != "")
                types.InsertDummy("Användartyp", "0");

            return types;
        }
    }
}