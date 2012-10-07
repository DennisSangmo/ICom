using System.Web.Mvc;
using NHibernate;
using StructureMap;

namespace ICom.Web.Infrastructure.ActionFilters
{
    public class TransactionalAttribute : ActionFilterAttribute {

        public TransactionalAttribute() {
            Order = 1;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (filterContext.IsChildAction)
                return;

            var session = ObjectFactory.GetInstance<ISession>();
            session.BeginTransaction();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext) {
            if (filterContext.IsChildAction)
                return;

            var session = ObjectFactory.GetInstance<ISession>();
            using (session.Transaction) {
                if (session.Transaction.IsActive && filterContext.Exception == null) {
                    session.Transaction.Commit();
                } else if (session.Transaction.IsActive && filterContext.Exception != null) {
                    session.Transaction.Rollback();
                }   
            }
        }
    }
}