using System;
using System.Collections.Generic;
using System.Text;
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

        public User Create(string name, UserType type) {
            var username = NameToUsername(name);
            var password = GeneratePassword(8);
            var user = new User(name, username, password) {
                                                        Type = type
                                                    };
            _session.Save(user);

            // TODO send the password to the user!

            return user;
        }

        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);
        private static string GeneratePassword(int size) {
            var builder = new StringBuilder();

            for (var i = 0; i < size; i++)
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Random.NextDouble() + 65))));

            return builder.ToString();
        }

        private static string NameToUsername(string name) {
            return name.ToLower().Replace(" ", ".");
        }
    }
}