using System;
using System.Security.Cryptography;
using System.Text;

namespace BabyRecords_Server.core.tools
{
    public class Cryptography
    {
        //建立密碼鹽
        public string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }
        //
        public string CreateHash(string password, string salt)
        {
            byte[] saltAndPwd = Encoding.UTF8.GetBytes(password + salt); 
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hashedPassword = sHA256ManagedString.ComputeHash(saltAndPwd);

            return Convert.ToBase64String(hashedPassword);
        }


    }
}
