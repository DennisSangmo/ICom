using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ICom.Core.Entities.UserEntity;
using ICom.Core.Entities.UserInfoEntity;
using ICom.Core.Extensions;
using ICom.Web.Controllers.Users.InputModels;
using ICom.Core.Extensions.Collections;

namespace ICom.Web.Controllers.Users.ViewModels
{
    public class UserSettingsViewModel
    {
        public User User { get; set; }

        public UserInfo NewUserInfo { get; set; }
        public PasswordInputModel PasswordInputModel { get; set; }

        public IEnumerable<SelectListItem> UserInfoTypes { get; set; }

        public UserSettingsViewModel(User user)
        {
            User = user;

            NewUserInfo = new UserInfo();
            PasswordInputModel = new PasswordInputModel();

            UserInfoTypes = Enum.GetValues(typeof(UserInfoType))
                                .Cast<UserInfoType>()
                                .ToSelectList(x => x.GetDescription(), x => ((int)x).ToString());
        }
    }
}