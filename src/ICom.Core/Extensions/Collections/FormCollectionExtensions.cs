using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace ICom.Core.Extensions.Collections {
    public static class FormCollectionExtensions {
         public static IEnumerable<SelectListItem> InsertDummy(this IEnumerable<SelectListItem> list, string text, string value) {
             var dummy = new SelectListItem {Text = text, Value = value};

             var tmp = list.ToList();
             tmp.Insert(0, dummy);

             return tmp;
         }
    }
}