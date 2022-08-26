namespace Aoc1503
{
    internal class Position
    {
        private int X;
        private int Y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}