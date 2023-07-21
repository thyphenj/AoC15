internal class Program
{
    static void Main(string[] args)
    {
        string filename = "input.txt";
        //string filename = "input-test.txt";

        Dictionary<string, int> people = new Dictionary<string, int>();

        string[] lines = File.ReadAllLines(filename);

        foreach ( var line in lines)
        {
            var l = line.Replace("would gain ", "+");
            l = l.Replace("would lose ", "-");
            l = l.Replace("happiness units by sitting next to ", "");
            var tok = l.Split(' ');

            people.Add($"{tok[0][0]}{tok[2][0]}", int.Parse(tok[1]));
        }

        foreach ( var p in people)
        {
            Console.WriteLine($"{p.Key}  {p.Value,4}");
        }
    }
}