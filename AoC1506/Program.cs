namespace AoC1506
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");


            // --------------------
            // -- Part 1

            var grid_part1 = new GridOne();

            foreach (var line in input)
            {
                var tokens = line.Split(' ');
                if (tokens[0] == "toggle")
                {
                    grid_part1.Action(tokens[0], decode(tokens[1]), decode(tokens[3]));
                }
                else
                {
                    grid_part1.Action(tokens[1], decode(tokens[2]), decode(tokens[4]));
                }
            }
            Console.WriteLine($"Part 1 - {grid_part1}");

            // --------------------
            // -- Part 2

            var grid_part2 = new GridTwo();

            foreach (var line in input)
            {
                var tokens = line.Split(' ');
                if (tokens[0] == "toggle")
                {
                    grid_part2.Action(tokens[0], decode(tokens[1]), decode(tokens[3]));
                }
                else
                {
                    grid_part2.Action(tokens[1], decode(tokens[2]), decode(tokens[4]));
                }
            }
            Console.WriteLine($"Part 2 - {grid_part2}");
        }

        static (int, int) decode(string str)
        {
            string[] tok = str.Split(',');

            return ((int.Parse(tok[0]), int.Parse(tok[1])));
        }
    }
}