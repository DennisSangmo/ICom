using System.Web.Mvc;
using ICom.Web.Infrastructure.Authorization.Storage;
using ICom.Web.Infrastructure.StructureMap;
using NHibernate;
using StructureMap;

namespace ICom.Web.App_Start
{
    public class StructureMapConfig
    {
        public static void Register(ISession session)
        {
            ObjectFactory.Configure(x =>
                                        {
                                            x.For<IControllerActivator>()
                                                .Use<StructureMapControllerActivator>();
                                            x.For<ISession>().Use(session);
                                            x.For(typeof(IStorage<>)).Use(typeof(SessionStorage<>));
                                        });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }
}