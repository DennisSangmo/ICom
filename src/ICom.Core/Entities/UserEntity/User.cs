using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ICom.Core.Entities.UserInfoEntity;

namespace ICom.Core.Entities.UserEntity {
    public class User : Entity {
        [DisplayName("Användarnamn")]
        public virtual string Username { get; set; }

        [DisplayName("Lösenord")]
        public virtual string Password { get; set; }

        [DisplayName("Namn")]
        [Required(ErrorMessage = "Ni måste ange ett namn!")]
        public virtual string Name { get; set; }

        [DisplayName("Användartyp")]
        [Required(ErrorMessage = "Ni måste ange en användartyp!")]
        public virtual UserType Type { get; set; }

        [DisplayName("E-post")]
        [Required(ErrorMessage = "Ni måste ange en e-post adress")]
        public virtual string Email { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }

        public virtual bool IsAdmin { get { return Type >= UserType.Administrator; } }
        public virtual bool HasUserInfos { get { return UserInfos.Any(); } }

        public User() {
            Type = UserType.Normal;

            UserInfos = new List<UserInfo>();
        }

        public User(string name, string username, string password, string email) : this() {
            Name = name;
            Username = username;
            Password = password;
            Email = email;
        }

        /// <summary>
        /// Update all replaceable properties with the props of the parameter. Rekommended only for admins
        /// </summary>
        public virtual void BigUpdate(User user)
        {
            SmallUpdate(user);
            
            Username = user.Username;
            Type = user.Type;
        }

        /// <summary>
        /// Updates the properties the user itselves may update.
        /// </summary>
        public virtual void SmallUpdate(User user)
        {
            Name = user.Name;
            Email = user.Email;
        }

        public virtual void AddInfo(UserInfo userInfo)
        {
            userInfo.UserId = Id;
            userInfo.User = this;
            UserInfos.Add(userInfo);
        }

        public virtual void DeleteInfo(UserInfo info)
        {
            if (UserInfos.All(x => x.Id != info.Id))
                return;
            
            UserInfos.Remove(info);
        }
    }
}