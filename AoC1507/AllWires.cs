public class AllWires
{
    public Dictionary<string, Wire> Wires = new Dictionary<string, Wire>();

    public void Add(string line)
    {
        string[] tok = line.Split(' ');

        switch (tok.Length)
        {
            case 3: // -- value or wirename

                Wires.Add(tok[2], new Wire(tok[0]));
                break;

            case 4: // -- gate : NOT

                Wires.Add(tok[3], new Wire(tok[0], tok[1]));
                break;

            case 5: // -- gate : AND, OR, LSHIFT, RSHIFT

                Wires.Add(tok[4], new Wire(tok[0], tok[1], tok[2]));
                break;

            default:
                break;
        }
    }

    public uint Resolve(string key)
    {
        Wire currWire = Wires[key];

        if (currWire.Value is not null)
            currWire.Value = (uint)currWire.Value;

        else if (currWire.Source == SignalSource.Wire)
            currWire.Value = Resolve(currWire.OpOne);

        else if (currWire.Source == SignalSource.Gate)
        {
            var opLeft = currWire.OpOneValue ?? Resolve(currWire.OpOne);

            if (currWire.Gate == "NOT")
                currWire.Value = ~opLeft;

            else if (currWire.Gate == "LSHIFT")
                currWire.Value = opLeft << int.Parse(currWire.OpTwo);

            else if (currWire.Gate == "RSHIFT")
                currWire.Value = opLeft >> int.Parse(currWire.OpTwo);

            else
            {
                var opRite = currWire.OpTwoValue ?? Resolve(currWire.OpTwo);

                if (currWire.Gate == "AND")
                    currWire.Value = opLeft & opRite;

                if (currWire.Gate == "OR")
                    currWire.Value = opLeft | opRite;
            }
        }
        return currWire.Value ?? throw new Exception("Bugger");
    }
}