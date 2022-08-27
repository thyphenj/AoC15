using System.Security.Cryptography;

namespace AoC1504
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = "ckczppom";
            //string key = "abcdef";
            string theHash = "";
            long i = 1;

            using (MD5 md5 = MD5.Create())
            {
                bool done_five = false;
                bool done_six = false;
                while (!done_six)
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes($"{key}{i}");
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    theHash = Convert.ToHexString(hashBytes);
                    if (!done_five && theHash.Substring(0, 5) == "00000")
                    {
                        done_five = true;
                        Console.WriteLine($"Part 1 - {i}  {theHash}");
                    }
                    else if (theHash.Substring(0, 6) == "000000")
                    {
                        done_six = true;
                        Console.WriteLine($"Part 2 - {i}  {theHash}");
                    }
                    i++;
                }
            }
        }
    }
}