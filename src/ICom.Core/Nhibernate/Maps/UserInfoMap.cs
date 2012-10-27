using FluentNHibernate.Mapping;
using ICom.Core.Entities.UserInfoEntity;

namespace ICom.Core.Nhibernate.Maps
{
    public class UserInfoMap : ClassMap<UserInfo>
    {
        public UserInfoMap()
        {
            Table("userinfos");

            Id(x => x.Id);
            Map(x => x.UserId, "user_id");

            Map(x => x.Type).CustomType<UserInfoType>();
            Map(x => x.Info);

            References(x => x.User).Not.Insert().Not.Update();
        }
    }
}