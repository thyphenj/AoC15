namespace AoC1503
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");

            int x = 0;
            int y = 0;

            var positions = new HashSet<string> { $"{x},{y}" };

            foreach (var ch in input)
            {
                switch (ch)
                {
                    case '>':
                        x++;
                        break;
                    case '<':
                        x--;
                        break;
                    case '^':
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
            Console.WriteLine($"Part 1 : {positions.Count}");

            // ------------------------------
            // -- Part 2

            int Sx = 0;
            int Sy = 0;
            int Rx = 0;
            int Ry = 0;

            positions = new HashSet<string> { $"{Sx},{Sy}" };

            bool santa = true;
            foreach (var ch in input)
            {
                switch (ch)
                {
                    case '>':
                        if (santa) Sx++; else Rx++;
                        break;
                    case '<':
                        if (santa) Sx--; else Rx--;
                        break;
                    case '^':
                        if (santa) Sy++; else Ry++;
                        break;
                    case 'v':
                        if (santa) Sy--; else Ry--;
                        break;
                    default:
                        break;
                }
                if ( santa)
                    positions.Add($"{Sx},{Sy}");
                else
                    positions.Add($"{Rx},{Ry}");
                santa = !santa;
            }
            Console.WriteLine($"part 2 : { positions.Count}");

        }
    }
}