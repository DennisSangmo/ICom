using System.Collections.Generic;
using ICom.Core.AuthSecurity;
using ICom.Core.Entities.UserEntity;
using NHibernate;

namespace ICom.Core.Services {
    public class UserService {
        private readonly ISession _session;

        public UserService(ISession session) {
            _session = session;
        }

        public User Login(string username, string password) {
            var hash = Encrypter.Encrypt(password);
            return _session.QueryOver<User>()
                           .Where(x => x.Username == username)
                           .Where(x => x.Password == hash)
                           .Take(1)
                           .SingleOrDefault();
        }

        public User Get(int id) {
            return _session.Get<User>(id);
        }

        public User Get(string username) {
            return _session.QueryOver<User>()
                           .Where(x => x.Username == username)
                           .Take(1)
                           .SingleOrDefault();
        }

        public IEnumerable<User> GetAll() {
            return _session.QueryOver<User>().List();
        }
    }
}