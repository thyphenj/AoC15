class Program
{
    static void Main()
    {
        int arrSize = 3400000;
        int[] houses = new int[arrSize];
        int min = arrSize*10; 

        for (int i = 1; i < arrSize-1; ++i)
            for (int j = i; j < arrSize && j < min; j += i)
                if ((houses[j] += i * 10) >= arrSize*10)
                    min = Math.Min(min, j);

        Console.WriteLine(min);

        houses = new int[arrSize];
        min = arrSize * 10;

        for (int i = 1; i < arrSize - 1; ++i)
            for(int j = i,c=0; j < arrSize && j < min&& c < 50; j += i, c++)           
                if ((houses[j] += i * 11) >= arrSize * 10)
                    min = Math.Min(min, j);

        Console.WriteLine(min);
    }
}
