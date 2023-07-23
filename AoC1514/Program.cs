using System;
namespace AoC1514
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            //string filename = "input-test.txt";

            var reindeers = new List<Reindeer>();

            var lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                //Console.WriteLine(line);
                var tokens = line.Split(' ');
                reindeers.Add(new Reindeer(tokens[0], tokens[3], tokens[6], tokens[13]));
            }

            // ---- Part 1 : Who's gone the furthest
            int maxDistance = 0;
            foreach (var r in reindeers)
            {
                int d = r.Distance(2503);
                //Console.WriteLine( $"{r.Name.PadRight(8)} - {d,6}");
                if (d > maxDistance)
                    maxDistance = d;
            }
            Console.WriteLine($"Part 1 - {maxDistance}");

            // ---- Part 2 : Who's been most often in the lead
            for (int t = 1; t <= 2503; t++)
            {
                maxDistance = 0;
                var leader = reindeers[0];

                foreach (var r in reindeers)
                {
                    int d = r.Distance(t);
                    if (d > maxDistance)
                    {
                        maxDistance = d;
                        leader = r;
                    }
                }
                leader.Points++;
            }
            int maxPoints = 0;
            foreach (var r in reindeers)
            {
                if (r.Points > maxPoints)
                    maxPoints = r.Points;
                //Console.WriteLine( $"{r.Name.PadRight(8)} - {r.Points,6}");
            }
            Console.WriteLine($"Part 2 - {maxPoints}");
        }
    }
}