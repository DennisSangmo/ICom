using System;
using System.Collections.Generic;
using System.Text;
using ICom.Core.AuthSecurity;
using ICom.Core.Entities.UserEntity;
using ICom.Core.Entities.UserInfoEntity;
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
                           .SingleOrDefault();
        }

        public User Get(int id) {
            return _session.Get<User>(id);
        }

        public User Get(string username) {
            return _session.QueryOver<User>()
                           .Where(x => x.Username == username)
                           .SingleOrDefault();
        }

        public IEnumerable<User> GetAll() {
            return _session.QueryOver<User>().List();
        }

        public User Create(User user) {
            var password = GeneratePassword(8);
            user.Password = Encrypter.Encrypt(password);

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

        public static string NameToUsername(string name) {
            return name.ToLower().Replace(" ", ".");
        }

        public bool IsUsernameFree(string username) {
            return _session.QueryOver<User>().Where(x => x.Username == username).RowCount() == 0;
        }

        public bool IsEmailFree(string email) {
            return _session.QueryOver<User>().Where(x => x.Email == email).RowCount() == 0;
        }

        public UserInfo GetInfo(int id)
        {
            return _session.Get<UserInfo>(id);
        }
    }
}