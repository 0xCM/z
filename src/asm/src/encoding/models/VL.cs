//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public readonly record struct VL : IComparable<VL>
{
    public static VL VL128 => new(z8);

    public static VL V256 => new(1);

    public static VL VL512 => new(2);

    public static VL LLIG => new(3);

    public static VL None => new(byte.MaxValue);

    readonly byte _Value;

    [MethodImpl(Inline)]
    VL(byte code)
    {
        _Value = code;
    }

    [MethodImpl(Inline)]
    public VL(AsmVL code)
    {
        _Value = (byte)code;
    }

    public uint Width
    {
        [MethodImpl(Inline)]
        get => (_Value == byte.MaxValue  || _Value == 2) ? 0 :  (uint)Pow2.log(_Value) << 7;
    }

    public readonly AsmVL Value
    {
        [MethodImpl(Inline)]
        get => (AsmVL)_Value;
    }

    public string Format()
    {
        Span<char> dst = stackalloc char[2];
        var i = 0u;
        BitRender.render2(_Value, ref i, dst);
        return new(dst);
    }

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public int CompareTo(VL src)
        => _Value.CompareTo(src._Value);

    [MethodImpl(Inline)]
    public static implicit operator VL(AsmVL src)
        => new(src);

    [MethodImpl(Inline)]
    public static explicit operator uint2(VL src)
        => src._Value;

    [MethodImpl(Inline)]
    public static bool operator < (VL a, VL b)
        => a.Value < b.Value;

    [MethodImpl(Inline)]
    public static bool operator <= (VL a, VL b)
        => a.Value <= b.Value;

    [MethodImpl(Inline)]
    public static bool operator > (VL a, VL b)
        => a.Value > b.Value;

    [MethodImpl(Inline)]
    public static bool operator >= (VL a, VL b)
        => a.Value >= b.Value;

}
