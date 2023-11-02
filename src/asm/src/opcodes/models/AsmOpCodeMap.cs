//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static AsmOpCodes;

[StructLayout(StructLayout,Pack=1)]
public readonly record struct AsmOpCodeMap : IComparable<AsmOpCodeMap>
{
    public readonly AsmOpCodeKind Kind;

    public readonly AsmOpCodeClass Class;

    public readonly AsmOpCodeIndex Index;

    public readonly MapName Name;

    public readonly Hex16 Value;

    [MethodImpl(Inline)]
    public AsmOpCodeMap(AsmOpCodeKind kind, AsmOpCodeClass @class, AsmOpCodeIndex index, asci2 indicator, asci4 selector)
    {
        Kind = kind;
        Class = @class;
        Index = index;
        Value = value(kind);
        Name = name(kind);
    }

    public int CompareTo(AsmOpCodeMap src)
        => cmp(Kind, src.Kind);

    public string Format()
        => Name.Depictor.Format();

    public override string ToString()
        => Format();
    
    public static AsmOpCodeMap Empty => default;
}
