using System.Collections.Generic;
using System.Linq;
using ICom.Core.Entities.UserEntity;

namespace ICom.Core.Extensions.Collections {
    public static class UserCollectionExtensions {
        public static IEnumerable<User> OrderByName(this IEnumerable<User> users) {
            return users.OrderBy(x => x.Name);
        }
    }
}