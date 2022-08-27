using System;
namespace AoC1507
{
    public class Wire
    {
        public SignalSource Source;

        public ushort? Value;
        public string? SourceWireName;
        public string? SourceGate;
        public string? LeftOperator;
        public string? RiteOperator;

        public Wire(ushort value)
        {
            Source = SignalSource.Value;

            Value = value;
        }

        public Wire(string wireName)
        {
            Source = SignalSource.Wire;

            SourceWireName = wireName;
        }

        public Wire ( string operand, string wireName)
        {
            Source = SignalSource.Gate;

            LeftOperator = wireName;
            SourceGate = operand;
        }

        public Wire(string wireName1, string operand, string wireName2)
        {
            Source = SignalSource.Gate;

            LeftOperator = wireName1;
            SourceGate = operand;
            RiteOperator = wireName2;
        }

        public override string ToString()
        {
            return $"{Source,5} [{Value}] [{LeftOperator}] [{SourceGate}] [{RiteOperator}]";
        }
    }
}

