namespace AoC1507
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            //string filename = "input-test.txt";
            string[] input = File.ReadAllLines(filename);

            var wires = new Dictionary<string, Wire>();
            foreach (var line in input)
            {
                string[] tok = line.Split(' ');

                switch (tok.Length)
                {
                    case 3:
                        ushort value = 0;
                        if (ushort.TryParse(tok[0], out value))
                            wires.Add(tok[2], new Wire(value));
                        else
                            wires.Add(tok[2], new Wire(tok[0]));
                        break;

                    case 4:
                        wires.Add(tok[3], new Wire(tok[0], tok[1]));
                        break;

                    case 5:
                        wires.Add(tok[4],new Wire(tok[0], tok[1], tok[2]));
                        break;

                    default:
                        break;
                }
            }
            foreach ( var wire in wires)
                Console.WriteLine($"{wire.Key,2}    {wire.Value}");
        }
    }
}