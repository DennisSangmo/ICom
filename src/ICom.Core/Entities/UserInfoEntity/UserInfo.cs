using ICom.Core.Entities.UserEntity;

namespace ICom.Core.Entities.UserInfoEntity
{
    public class UserInfo : Entity
    {
        public virtual int UserId { get; set; }
        public virtual UserInfoType Type { get; set; }
        public virtual string Info { get; set; }

        public virtual User User { get; set; }
    }
}