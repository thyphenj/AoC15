internal class Program
{
    static void Main()
    {
        string[] input = File.ReadAllLines("input.txt");

        // -- Part 1

        int sumPart1 = 0;
        int sumPart2 = 0;

        foreach (string line in input)
        {
            var x = new Line(line);

            sumPart1 += x.OriginalLength - x.ShortLength;
            sumPart2 += x.LongLength - x.OriginalLength;
        }

        Console.WriteLine($"Part 1 - {sumPart1}");
        Console.WriteLine($"Part 2 - {sumPart2}");
    }
}