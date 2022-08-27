namespace AoC1507
{
    internal class Program
    {
        static Dictionary<string, Wire> wires = new Dictionary<string, Wire>();
        static int Depth = 0;

        static void Main(string[] args)
        {
            string filename = "input.txt";
            //string filename = "input-test.txt";
            string[] input = File.ReadAllLines(filename);

            var wires1 = new AllWires();
            var wires2 = new AllWires();

            foreach (var line in input)
            {
                wires1.Add(line);
                wires2.Add(line);
            }

            // -- Part 1

            uint answer1 = wires1.Resolve("a");

            // -- Part 2

            wires2.Wires["b"].Value = answer1;

            uint answer2 = wires2.Resolve("a");


            Console.WriteLine($"Part 1 - {answer1}");
            Console.WriteLine($"Part 2 - {answer2}");
        }

    }
}