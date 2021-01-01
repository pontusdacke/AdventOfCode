using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Day_4
{
    class Program
    {
        static void Main(string[] args)
        {

            int counter = 0;
            var MD5 = (HashAlgorithm)CryptoConfig.CreateFromName("MD5");
            var UTF8Encoder = new UTF8Encoding();

            while (true)
            {
                string key = "iwrupvqb" + counter;
                byte[] encodedKey = UTF8Encoder.GetBytes(key);
                byte[] hash = MD5.ComputeHash(encodedKey);

                string encoded = BitConverter.ToString(hash)
                    .Replace("-", String.Empty);
                    //.ToLower();

                if (encoded.StartsWith("000000"))
                {
                    Console.WriteLine(counter);
                    break;
                }
                counter++;
            }

        }
    }
}
