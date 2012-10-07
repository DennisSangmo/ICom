using System.Web.Mvc;
using ICom.Core.Entities.UserEntity;
using ICom.Web.Infrastructure.Authorization.Storage;
using ICom.Web.Infrastructure.StructureMap;
using NHibernate;
using StructureMap;

namespace ICom.Web.App_Start
{
    public class StructureMapConfig
    {
        public static void Register(ISessionFactory sessionFactory)
        {
            ObjectFactory.Initialize(x => {
                                         x.SetAllProperties(y => {
                                                                y.OfType<IStorage<User>>();
                                                            });
                                        x.Scan(s => s.Assembly("ICom.Core"));
                                     });
            ObjectFactory.Configure(x =>{
                                        x.For<IControllerActivator>()
                                            .Use<StructureMapControllerActivator>();
                                        x.For<ISessionFactory>().Singleton().Use(sessionFactory);
                                        x.For<ISession>().HybridHttpOrThreadLocalScoped().Use(c => c.GetInstance<ISessionFactory>().OpenSession());
                                        x.For(typeof(IStorage<>)).Use(typeof(SessionStorage<>));
                                        x.FillAllPropertiesOfType<IStorage<User>>();
                                    });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }
}