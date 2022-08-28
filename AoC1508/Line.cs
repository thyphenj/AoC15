using System;

public class Line
{
    public string OriginalText;
    public string ShortText;
    public string LongText;

    public int OriginalLength;
    public int ShortLength;
    public int LongLength;

    public Line(string text)
    {
        OriginalText = text;
        OriginalLength = OriginalText.Length;

        // ------------------------------------------------------------------
        // -- part 1

        ShortText = OriginalText;

        if (ShortText[0] == '"')
            ShortText = ShortText.Substring(1);
        if (ShortText[ShortText.Length - 1] == '"')
            ShortText = ShortText.Substring(0, ShortText.Length - 1);

        ShortText = ShortText.Replace("\\\"", "+");
        ShortText = ShortText.Replace("\\\\", "-");

        var found = ShortText.IndexOf("\\x");
        while ( found >= 0)
        {
            ShortText = ShortText.Substring(0, found) + "_" + ShortText.Substring(found + 4);
            found = ShortText.IndexOf("\\x");
        }
        ShortLength = ShortText.Length;

        // ------------------------------------------------------------------
        // -- part 2

        LongText = OriginalText;
        LongLength = LongText.Length;

        LongText = LongText.Replace('"', '+');
        LongText = LongText.Replace('\\', '-');

        LongText = LongText.Replace("-", "\\\\");
        LongText = LongText.Replace("+", "\\\"");

        LongText = "\"" + LongText + "\"";

        LongLength = LongText.Length;
    }

    public override string ToString()
    {
        return $"{OriginalText}  =>  {ShortText}  =>  {LongText}";
    }
}
