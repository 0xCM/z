//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    // using H = Hash128;
    // using V = UInt128;
    // using api = HashCodes;

    // public readonly record struct Hash128 : IHashCode<H,V>
    // {
    //     public readonly V Value;

    //     [MethodImpl(Inline)]
    //     public Hash128(V value)
    //     {
    //         Value = value;
    //     }

    //     [MethodImpl(Inline)]
    //     public Hash128(Hash32 lo, Hash32 hi)
    //     {
    //         Value = lo | hi;
    //     }

    //     ulong IHashCode<ulong>.Value
    //         => Value;

    //     [MethodImpl(Inline)]
    //     public bool Equals(H src)
    //         => Value == src.Value;

    //     [MethodImpl(Inline)]
    //     public int CompareTo(H src)
    //         => Value.CompareTo(src.Value);

    //     public override int GetHashCode()
    //         => Value.GetHashCode();

    //     public string Format()
    //         => api.format<H,V>(this);

    //     public override string ToString()
    //         => Format();

    //     [MethodImpl(Inline)]
    //     public static implicit operator Hash128(ulong src)
    //         => new Hash128(src);
    // }
}