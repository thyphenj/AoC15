using System;
using System.IO;

namespace Aoc1503
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            HashSet<string> positions = new HashSet<string>();

            int x = 0;
            int y = 0;

            positions.Add($"{x},{y}");

            foreach ( var ch in input)
            {
                switch (ch)
                {
                    case '>':
                        x++;
                        break;
                    case '<':
                        x--;
                        break;
                    case '^' :
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                    default:
                        break;
                }
                positions.Add($"{x},{y}");
            }
            Console.WriteLine(positions.Count);
        }
    }
}