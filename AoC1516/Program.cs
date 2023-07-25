class Program
{
    static void Main()
    {
        Dictionary<string, int> detected = new Dictionary<string, int>();

        detected.Add("children", 3);
        detected.Add("cats", 7);
        detected.Add("samoyeds", 2);
        detected.Add("pomeranians", 3);
        detected.Add("akitas", 0);
        detected.Add("vizslas", 0);
        detected.Add("goldfish", 5);
        detected.Add("trees", 3);
        detected.Add("cars", 2);
        detected.Add("perfumes", 1);

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

        Dictionary<string, int> found = new Dictionary<string, int>();

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
                Console.WriteLine($"{i + 1,3} - {sue}");
        }
    }
}