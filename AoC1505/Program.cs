using System;
using System.IO;
using System.Security.Cryptography;

namespace Aoc1505
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            // --------------------
            // -- Part 1 

            int niceCount = 0;
            foreach (var str in input)
            {
                if (str.Contains("ab")) continue;
                if (str.Contains("cd")) continue;
                if (str.Contains("pq")) continue;
                if (str.Contains("xy")) continue;

                int vowelCount = 0;
                bool repeatedChar = false;
                for (int i = 0; i < str.Length; i++)
                {
                    if ("aeiou".Contains(str[i]))
                        vowelCount++;
                    if (i + 1 < str.Length && str[i] == str[i + 1])
                        repeatedChar = true;
                }
                if (vowelCount > 2 && repeatedChar)
                    niceCount++;
            }
            Console.WriteLine($"Part 1 - {niceCount}");

            // --------------------
            // -- Part 2

            niceCount = 0;
            foreach (var str in input)
            {
                bool pairFound = false;
                bool spltFound = false;

                for (int i = 0; i < str.Length; i++)
                {
                    if (i + 3 < str.Length)
                        for (int j = i + 2; j < str.Length-1; j++)
                            pairFound |= (str[i] == str[j] && str[i + 1] == str[j + 1]);

                    if (i + 2 < str.Length)
                        spltFound |= (str[i] == str[i + 2]);
                }
                if (spltFound && pairFound)
                    niceCount++;
            }
            Console.WriteLine($"Part 2 - {niceCount}");
        }
    }
}