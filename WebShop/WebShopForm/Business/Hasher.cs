using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebShopForm.Business
{
    public class Hasher
    {
        public static String HashOf(String value)
        {
            string hash = "";

            SHA256 sha254 = SHA256.Create();
            Encoding encoding = Encoding.UTF8;
            Byte[] result = sha254.ComputeHash(encoding.GetBytes(value));

            foreach (Byte b in result)
                hash += b.ToString("x2");

            return hash;
        }
    }
}