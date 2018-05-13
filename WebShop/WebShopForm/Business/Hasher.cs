using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebShopForm.Business
{
    /// <summary>
    /// This class is used to hash a string
    /// </summary>
    public class Hasher
    {
        /// <summary>
        /// Hashes a certain string.
        /// </summary>
        /// <param name="stringToHash">The string to hash</param>
        /// <returns>The hash of the string</returns>
        public static String HashOf(String stringToHash)
        {
            string hash = "";

            SHA256 sha254 = SHA256.Create();
            Encoding encoding = Encoding.UTF8;
            Byte[] result = sha254.ComputeHash(encoding.GetBytes(stringToHash));

            foreach (Byte b in result)
                hash += b.ToString("x2");

            return hash;
        }
    }
}