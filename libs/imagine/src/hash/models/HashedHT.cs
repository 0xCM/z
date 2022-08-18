//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Hashed<H,T> : IEquatable<Hashed<H,T>>, IComparable<Hashed<H,T>>
        where H : unmanaged, IEquatable<H>, IHashCode<H>
        where T : IEquatable<T>, IComparable<T>
    {
        public readonly H Hash;

        public readonly T Data;

        [MethodImpl(Inline)]
        public Hashed(H code, T data)
        {
            Hash = code;
            Data = data;
        }

        [MethodImpl(Inline)]
        public int CompareTo(Hashed<H,T> src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public bool Equals(Hashed<H,T> src)
            => Hash.Equals(src.Hash) && Data.Equals(src.Data);

        public override int GetHashCode()
            => Scalars.int32(Hash.Value);
    }
}