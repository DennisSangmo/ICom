using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace ICom.Web.App_Start
{
    public class FluentNhibernateConfig
    {
        private const string AssemblyName = "ICom.Core";

        private static Configuration _config;
        private static ISessionFactory _sessionFactory;

        public static void CreateConfig()
        {
            _config =  Fluently.Configure()
                           .Database(MySQLConfiguration.Standard.ConnectionString(x => x.FromConnectionStringWithKey("localhost")))
                           .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.Load(AssemblyName))).BuildConfiguration();
            
            _sessionFactory = _config.BuildSessionFactory();
        }

        public static ISession GetSession()
        {
            if (_sessionFactory == null)
                CreateConfig();

            return _sessionFactory.OpenSession();
        }
    }
}