using System;
using System.Security.Cryptography;
using System.Text;

namespace AspNetCore_Stack.Utils
{
    public class StringUtils
    {
        public static string RandomString()
        {
            return Guid.NewGuid().ToString(); ;
        }
        
        public static string Sha256(string _string)
        {
            var crypt = new SHA256Managed();
            var hash = String.Empty;
            var crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(_string), 0, Encoding.ASCII.GetByteCount(_string));
            foreach (var theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}