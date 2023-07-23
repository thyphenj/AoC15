namespace AoC1515;

class Program
{
    static void Main()
    {
        //string filename = "input-test.txt";
        string filename = "input.txt";

        List<Thing> things = new List<Thing>();

        var lines = File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            things.Add(new Thing(line));
        }

        long partOne = 0;
        long partTwo = 0;
        for (int i = 0; i <= 100; i++)
        {
            for (int j = 0; i + j <= 100; j++)
            {
                for (int k = 0; i + j + k <= 100; k++)
                {
                    int l = 100 - i - j - k;

                    long A = Math.Max(i * things[0].A + j * things[1].A + k * things[2].A + l * things[3].A, 0);
                    long B = Math.Max(i * things[0].B + j * things[1].B + k * things[2].B + l * things[3].B, 0);
                    long C = Math.Max(i * things[0].C + j * things[1].C + k * things[2].C + l * things[3].C, 0);
                    long D = Math.Max(i * things[0].D + j * things[1].D + k * things[2].D + l * things[3].D, 0);
                    long E = Math.Max(i * things[0].E + j * things[1].E + k * things[2].E + l * things[3].E, 0);

                    long prod = A * B * C * D;
                    if (prod > partOne)
                    
                        partOne = prod;

                    if (prod > partTwo && E == 500)
                        partTwo = prod;
                }
            }
        }
        Console.WriteLine($"Part 1 - {partOne}");
        Console.WriteLine($"Part 2 - {partTwo}");
    }
}