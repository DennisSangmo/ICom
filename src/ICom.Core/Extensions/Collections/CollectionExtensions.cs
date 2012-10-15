using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace ICom.Core.Extensions.Collections {
    public static class CollectionExtensions {
         public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> list, Func<T, string> text, Func<T, string> value, Func<T, bool> selected = null) {
             return list.Select(x => new SelectListItem {
                                                            Text = text(x),
                                                            Value = value(x),
                                                            Selected = selected != null && selected(x)
                                                        });
         }
    }
}