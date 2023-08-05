class Program
{
    static bool testing = true;
    static string Filename = "input.txt";
    static int Target = 150;

    static int[] capacity = { };
    static int[] contInd = { };

    static void Main()
    {      
        if (testing)
        {
            Filename = "input-test.txt";
            Target = 25;
        }
        string[] lines = File.ReadAllLines(Filename);
        int noofContainers = lines.Length;

        capacity = new int[noofContainers];
        contInd = new int[noofContainers];

        for (int i = 0; i < noofContainers; i++)
        {
            capacity[i] = int.Parse(lines[i]);
        }
        capacity = capacity.Order().ToArray<int>();

        int noofCombinations = 0;
        int two = 0;
        int four = 0;
        int sum = 0;
        int knd = 0;
        for (contInd[knd] = 0; contInd[knd] < noofContainers; contInd[knd]++)
        {
            if (sum + capacity[contInd[knd]] > Target) continue;
            else if (sum + capacity[contInd[knd]] == Target)
            {
                if ((++noofCombinations) % 10 == 1)
                    Console.WriteLine();
                Console.Write($"{noofCombinations,3}  -  {sum + capacity[contInd[knd]],3}    ");
                for (int i = 0; i <= knd; i++)
                    Console.Write($" {capacity[contInd[i]],3}");
                Console.WriteLine();
                break;
            }



            sum += capacity[contInd[knd++]];
            for (contInd[knd] = contInd[knd - 1] + 1; contInd[knd] < noofContainers; contInd[knd]++)
            {
                if (sum + capacity[contInd[knd]] > Target) continue;
                else if (sum + capacity[contInd[knd]] == Target)
                {
                    if ((++noofCombinations) % 10 == 1)
                        Console.WriteLine();
                    Console.Write($"{noofCombinations,3}  -  {sum + capacity[contInd[knd]],3}    ");
                    for (int i = 0; i <= knd; i++)
                        Console.Write($" {capacity[contInd[i]],3}");
                    Console.WriteLine($"  ------------------- {++two}");

                    break;
                }

                sum += capacity[contInd[knd++]];
                for (contInd[knd] = contInd[knd - 1] + 1; contInd[knd] < noofContainers; contInd[knd]++)
                {
                    if (sum + capacity[contInd[knd]] > Target) continue;
                    else if (sum + capacity[contInd[knd]] == Target)
                    {
                        if ((++noofCombinations) % 10 == 1)
                            Console.WriteLine();
                        Console.Write($"{noofCombinations,3}  -  {sum + capacity[contInd[knd]],3}    ");
                        for (int i = 0; i <= knd; i++)
                            Console.Write($" {capacity[contInd[i]],3}");
                        Console.WriteLine();
                        break;
                    }

                    sum += capacity[contInd[knd++]];
                    for (contInd[knd] = contInd[knd - 1] + 1; contInd[knd] < noofContainers; contInd[knd]++)
                    {
                        if (sum + capacity[contInd[knd]] > Target) continue;
                        else if (sum + capacity[contInd[knd]] == Target)
                        {
                            if ( (++noofCombinations) % 10 == 1)
                                Console.WriteLine();
                            Console.Write($"{noofCombinations,3}  -  {sum + capacity[contInd[knd]],3}    ");
                            for (int i = 0; i <= knd; i++)
                                Console.Write($" {capacity[contInd[i]],3}");
                            Console.WriteLine($"  ------------------- {++four}");
                            break;
                        }

                        sum += capacity[contInd[knd++]];
                        for (contInd[knd] = contInd[knd - 1] + 1; contInd[knd] < noofContainers; contInd[knd]++)
                        {
                            if (sum + capacity[contInd[knd]] > Target) continue;
                            else if (sum + capacity[contInd[knd]] == Target)
                            {
                                if ((++noofCombinations) % 10 == 1)
                                    Console.WriteLine();
                                Console.Write($"{noofCombinations,3}  -  {sum + capacity[contInd[knd]],3}    ");
                                for (int i = 0; i <= knd; i++)
                                    Console.Write($" {capacity[contInd[i]],3}");
                                Console.WriteLine();
                                break;
                            }

                            sum += capacity[contInd[knd++]];
                            for (contInd[knd] = contInd[knd - 1] + 1; contInd[knd] < noofContainers; contInd[knd]++)
                            {
                                if (sum + capacity[contInd[knd]] > Target) continue;
                                else if (sum + capacity[contInd[knd]] == Target)
                                {
                                    if ((++noofCombinations) % 10 == 1)
                                        Console.WriteLine();
                                    Console.Write($"{noofCombinations,3}  -  {sum + capacity[contInd[knd]],3}    ");
                                    for (int i = 0; i <= knd; i++)
                                        Console.Write($" {capacity[contInd[i]],3}");
                                    Console.WriteLine();
                                    break;
                                }

                                sum += capacity[contInd[knd++]];
                                for (contInd[knd] = contInd[knd - 1] + 1; contInd[knd] < noofContainers; contInd[knd]++)
                                {
                                    if (sum + capacity[contInd[knd]] > Target) continue;
                                    else if (sum + capacity[contInd[knd]] == Target)
                                    {
                                        if ((++noofCombinations) % 10 == 1)
                                            Console.WriteLine();
                                        Console.Write($"{noofCombinations,3}  -  {sum + capacity[contInd[knd]],3}    ");
                                        for (int i = 0; i <= knd; i++)
                                            Console.Write($" {capacity[contInd[i]],3}");
                                        Console.WriteLine();
                                        break;
                                    }

                                    sum += capacity[contInd[knd++]];
                                    for (contInd[knd] = contInd[knd - 1] + 1; contInd[knd] < noofContainers; contInd[knd]++)
                                    {
                                        if (sum + capacity[contInd[knd]] > Target) continue;
                                        else if (sum + capacity[contInd[knd]] == Target)
                                        {
                                            if ((++noofCombinations) % 10 == 1)
                                                Console.WriteLine();
                                            Console.Write($"{noofCombinations,3}  -  {sum + capacity[contInd[knd]],3}    ");
                                            for (int i = 0; i <= knd; i++)
                                                Console.Write($" {capacity[contInd[i]],3}");
                                            Console.WriteLine();
                                            break;
                                        }

                                        sum += capacity[contInd[knd++]];
                                        for (contInd[knd] = contInd[knd - 1] + 1; contInd[knd] < noofContainers; contInd[knd]++)
                                        {
                                            if (sum + capacity[contInd[knd]] > Target) continue;
                                            else if (sum + capacity[contInd[knd]] == Target)
                                            {
                                                if ((++noofCombinations) % 10 == 1)
                                                    Console.WriteLine();
                                                Console.Write($"{noofCombinations,3}  -  {sum + capacity[contInd[knd]],3}    ");
                                                for (int i = 0; i <= knd; i++)
                                                    Console.Write($" {capacity[contInd[i]],3}");
                                                Console.WriteLine();
                                                break;
                                            }

                                            sum += capacity[contInd[knd++]];
                                            for (contInd[knd] = contInd[knd - 1] + 1; contInd[knd] < noofContainers; contInd[knd]++)
                                            {
                                                if (sum + capacity[contInd[knd]] > Target) continue;
                                                else if (sum + capacity[contInd[knd]] == Target)
                                                {
                                                    if ((++noofCombinations) - 1 % 10 == 1)
                                                        Console.WriteLine();
                                                    Console.Write($"{noofCombinations,3}  -  {sum + capacity[contInd[knd]],3}    ");
                                                    for (int i = 0; i <= knd; i++)
                                                        Console.Write($" {capacity[contInd[i]],3}");
                                                    Console.WriteLine();
                                                    break;
                                                }

                                                {
                                                    /* insert shit here */
                                                }
                                            }
                                            sum -= capacity[contInd[--knd]];
                                        }
                                        sum -= capacity[contInd[--knd]];
                                    }
                                    sum -= capacity[contInd[--knd]];
                                }
                                sum -= capacity[contInd[--knd]];
                            }
                            sum -= capacity[contInd[--knd]];
                        }
                        sum -= capacity[contInd[--knd]];
                    }
                    sum -= capacity[contInd[--knd]];
                }
                sum -= capacity[contInd[--knd]];
            }
            sum -= capacity[contInd[--knd]];
        }
        //for (int i = 0; i < cnt; i++)
        //{
        //    Recurse(capacity[..1], capacity[1..]);
        //    capacity = capacity[1..];
        //}
    }

    internal static void Recurse(int[] perm, int[] atoms)
    {
        int theSum = perm.Sum();
        Console.WriteLine($"{theSum,4} - [{show(perm)}]   --   [{show(atoms)}]");
        if (theSum == Target)
        {
            foreach (var a in perm)
            {
                //Console.Write($"{a,3}  ");
            }
            //Console.WriteLine($"-- {theSum}");
        }
        else if (theSum < Target)
        {
            Array.Resize<int>(ref perm, perm.Length + 1);
            foreach (var atom in atoms)
            {
                perm[perm.Length - 1] = atom;
                Recurse(perm, atoms[1..]);
            }
            Array.Resize<int>(ref perm, perm.Length - 1);
        }
    }
    private static string show(List<int> lst)
    {
        string retval = "";

        foreach (var l in lst)
            retval += $"  {l,3}";
        return retval;
    }
    private static string show(int[] lst)
    {
        string retval = "";

        foreach (var l in lst)
            retval += $"  {l,3}";
        return retval;
    }
}