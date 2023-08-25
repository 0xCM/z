//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static AsmOpCodes;
using static sys;

[StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(64)]
public readonly struct XedOpCode : IEquatable<XedOpCode>, IComparable<XedOpCode>
{
    public readonly MachineMode Mode;

    public readonly XedOpCodeKind Kind;

    public readonly OpCodeValue Value;

    readonly byte Pad;

    [MethodImpl(Inline)]
    public XedOpCode(MachineMode mode, XedOpCodeKind kind, OpCodeValue value)
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

    static string minimal(OpCodeValue src)
    {
        var size = src.TrimmedSize;
        ref readonly var b0 = ref src[0];
        ref readonly var b1 = ref src[1];
        ref readonly var b2 = ref src[2];

        var dst = $"0x{b0} 0x{b1} 0x{b2}";
        switch(size)
        {
            case 0:
            case 1:
                dst = $"0x{b0}";
            break;
            case 2:
            dst = $"0x{b0} 0x{b1}";
            break;
        }
        return dst;
    }

    public string Format()
        => format(this);

    public override string ToString()
        => Format();


    public override int GetHashCode()
        => Hash;

    public bool Equals(XedOpCode src)
        => Kind == src.Kind && Value == src.Value;

    public override bool Equals(object src)
        => src is XedOpCode x && Equals(x);

    public int CompareTo(XedOpCode src)
    {
        var result = cmp(Kind, src.Kind);
        if(result == 0)
            result = Value.CompareTo(src.Value);
        return result;
    }

    [MethodImpl(Inline)]
    public static bool operator==(XedOpCode a, XedOpCode b)
        => a.Equals(b);

    [MethodImpl(Inline)]
    public static bool operator!=(XedOpCode a, XedOpCode b)
        => !a.Equals(b);

    [MethodImpl(Inline)]
    public static explicit operator ulong(XedOpCode src)
        => convert(src, out _);

    [MethodImpl(Inline)]
    public static explicit operator XedOpCode(ulong src)
        => convert(src, out _);

    public static XedOpCode Empty => default;
}
