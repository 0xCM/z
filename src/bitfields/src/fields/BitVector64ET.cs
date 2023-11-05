//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public record struct BitVector64<E>
    where E : unmanaged, Enum
{
    ulong Data;

    [MethodImpl(Inline)]
    public BitVector64(ulong data)
    {
        Data = data;
    }

    public bit this[byte index]
    {
        [MethodImpl(Inline)]
        get => bit.test(Data,index);
        set => Data = bit.set(Data,index,value);
    }

    public bit this[E index]
    {
        [MethodImpl(Inline)]
        get => bit.test(Data,bw8(index));
        set => Data = bit.set(Data,bw8(index),value);
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => sys.hash((uint)Data, (uint)(Data >> 32));
    }

    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public bool Equals(BitVector64<E> src)
        => Data == src.Data;

    public string Format()
        => Bitfields.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator BitVector64<E>(ulong src)
        => new (src);
}
