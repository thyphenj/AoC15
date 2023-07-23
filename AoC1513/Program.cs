internal class Program
{
    public static int MaxHappy;
    public static Dictionary<string, (int, int)> Happiness = new Dictionary<string, (int, int)>();

    static void Main(string[] args)
    {
        string filename = "input.txt";
        //string filename = "input-test.txt";

        HashSet<char> peeps = new HashSet<char>();

        string[] lines = File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            var l = line.Replace("would gain ", "+");
            l = l.Replace("would lose ", "-");
            l = l.Replace("happiness units by sitting next to ", "");
            l = l.Replace(".", "");
            var tok = l.Split(' ');

            char a = tok[0][0];
            char b = tok[2][0];
            if (a < b)
            {
                string key = $"{a}{b}";
                Happiness.Add(key, (int.Parse(tok[1]), 0));
            }
            else
            {
                string key = $"{b}{a}";
                Happiness[key] = (Happiness[key].Item1, int.Parse(tok[1]));
            }
            peeps.Add(a);
            peeps.Add(b);
        }

        var people = peeps.ToList();
        MaxHappy = 0;
        Recurse("", people);

        Console.WriteLine($"Part 1 - {MaxHappy}");
        Console.WriteLine();

        foreach ( var p in peeps)
        {
            Happiness.Add($"{p}Z", (0, 0));
        }
        peeps.Add('Z');

        people = peeps.ToList();
        MaxHappy = 0;
        Recurse("", people);

        Console.WriteLine($"Part 2 - {MaxHappy}");
        Console.WriteLine();

    }

    public static void Recurse(string perm, List<char> atoms)
    {
        if (atoms.Count == 0)
        {
            int sum = 0;
            for (int i = 0; i < perm.Length; i++)
            {
                int j = i + 1;
                if (j == perm.Length)
                {
                    j = 0;
                }
                string key = (perm[i] < perm[j]) ? $"{perm[i]}{perm[j]}" : $"{perm[j]}{perm[i]}";
                sum += Happiness[key].Item1 + Happiness[key].Item2;
            }

            if (sum > MaxHappy)
                MaxHappy = sum;

            //Console.WriteLine($"{perm} - {sum}");
        }
        else
        {
            foreach (var atom in atoms)
            {
                List<char> newBag = atoms.Where(e => e != atom).ToList();
                Recurse(perm + atom, newBag);
            }
        }
    }
}