using System.ComponentModel;

namespace ICom.Core.Entities.UserInfoEntity
{
    public enum UserInfoType
    {
        [Description("Hemnummer")]
        HomePhone = 1,
        [Description("Mobilnummer")]
        MobilePhone,
        [Description("Arbetsnummer")]
        WorkPhone,
        [Description("Alternativ email")]
        Email,
        [Description("Adress")]
        Adress,
        [Description("Postnummer")]
        PostalCode,
        [Description("Stad")]
        City
    }
}