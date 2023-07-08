using Newtonsoft.Json.Linq;

public class Parser
{
    private static long SumAll;
    private static long SumNonRed;
    private static int Level;

    public Parser(string str)
    {
        SumAll = 0;
        SumNonRed = 0;
        Level = 0;

        foreach (var json in JArray.Parse(str).Children())
        {
            var yy = new Parser(json);
        }
    }

    public Parser(JToken json)
    {
        Display(json);

        long localsum = Accumulate(json);

        Level++;
        foreach (var child in json.Children())
        {
            var yy = new Parser(child);
        }
        Level--;

        SumAll += localsum;
    }

    public long GetSumAll()
    {
        return SumAll;
    }

    public long GetSumNonRed()
    {
        return SumNonRed;
    }

    private int Accumulate(JToken toke)
    {
        int retval = 0;

        if (toke.Type == JTokenType.Integer)
            retval = toke.ToObject<int>();

        return retval;
    }

    private void Display(JToken toke)
    {
        for (int i = 0; i < Level; i++)
            Console.Write("  ");

        Console.Write(toke.Type);

        switch (toke.Type)
        {
            case JTokenType.Integer:
                Console.Write(" - " + toke.ToObject<int>());
                break;

            case JTokenType.String:
                Console.Write(" - " + toke.ToObject<string>());
                break;

            case JTokenType.Property:
                break;

            default:
                break;
        }

        Console.WriteLine();
    }
}
