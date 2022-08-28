public class Wire
{
    public SignalSource Source;

    public uint? Value;
    public string Gate = "";
    public string OpOne = "";
    public string OpTwo = "";
    public uint? OpOneValue;
    public uint? OpTwoValue;

    public Wire(uint val)
    {
        Source = SignalSource.Value;

        Value = val & 0xFFFF;
    }

    public Wire(string wireNameOrValue)
    {
        uint val;
        if (uint.TryParse(wireNameOrValue, out val))
        {
            Source = SignalSource.Value;
            Value = val & 0xFFFF;
        }
        else
        {
            Source = SignalSource.Wire;
            OpOne = wireNameOrValue;
        }
    }

    public Wire(string gate, string operand1)
    {
        Source = SignalSource.Gate;

        Gate = gate;

        OpOne = operand1;

        uint val = 0;
        if (uint.TryParse(OpOne, out val)) OpOneValue = val; ;
    }

    public Wire(string operand1, string gate, string operand2)
    {
        Source = SignalSource.Gate;

        Gate = gate;

        OpOne = operand1;
        OpTwo = operand2;

        uint val = 0;
        if (uint.TryParse(OpOne, out val)) OpOneValue = val; ;
        if (uint.TryParse(OpTwo, out val)) OpTwoValue = val; ;
    }
}
