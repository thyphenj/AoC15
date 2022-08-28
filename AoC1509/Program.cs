internal class Program
{
    static void Main()
    {
        string[] input = File.ReadAllLines("input.txt");

        // -- INIT INIT INIT

        var names = new List<string>();
        var trips = new Dictionary<string, int>();

        foreach (var line in input)
        {
            string[] tokens = line.Split(' ');

            string name1 = tokens[0].Substring(0, 5);
            string name2 = tokens[2].Substring(0, 5);

            if (!names.Contains(name1)) names.Add(name1);
            if (!names.Contains(name2)) names.Add(name2);

            trips.Add(name1 + " " + name2, int.Parse(tokens[4]));
            trips.Add(name2 + " " + name1, int.Parse(tokens[4]));
        }

        // -- Part 1

        var used = new List<int>();

        int longest = 0;
        int shortest = int.MaxValue;

        for (int i0 = 0; i0 < names.Count; i0++)
        {
            used.Add(i0);
            for (int i1 = 0; i1 < names.Count; i1++)
            {
                if (used.Contains(i1)) continue;
                used.Add(i1);
                int Distance1 = trips.GetValueOrDefault(names[i0] + " " + names[i1]);

                for (int i2 = 0; i2 < names.Count; i2++)
                {
                    if (used.Contains(i2)) continue;
                    used.Add(i2);

                    int Distance2 = Distance1 + trips.GetValueOrDefault(names[i1] + " " + names[i2]);
                    for (int i3 = 0; i3 < names.Count; i3++)
                    {
                        if (used.Contains(i3)) continue;
                        used.Add(i3);

                        int Distance3 = Distance2 + trips.GetValueOrDefault(names[i2] + " " + names[i3]);
                        for (int i4 = 0; i4 < names.Count; i4++)
                        {
                            if (used.Contains(i4)) continue;
                            used.Add(i4);

                            int Distance4 = Distance3 + trips.GetValueOrDefault(names[i3] + " " + names[i4]);
                            for (int i5 = 0; i5 < names.Count; i5++)
                            {
                                if (used.Contains(i5)) continue;
                                used.Add(i5);

                                int Distance5 = Distance4 + trips.GetValueOrDefault(names[i4] + " " + names[i5]);
                                for (int i6 = 0; i6 < names.Count; i6++)
                                {
                                    if (used.Contains(i6)) continue;
                                    used.Add(i6);

                                    int Distance6 = Distance5 + trips.GetValueOrDefault(names[i5] + " " + names[i6]);
                                    for (int i7 = 0; i7 < names.Count; i7++)
                                    {
                                        if (used.Contains(i7)) continue;
                                        used.Add(i7);

                                        int Distance7 = Distance6 + trips.GetValueOrDefault(names[i6] + " " + names[i7]);

                                        if (Distance7 < shortest) shortest = Distance7;
                                        if (Distance7 > longest) longest = Distance7;

                                        used.Remove(i7);
                                    }
                                    used.Remove(i6);
                                }
                                used.Remove(i5);
                            }
                            used.Remove(i4);
                        }
                        used.Remove(i3);
                    }
                    used.Remove(i2);
                }
                used.Remove(i1);
            }
            used.Remove(i0);
        }

        Console.WriteLine($"Part 1 - {shortest}");
        Console.WriteLine($"Part 2 - {longest}");
    }
}