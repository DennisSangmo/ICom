namespace ICom.Core.Entities.UserEntity {
    public class User : Entity {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual UserType Type { get; set; }

        public User() {
            Type = UserType.Normal;
        }

        public User(string name, string username, string password) : this() {
            Name = name;
            Username = username;
            Password = password;
        }
    }
}