//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

public readonly record struct VL : IComparable<VL>
{
    readonly byte _Value;

    public VL(AsmVL code)
    {
        _Value = (byte)code;
    }

    public uint Width
    {
        [MethodImpl(Inline)]
        get => (uint)Pow2.log(_Value) << 7;
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
}
