internal class Program
{
    static void Main()
    {
        //string input = "cqjxjnds";
        string input = "cqjxxyzz";

        string part1 = input;

        Console.WriteLine(input);
        input = IncrementAndValidate(input);
        Console.WriteLine(input);
    }

    private static string IncrementAndValidate(string input)
    {
        string retval = Increment(input);
        while (!Validate(retval))
            retval = Increment(retval);

        return retval;
    }

    private static bool Validate(string retval)
    {
        bool run = false;
        bool pairs = false;

        for (int i = 0; i < 6 && !run; i++)
            if (retval[i] + 1 == retval[i + 1] && retval[i] + 2 == retval[i + 2])
                run = true;
        
        for (int i = 0; i < 7 && !pairs; i++)
            if (retval[i] == retval[i + 1])
                for (int j = i + 2; j < 7 && !pairs; j++)
                    if (retval[j] == retval[j + 1] && retval[i] != retval[j])
                        pairs = true;

        return pairs && run;
    }

    private static string Increment(string input)
    {
        char[] chars = input.ToCharArray();

        int ind = 7;
        chars[ind]++;
        if ("iol".Contains(chars[ind]))
            chars[ind]++;
        while (chars[ind] > 'z')
        {
            chars[ind] = 'a';
            ind--;
            chars[ind]++;
        }
        return new string(chars);
    }
}