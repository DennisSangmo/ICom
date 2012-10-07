namespace ICom.Core.Entities.UserEntity {
    public class User : Entity
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual UserType Type { get; set; }

        public User() {
            Type = UserType.Normal;
        }
    }
}