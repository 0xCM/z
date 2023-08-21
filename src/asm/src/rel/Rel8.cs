//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using W = W8;
using T = Rel8;

public readonly record struct Rel8 : IRelOp<byte>, IDataType<Rel8>
{
    public readonly byte Value;

    [MethodImpl(Inline)]
    public Rel8(byte src)
        => Value = src;

    public NativeSize Size
        => NativeSizeCode.W8;

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Value == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Value != 0;
    }

    public string Format()
        => HexFormatter.format(w, Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

    public override string ToString()
        => Format();

    byte IValued<byte>.Value
        => Value;

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Value;
    }


    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public int CompareTo(T src)
        => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

    [MethodImpl(Inline)]
    public bool Equals(T src)
        => Value == src.Value;

    [MethodImpl(Inline)]
    public Address8 ToAddress()
        => Value;

    [MethodImpl(Inline)]
    public static bool operator <(T a, T b)
        => a.Value < b.Value;

    [MethodImpl(Inline)]
    public static bool operator >(T a, T b)
        => a.Value > b.Value;

    [MethodImpl(Inline)]
    public static bool operator <=(T a, T b)
        => a.Value <= b.Value;

    [MethodImpl(Inline)]
    public static bool operator >=(T a, T b)
        => a.Value >= b.Value;

    [MethodImpl(Inline)]
    public static implicit operator byte(T src)
        => src.Value;

    [MethodImpl(Inline)]
    public static implicit operator T(byte src)
        => new T(src);

    public static W w => default;
}
