//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using W = W32;
using T = Rel16;

public readonly record struct Rel16 : IRelOp<ushort>, IDataType<Rel16>
{
    public readonly ushort Value;

    [MethodImpl(Inline)]
    public Rel16(ushort src)
        => Value = src;

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Value;
    }

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

    public NativeSize Size
        => NativeSizeCode.W16;

    public string Format()
        => HexFormatter.format(w, Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

    public override string ToString()
        => Format();

    ushort IValued<ushort>.Value
        => Value;

    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public int CompareTo(T src)
        => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

    [MethodImpl(Inline)]
    public bool Equals(T src)
        => Value == src.Value;

    [MethodImpl(Inline)]
    public Address16 ToAddress()
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
    public static implicit operator ushort(T src)
        => src.Value;

    [MethodImpl(Inline)]
    public static implicit operator T(ushort src)
        => new Rel16(src);

    public static W w=> default;
}
