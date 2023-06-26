public class Parser
{
    int CharacterPosition = 0;

    public string Text;

    public Parser(string input)
    {
        Text = input;

        CharacterPosition = 0;

        switch (input[CharacterPosition++])
        {
            case '[':
                var A = ParseArray(); ;
                break;

            case '{':
                break;

            case '"':
                break;

            default:
                break;
        }
    }
    public long ParseArray()
    {
        return 0;
    }
}
