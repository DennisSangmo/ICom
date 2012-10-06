using System.Web.Mvc;
using ICom.Core.Domain;
using ICom.Web.Infrastructure.Authorization.Storage;
using StructureMap;

namespace ICom.Web.Infrastructure.HtmlHelpers
{
    public static class HtmlHelperExtenssion
    {
        public static User User(this HtmlHelper helper)
        {
            var storage = ObjectFactory.GetInstance<IStorage<User>>();
            return storage.Get(SessionKeys.User);
        }
    }
}