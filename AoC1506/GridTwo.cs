namespace AoC1506
{
    public class GridTwo
    {
        public int[,] Leds;

        public GridTwo()
        {
            Leds = new int[1000, 1000];
        }
        public void Action(string action, (int, int) from, (int, int) to)
        {
            for (int x = from.Item1; x <= to.Item1; x++)
                for (int y = from.Item2; y <= to.Item2; y++)
                    if (action == "toggle")
                        Leds[x, y] += 2;
                    else if (action == "on")
                        Leds[x, y]++;
                    else if (action == "off")
                        if (Leds[x, y] > 0)
                            Leds[x, y]--;
        }

        public override string ToString()
        {
            long count = 0;
            for (int x = 0; x < 1000; x++)
                for (int y = 0; y < 1000; y++)
                    count += Leds[x, y];

            return count.ToString();
        }
    }
}

