using System.ComponentModel;
using ICom.Core.Entities.UserEntity;

namespace ICom.Core.Entities.UserInfoEntity
{
    public class UserInfo : Entity
    {
        public virtual int UserId { get; set; }

        [DisplayName("Typ")]
        public virtual UserInfoType Type { get; set; }
        [DisplayName("Information")]
        public virtual string Info { get; set; }

        public virtual User User { get; set; }
    }
}