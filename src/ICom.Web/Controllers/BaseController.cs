using System.Web.Mvc;
using ICom.Core.Domain;
using ICom.Core.Services;
using ICom.Web.Infrastructure.ActionFilters;
using ICom.Web.Infrastructure.Authorization.Storage;

namespace ICom.Web.Controllers
{
    [Authorize]
    [RetrieveUser]
    [Transactional]
    public class BaseController : Controller
    {
        private readonly IStorage<User> _storage;
        public UserService UserService { get; set; }

        public User User { get { return _storage.Get(SessionKeys.User); } }

        public BaseController(IStorage<User> storage)
        {
            _storage = storage;
        }

        public BaseController(){}
    }
}
