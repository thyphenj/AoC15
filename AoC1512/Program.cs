internal class Program
{
    static void Main(string[] args)
    {
        string filename = "input-test.txt";
        string input = File.ReadAllText(filename);

        //var p = new Parser(input);
        //Console.WriteLine();

        // -- Part 1

        //Console.WriteLine($"Part 1 - {p.GetSumAll()}");

        // -- Part 2

        //Console.WriteLine($"Part 2 - {p.GetSumNonRed()}");

        new PartTwo(input);
    }
}