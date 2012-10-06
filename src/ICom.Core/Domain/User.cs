namespace ICom.Core.Domain
{
    public class User : Entity
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}