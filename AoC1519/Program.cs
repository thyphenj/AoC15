using System.Text.RegularExpressions;

class Program
{
    static bool testing = false;
    static string Filename = testing
        ? "input-test.txt"
        : "input.txt";

    static void Main()
    {
        string[] lines = File.ReadAllLines(Filename);
        int nooflines = lines.Count();
        List<string[]> recipes = new List<string[]>();
        for (int i = 0; i < nooflines - 2; i++)
        {
            string[] token = MapToBracketed(lines[i]).Split(' ');
            recipes.Add(new string[] { token[0], token[2] });
        }

        string Molecule = MapToBracketed(lines[nooflines - 1]);
        Console.WriteLine(Molecule);
        Console.WriteLine();

        HashSet<string> newStuff = new HashSet<string>();
        foreach (var r in recipes)
        {
            for (int i = 0; i < Molecule.Length; i++)
            {
                if (r[0][0] == Molecule[i])
                {
                    string left = Molecule.Substring(0, i);
                    string here = r[1];
                    string rite = Molecule.Substring(i + 1);
                    newStuff.Add($"{left}{here}{rite}");
                }
            }
        }
        Console.WriteLine($"Part 1 - {newStuff.Count()}");
        Console.WriteLine();

        // -----------------------------------
        Regex twoLetters = new Regex("[A-Za-z][A-Za-z]");
        Regex fnArg = new Regex(@"[A-Za-z]\([A-Za-z]\)");
        Regex fnArgArg = new Regex(@"[A-Za-z]\([A-Za-z],[A-Za-z]\)");

        MatchCollection matches;

        int replacements = 0;
        do
        {
            matches = twoLetters.Matches(Molecule);
            if (matches.Count > 0)
            {
                replacements += matches.Count;
                Molecule = twoLetters.Replace(Molecule, "Z");
                Console.WriteLine($"a] {matches.Count,3}  -  {Molecule}");
            }
            else
            {
                matches = fnArg.Matches(Molecule);
                if (matches.Count > 0)
                {
                    replacements += matches.Count;
                    Molecule = fnArg.Replace(Molecule, "Z");
                    Console.WriteLine($"b] {matches.Count,3}  -  {Molecule}");
                }
                else
                {
                    matches = fnArgArg.Matches(Molecule);
                    if (matches.Count > 0)
                    {
                        replacements += matches.Count;
                        Molecule = fnArgArg.Replace(Molecule, "Z");
                        Console.WriteLine($"c] {matches.Count,3}  -  {Molecule}");
                    }
                }
            }
        } while (matches.Count > 0);
        Console.WriteLine($"Part 2 - {replacements}");
    }

    static int Recurse(string str)
    {
        int retval = 0;

        int i = 0;
        while (i < str.Length)
        {
            i++;
        }
        return retval;
    }

    static string MapToBracketed(string str)
    {
        return str.Replace("Rn", "(").Replace("Ar", ")").Replace("Y", ",").Replace("Ca", "C").Replace("Mg", "M").Replace("Si", "S").Replace("Al", "A").Replace("Th", "t").Replace("Ti", "T");
    }
}
