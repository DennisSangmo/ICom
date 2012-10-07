using System.Web;
using System.Web.Security;
using ICom.Core.Entities;
using ICom.Core.Entities.UserEntity;

namespace ICom.Web.Infrastructure.Authorization.Storage
{
    public class SessionStorage<T> : IStorage<T>
    {
        public void Store(string key, T obj)
        {
            HttpContext.Current.Session.Add(key, obj);

            if(typeof(T) == typeof(User))
            {
                var user = obj as User;
                FormsAuthentication.SetAuthCookie(user.Username, true);
            }
        }

        public T Get(string key)
        {
            return (T)HttpContext.Current.Session[key];
        }

        public void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);

            if(typeof(T) == typeof(User))
            {
                FormsAuthentication.SignOut();
            }
        }
    }
}