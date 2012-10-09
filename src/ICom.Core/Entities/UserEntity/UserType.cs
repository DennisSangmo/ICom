using System.ComponentModel;

namespace ICom.Core.Entities.UserEntity
{
    public enum UserType {
        [Description("Normal")]
        Normal = 10,
        [Description("Administrat�r")]
        Administrator = 20,
        [Description("Utvecklare")]
        Developer = 30
    }
}