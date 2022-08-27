namespace AoC1502
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            //string[] lines = { "2x3x4", "1x1x10" };

            long area = 0;
            long length = 0;
            foreach ( var line in lines)
            {
                string[] lengths = line.Split('x');
                int[] values = new int[3]; ;
                values[0] = int.Parse(lengths[0]);
                values[1] = int.Parse(lengths[1]);
                values[2] = int.Parse(lengths[2]);

                Array.Sort(values);
                int a = values[0];
                int b = values[1];
                int c = values[2];

                // -- part 1

                int smallSideArea = a * b;
                int largeArea = 2 * (a * b + b * c + a * c);
                area += largeArea + smallSideArea;

                // -- part 2

                int smallLength = 2*(a + b);
                int bowlength = a * b * c;
                length += smallLength + bowlength;
            }
            Console.WriteLine($"Part 1 - {area}");
            Console.WriteLine($"Part 2 - {length}");
        }
    }
}