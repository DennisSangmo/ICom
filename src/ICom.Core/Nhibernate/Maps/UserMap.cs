using FluentNHibernate.Mapping;
using ICom.Core.Domain;

namespace ICom.Core.Nhibernate.Maps {
    public class UserMap : ClassMap<User> {
        public UserMap() {
            Table("users");
            Id(x => x.Id);

            Map(x => x.Username);
            Map(x => x.Password);
        }
    }
}