    internal class Program
    {
        static void Main()
        {
            string[] input = File.ReadAllLines("input.txt");

            var wires1 = new AllWires();
            var wires2 = new AllWires();

            foreach (var line in input)
            {
                wires1.Add(line);
                wires2.Add(line);
            }

            // -- Part 1

            uint part1 = wires1.Resolve("a");

            // -- Part 2

            wires2.Wires["b"].Value = part1;

            uint part2 = wires2.Resolve("a");


            Console.WriteLine($"Part 1 - {part1}");
            Console.WriteLine($"Part 2 - {part2}");
        }
    }