//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public struct BitMask
{
    public readonly byte Width;

    public ulong Value;

    [MethodImpl(Inline)]
    public BitMask(byte value)
    {
        Width = 8;
        Value = value;
    }

    [MethodImpl(Inline)]
    public BitMask(ushort value)
    {
        Width = 16;
        Value = value;
    }

    [MethodImpl(Inline)]
    public BitMask(uint value)
    {
        Width = 32;
        Value = value;
    }

    [MethodImpl(Inline)]
    public BitMask(ulong value)
    {
        Width = 64;
        Value = value;
    }

    [MethodImpl(Inline)]
    public BitMask(byte width, ulong value)
    {
        Width = width;
        Value = value;
    }

    [MethodImpl(Inline)]
    public byte Apply(byte src)
        => math.and((byte)Value, src);

    [MethodImpl(Inline)]
    public ushort Apply(ushort src)
        => math.and((ushort)Value, src);

    [MethodImpl(Inline)]
    public uint Apply(uint src)
        => math.and((uint)Value, src);

    [MethodImpl(Inline)]
    public ulong Apply(ulong src)
        => math.and(Value, src);

    [MethodImpl(Inline)]
    public BitMask And(BitMask src)
        => new (math.max(Width,src.Width), Value & src.Value);

    [MethodImpl(Inline)]
    public BitMask Or(BitMask src)
        => new (math.max(Width,src.Width), Value | src.Value);

    [MethodImpl(Inline)]
    public BitMask Xor(BitMask src)
        => new (math.max(Width,src.Width), Value ^ src.Value);

    [MethodImpl(Inline)]
    public BitMask Invert()
        => new (Width, ~Value);

    [MethodImpl(Inline)]
    public BitMask Negate()
        => new (Width, math.negate(Value));

    [MethodImpl(Inline)]
    public BitMask Sll(byte count)
    {
        var value = Value << count;
        var width = math.max(bits.effwidth(value), Width);
        return new BitMask(width,value);
    }

    [MethodImpl(Inline)]
    public BitMask Srl(byte count)
    {
        var value = Value << count;
        var width = math.min(bits.effwidth(value), Width);
        return new BitMask(width,value);
    }

    public string Format()
        => ((BitMaskData)this).Format();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static BitMask operator ~(BitMask src)
        => src.Invert();

    [MethodImpl(Inline)]
    public static BitMask operator -(BitMask src)
        => src.Negate();

    [MethodImpl(Inline)]
    public static BitMask operator &(BitMask a, BitMask b)
        => a.And(b);

    [MethodImpl(Inline)]
    public static BitMask operator |(BitMask a, BitMask b)
        => a.Or(b);

    [MethodImpl(Inline)]
    public static BitMask operator ^(BitMask a, BitMask b)
        => a.Xor(b);

    [MethodImpl(Inline)]
    public static BitMask operator <<(BitMask a, int count)
        => a.Sll((byte)count);

    [MethodImpl(Inline)]
    public static BitMask operator >>(BitMask a, int count)
        => a.Srl((byte)count);

    [MethodImpl(Inline)]
    public static implicit operator BitMask(ulong src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator BitMaskData(BitMask src)
        => new (src.Value, src.Width);

    public static BitMask Empty => default;
}
