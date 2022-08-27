using System;
using System.IO;
using System.Security.Cryptography;

namespace Aoc1504
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = "ckczppom";
            //string key = "abcdef";
            string theHash = "";
            long i = 1;

            while (true)
            {
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes($"{key}{i}");
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    theHash = Convert.ToHexString(hashBytes);
                    if (theHash.Substring(0,6) == "000000") break;

                    i++;
                }
            }

            Console.WriteLine($"{i}  {theHash}");
        }
    }
}