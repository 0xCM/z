//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    /// <summary>
    /// FieldKind[0,2] ValueKind[3,10] Operator[11,12] Value[16,31]
    /// </summary>
    [BitPattern(PatternText)]
    public readonly struct InstFieldBits : IBitPattern<InstFieldBits>
    {
        //public const string PatternName = nameof(InstFieldBits);

        public const string PatternText = "fff kkkkkkk oo vvvvvvvvvvvvvvvv";

        public static InstFieldBits Bits => default;

        public static BpCalcs<InstFieldBits> Calcs => Bits;

        // public string Name
        //     => PatternName;

        public BpExpr Pattern
            => PatternText;

        // public const byte KindWidth = num3.Width;

        // public const byte OperatorWidth = InstOperator.Width;

        // public const byte ValueKindWidth = num7.Width;

        // public const byte ValueWidth = num16.Width;

        //public const byte Width = KindWidth + ValueKindWidth + OperatorWidth + ValueWidth;

        //public const byte KindOffset = 0;

        //public const byte OperatorOffset = KindOffset + KindWidth;

        //public const byte ValueKindOffset = OperatorOffset + OperatorWidth;

        //public const byte ValueOffset = ValueKindOffset + ValueKindWidth;

        // public const uint KindMask = num3.MaxValue << KindOffset;

        // public const uint OperatorMask = num2.MaxValue << OperatorOffset;

        // public const uint ValueKindMask = num7.MaxValue << ValueKindOffset;

        // public const uint ValueMask = num16.MaxValue << ValueOffset;
    }
}
