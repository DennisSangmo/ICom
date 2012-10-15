using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        public User() {
            Type = UserType.Normal;
        }

        public User(string name, string username, string password, string email) : this() {
            Name = name;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}