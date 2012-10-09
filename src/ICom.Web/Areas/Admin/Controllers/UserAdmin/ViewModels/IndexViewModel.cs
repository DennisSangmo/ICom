using System.Collections.Generic;
using ICom.Core.Entities.UserEntity;
using ICom.Core.Extensions.Collections;

namespace ICom.Web.Areas.Admin.Controllers.UserAdmin.ViewModels {
    public class IndexViewModel {
        public IEnumerable<User> Users { get; set; }

        public IndexViewModel(IEnumerable<User> users) {
            Users = users.OrderByName();
        }
    }
}