using System;
using System.Security.Cryptography;
using System.Text;

namespace ICom.Core.AuthSecurity {
    public static class Encrypter {
        private static readonly byte[] Salt = new byte[]{1,0,1,1,1,0,0,0,1};

        public static string Encrypt(string password) {
            var data = Encoding.UTF8.GetBytes(password);
            var encrypted = new byte[data.Length + Salt.Length];

            for (var i = 0; i < data.Length; i++) {
                encrypted[i] = data[i];
            }

            for (var i = 0; i < Salt.Length; i++) {
                encrypted[data.Length + i] = Salt[i];
            }

            var hash = new SHA256Managed();
            return Convert.ToBase64String(hash.ComputeHash(encrypted));
        }
    }
}