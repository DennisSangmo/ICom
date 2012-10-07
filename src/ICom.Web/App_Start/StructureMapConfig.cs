using System.Web.Mvc;
using ICom.Core.Domain;
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
            ObjectFactory.Initialize(x => {
                                         x.SetAllProperties(y => {
                                                                y.OfType<IStorage<User>>();
                                                            });
                                        x.Scan(s => s.Assembly("ICom.Core"));
                                     });
            ObjectFactory.Configure(x =>{
                                        x.For<IControllerActivator>()
                                            .Use<StructureMapControllerActivator>();
                                        x.For<ISession>().Use(session);
                                        x.For(typeof(IStorage<>)).Use(typeof(SessionStorage<>));
                                        x.FillAllPropertiesOfType<IStorage<User>>();
                                    });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(ObjectFactory.Container));
        }
    }
}