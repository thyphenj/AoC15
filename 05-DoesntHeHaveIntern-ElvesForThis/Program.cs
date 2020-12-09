using System;
using System.IO;

namespace _05_DoesntHeHaveIntern_ElvesForThis
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            int count = 0;

            foreach (var s in input)
            {
                if (Nice(s))
                    count++;
            }
            Console.WriteLine(count);

        }
        static bool Nice(string s)
        {
            int vowels = 0;
            bool dble = false;
            bool abcd = false;

            for (int i = 0; i < s.Length; i++)
            {
                if ("aeiou".Contains(s[i]))
                    vowels++;

                if (i < s.Length - 1)
                {
                    if (s[i] == s[i + 1])
                        dble = true;
                    string ss = s.Substring(i, 2);
                    if (ss == "ab" || ss == "cd" || ss == "pq" || ss == "xy")
                        abcd = true;
                }
            }
            return vowels > 2 && dble && !abcd;
        }
    }
}
