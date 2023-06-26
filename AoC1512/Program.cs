internal class Program
{
    static void Main(string[] args)
    {
        string filename = "input.txt";
        string input = File.ReadAllText(filename);

        // -- Part 1

        Console.WriteLine($"Part 1 - {Part1(input)}");

        // -- Part 2

        Console.WriteLine($"Part 2 - {Part2(input)}");
    }

    // ----------------------------------------------------------------------

    private static long Part2(string input)
    {
        string numberStr = "";

        long sumTotal = 0;
        bool inArr = false;

        var prvInArr = new Stack<bool>();
        var prvSum = new Stack<long>();

        int charPos = 0;
        while (charPos < input.Length)
        {
            var ch = input[charPos++];

            if ("-0123456789".Contains(ch))
            {
                numberStr += ch;
            }
            else if (numberStr.Length != 0)
            {
                int val = 0;
                if (int.TryParse(numberStr, out val))
                    sumTotal += val;
                numberStr = "";
            }
            else if (ch == '{')
            {
                prvSum.Push(sumTotal);
                sumTotal = 0;

                prvInArr.Push(inArr);
                inArr = false;
            }
            else if (ch == '[')
            {
                prvSum.Push(sumTotal);
                sumTotal = 0;

                prvInArr.Push(inArr);
                inArr = true;
            }

            else if (ch == '}')
            {
                sumTotal += prvSum.Pop();
                inArr = prvInArr.Pop();
            }

            else if (ch == ']')
            {
                sumTotal += prvSum.Pop();
                inArr = prvInArr.Pop();
            }

            else if (input.Substring(charPos-1).Length > 5 && input.Substring(charPos-1, 5) == "\"red\"")
            {
                if (!inArr)
                {
                    charPos += 4;

                    int depth = 1;
                    do
                    {
                        ch = input[charPos++];

                        if ("[{".Contains(ch))
                            depth++;

                        if ("]}".Contains(ch))
                            depth--;
                    }
                    while (!"}]".Contains(ch) || depth != 0);

                    sumTotal = prvSum.Pop();
                    inArr = prvInArr.Pop();
                }
            }
            
        }
        return sumTotal;
    }
    // ----------------------------------------------------------------------

    private static long Part1(string input)
    {
        string numberStr = "";
        long sumTotal = 0;

        foreach (var ch in input)
        {
            if ("-0123456789".Contains(ch))
            {
                numberStr += ch;
            }
            else if (numberStr.Length != 0)
            {
                int val = 0;
                if (int.TryParse(numberStr, out val))
                    sumTotal += val;
                numberStr = "";
            }
        }
        return sumTotal;
    }

}