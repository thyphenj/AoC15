internal class State
{
    public int Start;
    public int End;

    public char Ch;
    public bool InArr;
    public bool InObj;
    public int LocalSum;
    public bool Red;

    public State(string str, int ptr)
    {
        Start = ptr;
        Ch = str[ptr];
        InArr = (Ch == '[');
        InObj = (Ch == '{');
        LocalSum = 0;
        Red = false;
    }

    public State(string str, int ptr, State stat)
    {
        Start = ptr;
        Ch = str[ptr];
        InArr = (Ch == '[');
        InObj = (Ch == '{');
        LocalSum = 0;
        Red = stat.Red;
    }

    public override string ToString()
    {
        return $"({Start,4},{End,4})   char={Ch}   " + (InObj ? "Object" : "      ") + (Red ? "   red" : "      ") + $"   sum:{LocalSum}";
    }
}