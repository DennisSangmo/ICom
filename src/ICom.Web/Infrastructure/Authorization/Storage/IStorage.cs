namespace ICom.Web.Infrastructure.Authorization.Storage
{
    public interface IStorage<T>
    {
        void Store(string key, T obj);
        T Get(string key);
        void Remove(string key);
    }

    public static class SessionKeys
    {
        public static string User = "UserKey";
    }
}