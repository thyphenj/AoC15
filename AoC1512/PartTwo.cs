using System.Text.RegularExpressions;

public class PartTwo
{
    static Stack<State> st = new Stack<State>();

    public PartTwo(string input)
    {
        int ptr = 0;
        var stat = new State(input, ptr);
        ptr++;

        Console.WriteLine(input);

        while (ptr < input.Length)
        {
            switch (input[ptr])
            {
                case '[':
                case '{':
                    st.Push(stat);
                    stat = new State(input, ptr, stat);
                    ptr++;
                    break;

                case ']':
                case '}':
                    stat.End = ptr;
                    Console.WriteLine(stat);
                    if ( ptr+2 != input.Length)
                        stat = st.Pop();
                    ptr++;
                    break;

                default:
                    if (isNumeric(input[ptr]))
                    {
                        string str = input[ptr++].ToString();
                        while (isNumeric(input[ptr]))
                        {
                            str = $"{str}{input[ptr++]}";
                        }
                        stat.LocalSum += int.Parse(str);
                    }
                    else if (input[ptr] == 'r')
                    {
                        if (stat.InObj && "red" == input.Substring(ptr, 3))
                        {
                            stat.Red = true;
                            ptr += 3;
                        }
                        else
                            ptr++;
                    }
                    else
                        ptr++;
                    break;

            }
        }
        Console.WriteLine();
    }
    private bool isNumeric(char ch)
    {
        return "-0123456789".Contains(ch);
    }
}
