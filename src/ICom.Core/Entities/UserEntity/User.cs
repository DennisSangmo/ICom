using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ICom.Core.Entities.UserEntity {
    public class User : Entity {
        [DisplayName("Anv�ndarnamn")]
        public virtual string Username { get; set; }

        [DisplayName("L�senord")]
        public virtual string Password { get; set; }

        [DisplayName("Namn")]
        [Required(ErrorMessage = "Ni m�ste ange ett namn!")]
        public virtual string Name { get; set; }

        [DisplayName("Anv�ndartyp")]
        [Required(ErrorMessage = "Ni m�ste ange en anv�ndartyp!")]
        public virtual UserType Type { get; set; }

        [DisplayName("E-post")]
        [Required(ErrorMessage = "Ni m�ste ange en e-post adress")]
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