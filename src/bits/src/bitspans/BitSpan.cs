//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using api = BitSpans;

[DataTypeAttributeD("bitspan")]
public readonly ref struct BitSpan
{
    public static Outcome parse(string src, out BitSpan dst)
        => api.parse(src, out dst);

    readonly Span<bit> Data;

    [MethodImpl(Inline)]
    public BitSpan(Span<bit> src)
        => Data = src;

    public int Length
    {
        [MethodImpl(Inline)]
        get => Data.Length;
    }

    public uint BitCount
    {
        [MethodImpl(Inline)]
        get => (uint)Data.Length;
    }

    public ref bit this[ulong index]
    {
        [MethodImpl(Inline)]
        get => ref seek(Data, index);
    }

    public ref bit this[long index]
    {
        [MethodImpl(Inline)]
        get => ref seek(Data, index);
    }

    public ref bit First
    {
        [MethodImpl(Inline)]
        get => ref first(Data);
    }

    [MethodImpl(Inline)]
    public int Msb()
        => api.msb(this);

    [MethodImpl(Inline)]
    public int Lsb()
        => api.lsb(this);

    public BitSpan Reverse()
        => api.reverse(this);

    [MethodImpl(Inline)]
    public BitSpan Extract(uint offset, uint length)
        => api.extract(this, offset, length);

    [MethodImpl(Inline)]
    public BitSpan Truncate(uint maxbits)
        => api.truncate(this, maxbits);

    [MethodImpl(Inline)]
    public BitSpan Trim()
        => api.trim(this);

    internal Span<bit> Storage
    {
        [MethodImpl(Inline)]
        get => Data;
    }

    public uint PopCount()
        => api.pop(this);

    public string Format()
        => api.format(this);

    public string Format(BitFormat options)
        => api.format(this, options);

    [MethodImpl(Inline)]
    public static bit operator ==(in BitSpan a, in BitSpan b)
        => api.same(a,b);

    [MethodImpl(Inline)]
    public static bit operator !=(in BitSpan x, in BitSpan y)
        => !api.same(x,y);

    [MethodImpl(Inline)]
    public static BitSpan operator &(in BitSpan a, in BitSpan b)
        => api.and(a,b);

    [MethodImpl(Inline)]
    public static BitSpan operator ~(in BitSpan src)
        => api.not(src);

    [MethodImpl(Inline)]
    public static BitSpan operator |(in BitSpan a, in BitSpan b)
        => api.or(a,b);

    [MethodImpl(Inline)]
    public static implicit operator BitSpan(Span<bit> src)
        => new BitSpan(src);

    [MethodImpl(Inline)]
    public static implicit operator BitSpan(bit[] src)
        => new BitSpan(src);

    public static BitSpan Empty => default;

    public override bool Equals(object obj)
        => false;

    public override int GetHashCode()
        => 0;
}
