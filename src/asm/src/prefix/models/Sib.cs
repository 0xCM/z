//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static SibFields;

/// <summary>
/// ss iii bbb
/// </summary>
[ApiComplete, DataWidth(8)]
public record struct Sib : IAsmByte<Sib>
{
    [MethodImpl(Inline), Op]
    public static ScaleFactor factor(Sib src)
        => (ScaleFactor)Pow2.pow8u(src.Scale);

    [MethodImpl(Inline)]
    public static Sib init(byte src = 0)
        => new (src);

    byte _Value;

    [MethodImpl(Inline)]
    public Sib(byte src)
    {
        _Value = src;
    }

    [MethodImpl(Inline)]
    public Sib(uint3 @base, uint3 index, uint2 scale)
    {
        _Value = BitNumbers.join(@base,index,scale);
    }

    public uint3 Base
    {
        [MethodImpl(Inline)]
        get => (uint3)bits.extract(_Value, Base_Min, Base_Max);

        [MethodImpl(Inline)]
        set => _Value = math.or(bits.scatter((byte)value, Base_Mask), math.and(_Value, math.not(Base_Mask)));
    }

    public uint3 Index
    {
        [MethodImpl(Inline)]
        get => (uint3)bits.extract(_Value, Index_Min, Index_Max);

        [MethodImpl(Inline)]
        set => _Value = math.or(bits.scatter((byte)value, Index_Mask), math.and(_Value, math.not(Index_Mask)));
    }

    public uint2 Scale
    {
        [MethodImpl(Inline)]
        get => (uint2)bits.extract(_Value, Scale_Min, Scale_Max);

        [MethodImpl(Inline)]
        set => _Value = math.or(bits.scatter((byte)value, Scale_Mask), math.and(_Value, math.not(Scale_Mask)));
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => _Value.Equals(0);
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => !IsEmpty;
    }

    public bool IsNonZero
    {
        [MethodImpl(Inline)]
        get => _Value != 0;
    }

    [MethodImpl(Inline)]
    public byte Value()
        => _Value;

    public static Sib Empty
        => default;

    public string Bitstring()
    {
        Span<char> dst = stackalloc char[RenderWidth];

        var i = 0u;
        BitRender.render2(Scale, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render3(Index, ref i, dst);
        seek(dst,i++) = Chars.Space;

        BitRender.render3(Base, ref i, dst);
        return new string(dst);
    }

    public string Format()
        => AsmPrefixByte.format(this);

    public override string ToString()
        => Format();

    public bool Equals(Sib src)
        => _Value == src._Value;
    public override int GetHashCode()
        => _Value;

    [MethodImpl(Inline)]
    public static implicit operator byte(Sib src)
        => src.Value();

    [MethodImpl(Inline)]
    public static explicit operator Sib(byte src)
        => new (src);
}
