namespace AoC1501
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string brackets = File.ReadAllText("input.txt");

            int floor = 0;
            int charpos = 0;
            int basement = 0;
            bool beenToBasement = false;

            foreach ( var ch in brackets)
            {
                charpos++;
                if (ch == '(')
                    floor++;
                if ( ch == ')')
                    floor--;
                if (floor == -1 && !beenToBasement)
                {
                    beenToBasement = true;
                    basement = charpos;
                }
            }
            Console.WriteLine($"part 1 - {floor}");
            Console.WriteLine($"part 2 - {basement}");
        }
    }
}