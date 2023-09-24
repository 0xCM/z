//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static AsmOpCodes;
using static sys;

[StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(64)]
public readonly struct AsmOpCode : IEquatable<AsmOpCode>, IComparable<AsmOpCode>
{
    public readonly MachineMode Mode;

    public readonly AsmOpCodeKind Kind;

    public readonly OpCodeValue Value;

    readonly byte Pad;

    [MethodImpl(Inline)]
    public AsmOpCode(MachineMode mode, AsmOpCodeKind kind, OpCodeValue value)
    {
        Mode = mode;
        Kind = kind;
        Value = value;
        Pad = 0;
    }

    public AsmOpCodeClass Class
    {
        [MethodImpl(Inline)]
        get => @class(Kind);
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => ((uint)Mode << 29) | (((uint)Class << 24) | (uint)Value);
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Kind == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Kind != 0;
    }

    public asci2 Symbol
        => symbol(Kind);

    public asci4 Selector
        => selector(Kind);

    public AsmOpCodeMap Map
        => new (Kind, Class, index(Kind), Symbol, Selector);

    public string Format()
        => format(this);

    public override string ToString()
        => Format();

    public override int GetHashCode()
        => Hash;

    public bool Equals(AsmOpCode src)
        => Kind == src.Kind && Value == src.Value;

    public override bool Equals(object src)
        => src is AsmOpCode x && Equals(x);

    public int CompareTo(AsmOpCode src)
    {
        var result = cmp(Kind, src.Kind);
        if(result == 0)
            result = Value.CompareTo(src.Value);
        return result;
    }

    [MethodImpl(Inline)]
    public static bool operator==(AsmOpCode a, AsmOpCode b)
        => a.Equals(b);

    [MethodImpl(Inline)]
    public static bool operator!=(AsmOpCode a, AsmOpCode b)
        => !a.Equals(b);

    [MethodImpl(Inline)]
    public static explicit operator ulong(AsmOpCode src)
        => convert(src, out _);

    [MethodImpl(Inline)]
    public static explicit operator AsmOpCode(ulong src)
        => convert(src, out _);

    public static AsmOpCode Empty => default;
}
