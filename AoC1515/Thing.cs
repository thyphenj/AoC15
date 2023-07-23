namespace AoC1515;

public class Thing
{
    public string Name;

    public int A;
    public int B;
    public int C;
    public int D;
    public int E;

    public Thing(string line)
    {
        var tok = line.Split(": ");

        Name = tok[0];

        tok = tok[1].Split(", ");

        A = int.Parse(tok[0].Split(' ')[1]);
        B = int.Parse(tok[1].Split(' ')[1]);
        C = int.Parse(tok[2].Split(' ')[1]);
        D = int.Parse(tok[3].Split(' ')[1]);
        E = int.Parse(tok[4].Split(' ')[1]);
    }
}