using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Services
{
    public static class PasswordUtilities
    {
        public static string CreateHash(string dataToHash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytValue = Encoding.UTF8.GetBytes(dataToHash);
                byte[] bytHash = sha256.ComputeHash(bytValue);
                string base64 = Convert.ToBase64String(bytHash);
                return base64;
            }
        }

        public static string CreateSalt()
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
    }
}
