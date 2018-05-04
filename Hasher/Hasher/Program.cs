using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hasher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the password: ");
            Console.WriteLine("The password hash is " + HashOf(Console.ReadLine()));
            Console.ReadKey();
        }

        public static String HashOf(String value)
        {
            string hash = "";

            SHA256 sha254 = SHA256.Create();
            Encoding encoding = Encoding.UTF8;
            Byte[] result = sha254.ComputeHash(encoding.GetBytes(value));

            foreach (Byte b in result)
                hash +=b.ToString("x2");

            return hash;
        }
    }
}
