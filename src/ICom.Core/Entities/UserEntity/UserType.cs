using System.ComponentModel;

namespace ICom.Core.Entities.UserEntity
{
    public enum UserType {
        [Description("Normal")]
        Normal = 10,
        [Description("Administratör")]
        Administrator = 20,
        [Description("Utvecklare")]
        Developer = 30
    }
}