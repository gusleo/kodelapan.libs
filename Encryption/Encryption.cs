using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kodelapan.Libs.Encryption
{
    public class Encryption
    {
        public static string CreateSalt()
        {
            var data = new byte[0x10];
           
            var cryptoServiceProvider = System.Security.Cryptography.RandomNumberGenerator.Create();
            cryptoServiceProvider.GetBytes(data);
            return Convert.ToBase64String(data);
            
        }
        public static byte[] CreateByteSalt()
        {
            var data = new byte[0x10];
            
            var cryptoServiceProvider = System.Security.Cryptography.RandomNumberGenerator.Create();
            cryptoServiceProvider.GetBytes(data);
            return data;
            
        }
        public static string EncryptPassword(string password, string salt)
        {
            using ( var sha256 = SHA256.Create() )
            {
                var saltedPassword = string.Format("{0}{1}", salt, password);
                byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }
        public static byte[] EncryptPasswordByte(string password, byte[] salt)
        {
            using ( var sha256 = SHA256.Create() )
            {
                var saltedPassword = string.Format("{0}{1}", Convert.ToBase64String(salt), password);
                byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return sha256.ComputeHash(saltedPasswordAsBytes);
            }
        }
    }
}
