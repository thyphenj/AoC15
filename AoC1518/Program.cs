class Program
{
    static bool testing = false;
    static string Filename = "input.txt";
    static int Steps = 100;

    static string[]? Lines;
    static bool[,]? Grid;
    static int GridSize = 0;

    static void Main()
    {
        if (testing)
        {
            Filename = "input-test.txt";
            Steps = 4;
        }
        Lines = File.ReadAllLines(Filename);
        GridSize = Lines.Length;

        Grid = new bool[GridSize + 2, GridSize + 2]; // -- default to false

        for (int j = 0; j < GridSize; j++)
        {
            int x = j + 1;
            int i = 0;
            foreach (var ch in Lines[j])
            {
                int y = i + 1;
                Grid[x, y] = (ch == '#');
                i++;
            }
        }
        // -- Part 1
        int count = 0;
        for (int i = 0; i < Steps; i++)
        {
            Grid = Iterate();
            count = CountGrid();
        }
        Console.WriteLine(count);

        Grid = ResetGrid();
        count = 0;
        for (int i = 0; i < Steps; i++)
        {
            Grid = Iterate(2);
            count = CountGrid();
        }
        Console.WriteLine(count);
    }

    static bool[,] ResetGrid()
    {
        var retval = new bool[GridSize + 2, GridSize + 2];

        int j = 0;
        foreach (var line in Lines)
        {
            int x = j + 1;
            int i = 0;
            foreach (var ch in line)
            {
                int y = i + 1;
                retval[x, y] = (ch == '#');
                i++;
            }
            j++;
        }
        return retval;
    }

    static bool[,] Iterate(int part = 1)
    {
        var retval = new bool[GridSize + 2, GridSize + 2];

        for (int x = 1; x <= GridSize; x++)
        {
            for (int y = 1; y <= GridSize; y++)
            {
                int neighbours = 0;
                foreach (var x_offset in new int[] { -1, 0, +1 })
                {
                    foreach (var y_offset in new int[] { -1, 0, +1 })
                    {
                        if (x_offset != 0 || y_offset != 0)
                        {
                            if (Grid![x + x_offset, y + y_offset])
                                neighbours++;
                        }
                    }
                }
                if (Grid[x, y])
                {
                    retval[x, y] = (neighbours == 2 || neighbours == 3);
                }
                else
                {
                    retval[x, y] = (neighbours == 3);
                }
                if (part != 1)
                {
                    if ((x == 1 || x == 100) && (y == 1 || y == 100))
                        retval[x, y] = true;
                }
            }
        }

        return retval;
    }

    static void DrawGrid()
    {
        for (int x = 1; x <= GridSize; x++)
        {
            for (int y = 1; y <= GridSize; y++)
            {
                Console.Write(Grid[x, y] ? '#' : '.');
            }
            Console.WriteLine();
        }
    }
    static int CountGrid()
    {
        int count = 0;
        for (int x = 1; x <= GridSize; x++)
        {
            for (int y = 1; y <= GridSize; y++)
            {
                count += Grid[x, y] ? 1 : 0;
            }
        }
        return count;
    }
}