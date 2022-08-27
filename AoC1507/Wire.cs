using System;
namespace AoC1507
{
    public class Wire
    {
        public SignalSource Source;
        public bool Resolved = false;

        public uint? Value;
        public string Gate = "";
        public string OpOne = "";
        public string OpTwo = "";
        public uint? OpOneValue;
        public uint? OpTwoValue;

        public Wire(uint value)
        {
            Source = SignalSource.Value ;
            Resolved = true;

            Value = value & 0xFFFF;
        }

        public Wire(string wireName)
        {
            Source = SignalSource.Wire;
            Resolved = false;

            OpOne = wireName;
        }

        public Wire(string gate, string wireName)
        {
            Source = SignalSource.Gate;
            Resolved = false;

            Gate = gate;

            OpOne = wireName;
            if (uint.TryParse(OpOne, out var val)) OpOneValue = val; ;
        }

        public Wire(string wireName1, string gate, string wireName2)
        {
            Source = SignalSource.Gate;
            Resolved = false;

            Gate = gate;

            OpOne = wireName1;
            if (uint.TryParse(OpOne, out var val)) OpOneValue = val; ;
            OpTwo = wireName2;
            if (uint.TryParse(OpTwo, out  val)) OpTwoValue = val; ;
        }

        public override string ToString()
        {
            return $"{Source,5} [{Value}] [{OpOne}] [{Gate}] [{OpTwo}]";
        }
    }
}

