using FluentNHibernate.Mapping;
using ICom.Core.Entities.UserEntity;

namespace ICom.Core.Nhibernate.Maps {
    public class UserMap : ClassMap<User> {
        public UserMap() {
            Table("users");
            Id(x => x.Id);

            Map(x => x.Username);
            Map(x => x.Password);
            Map(x => x.Name);
            Map(x => x.Type).CustomType<UserType>().Default("3");
            Map(x => x.Email);
        }
    }
}