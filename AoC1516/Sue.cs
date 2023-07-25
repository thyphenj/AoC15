public class Sue
{
    public Dictionary<string,int> Elements;

    public Sue(string line)
    {
        Elements = new Dictionary<string,int>();

        string[] toks = line.Split(", ");
        foreach ( var tok in toks)
        {
            var thing = tok.Split(": ");
            Elements.Add(thing[0], int.Parse(thing[1]));
        }
    }

    public override string ToString()
    {
        string retval = "";
        foreach ( var e in Elements)
        {
            retval += $", {e.Key.PadRight(11)}: {e.Value,4}" ;
        }
        return retval.Substring(2);
    }
}

