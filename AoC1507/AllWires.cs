using System;
namespace AoC1507
{
    public class AllWires
    {
        public Dictionary<string, Wire> Wires = new Dictionary<string, Wire>();

        public AllWires()
        {
        }

        public void Add(string line)
        {
            string[] tok = line.Split(' ');

            switch (tok.Length)
            {
                case 3:
                    uint value = 0;
                    if (uint.TryParse(tok[0], out value))
                        Wires.Add(tok[2], new Wire(value));
                    else
                        Wires.Add(tok[2], new Wire(tok[0]));
                    break;

                case 4:
                    Wires.Add(tok[3], new Wire(tok[0], tok[1]));
                    break;

                case 5:
                    Wires.Add(tok[4], new Wire(tok[0], tok[1], tok[2]));
                    break;

                default:
                    break;
            }
        }

        public void Add(string key, Wire wire)
        {
            Wires.Add(key, wire);
        }

        public uint Resolve(string key)
        {
            Wire currWire = Wires[key];

            uint retval = 0;

            if (currWire.Value is not null)
                retval = (uint)currWire.Value;

            else if (currWire.Source == SignalSource.Wire)
                retval = Resolve(currWire.OpOne);

            else if (currWire.Source == SignalSource.Gate)
            {
                var opLeft = currWire.OpOneValue ?? Resolve(currWire.OpOne);

                if (currWire.Gate == "NOT")
                    retval = ~opLeft;

                else if (currWire.Gate == "LSHIFT")
                    retval = opLeft << int.Parse(currWire.OpTwo);

                else if (currWire.Gate == "RSHIFT")
                    retval = opLeft >> int.Parse(currWire.OpTwo);

                else
                {
                    var opRite = currWire.OpTwoValue ?? Resolve(currWire.OpTwo);

                    if (currWire.Gate == "AND")
                        retval = opLeft & opRite;

                    if (currWire.Gate == "OR")
                        retval = opLeft | opRite;
                }
            }

            currWire.Value = retval;

            return retval;
        }
    }
}

