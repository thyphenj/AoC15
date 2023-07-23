namespace AoC1514
{
    public class Reindeer
    {
        public string Name;
        public int Speed;
        public int Flight;
        public int Rest;

        public int Position;

        public int Points;

        public Reindeer(string a, string b, string c, string d)
        {
            Name = a;
            Speed = int.Parse(b);
            Flight = int.Parse(c);
            Rest = int.Parse(d);

            Points = 0;
        }

        public int Distance(int sec)
        {
            int cycles = sec / (Flight + Rest);
            int extra = sec % (Flight + Rest);

            int dist = cycles * Flight * Speed;

            if (extra < Flight)
                dist += extra * Speed;
            else
                dist += Flight * Speed;

            Position = dist;

            return dist;
        }
    }
}

