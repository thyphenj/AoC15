class Program
{
    static void Main()
    {
        string filename = "input.txt";

        string[] lines = File.ReadAllLines(filename);

        Sue[] sues = new Sue[lines.Length];

        foreach (var line in lines)
        {
            string localLine = line.Substring(4);
            int i = localLine.IndexOf(':');

            int sueNumber = int.Parse(localLine.Substring(0, i)) - 1;
            sues[sueNumber] = new Sue(localLine.Substring(i + 2));
        }

        Dictionary<string, int> detected = new Dictionary<string, int>();

        detected.Add("children", 3);
        detected.Add("samoyeds", 2);
        detected.Add("akitas", 0);
        detected.Add("vizslas", 0);
        detected.Add("cars", 2);
        detected.Add("perfumes", 1);

        detected.Add("cats", 7);
        detected.Add("trees", 3);

        detected.Add("pomeranians", 3);
        detected.Add("goldfish", 5);

        List<string> more = new List<string> { "cats", "trees" };
        List<string> less = new List<string> { "pomeranians", "goldfish" };


        for (int i = 0; i < sues.Length; i++)
        {
            var sue = sues[i];
            bool gotOne = true;
            foreach (var e in sue.Elements)
            {
                if (e.Value != detected[e.Key])
                {
                    gotOne = false;
                    break; ;
                }
            }
            if (gotOne)
                Console.WriteLine($"Part 1 : {i + 1,3} - {sue}");
        }

        for (int i = 0; i < sues.Length; i++)
        {
            var sue = sues[i];
            bool gotOne = true;
            foreach (var e in sue.Elements)
            {
                if (less.Contains(e.Key))
                {
                    if (e.Value >= detected[e.Key])
                    {
                        gotOne = false;
                        break;
                    }
                }
                else if (more.Contains(e.Key))
                {
                    if (e.Value <= detected[e.Key])
                    {
                        gotOne = false;
                        break; ;
                    }
                }
                else if (e.Value != detected[e.Key])
                {
                    gotOne = false;
                    break; ;
                }
            }
            if (gotOne)
                Console.WriteLine($"Part 2 : {i + 1,3} - {sue}");
        }
    }
}