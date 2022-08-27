namespace AoC1507
{
    internal class Program
    {
        static Dictionary<string, Wire> wires = new Dictionary<string, Wire>();

        static void Main(string[] args)
        {
            string filename = "input.txt";
            //string filename = "input-test.txt";
            string[] input = File.ReadAllLines(filename);

            foreach (var line in input)
            {
                string[] tok = line.Split(' ');

                switch (tok.Length)
                {
                    case 3:
                        uint value = 0;
                        if (uint.TryParse(tok[0], out value))
                            wires.Add(tok[2], new Wire(value));
                        else
                            wires.Add(tok[2], new Wire(tok[0]));
                        break;

                    case 4:
                        wires.Add(tok[3], new Wire(tok[0], tok[1]));
                        break;

                    case 5:
                        wires.Add(tok[4], new Wire(tok[0], tok[1], tok[2]));
                        break;

                    default:
                        break;
                }
            }
            //foreach ( var wire in wires)
            //    Console.WriteLine($"{wire.Key,2}    {wire.Value}");

            uint answer = Resolve("a",wires["a"]);

            Console.WriteLine(answer);
        }

        internal static uint Resolve(string key,Wire root)
        {
            Console.WriteLine($"{key,2}   {root}");
            uint retval = 0;

            if (root.Value is not null)
                retval =  (uint)root.Value;

            else if (root.Source == SignalSource.Wire)
                retval = Resolve(root.OpOne,wires[root.OpOne]);

            else if (root.Source == SignalSource.Gate)
            {
                var opLeft =  root.OpOneValue ??  Resolve(root.OpOne, wires[root.OpOne]);

                if (root.Gate == "NOT")
                    retval = ~opLeft;

                else if (root.Gate == "LSHIFT")
                    retval =  opLeft << int.Parse(root.OpTwo);

                else if (root.Gate == "RSHIFT")
                    retval =  opLeft >> int.Parse(root.OpTwo);

                else
                {
                    var opRite = root.OpTwoValue ?? Resolve(root.OpTwo,wires[root.OpTwo]);

                    if (root.Gate == "AND")
                        retval = opLeft & opRite;

                    if (root.Gate == "OR")
                        retval =  opLeft | opRite;
                }
            }

            root.Value = retval;

            return retval;
        }
    }
}