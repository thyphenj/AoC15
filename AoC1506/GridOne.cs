namespace AoC1506
{
    public class GridOne
    {
        public bool[,] Leds;

        public GridOne()
        {
            Leds = new bool[1000, 1000];
        }
        public void Action(string action, (int, int) from, (int, int) to)
        {
            for (int x = from.Item1; x <= to.Item1; x++)
                for (int y = from.Item2; y <= to.Item2; y++)
                    if (action == "toggle")
                        Leds[x, y] = !Leds[x, y];
                    else if (action == "on")
                        Leds[x, y] = true;
                    else if (action == "off")
                        Leds[x, y] = false;
        }

        public override string ToString()
        {
            int count = 0;
            for (int x = 0; x < 1000; x++)
                for (int y = 0; y < 1000; y++)
                    if (Leds[x, y])
                        count++;

            return count.ToString();
        }
    }
}

