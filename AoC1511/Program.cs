internal class Program
{
    static void Main()
    {
        //string input = "cqjxjnds";
        string   input = "aaaazzzz";

        string part1 = input;

        input = increment(input);
    }

    private static string increment(string input)
    {
        string retval = "";

        char[] chars = input.ToCharArray();

        int ind = 7;
        while (chars[ind]>= 'z')
        {
            chars[ind] = 'a';
            ind--;
            chars[ind]++;
        }

        return retval;
    }
}