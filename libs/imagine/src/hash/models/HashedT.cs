//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct Hashed<T> : IEquatable<Hashed<T>>, IComparable<Hashed<T>>
        where T : IEquatable<T>, IComparable<T>
    {
        public readonly Hash32 Hash;

        public readonly T Data;

        [MethodImpl(Inline)]
        public Hashed(Hash32 code, T data)
        {
            Hash = code;
            Data = data;
        }

        [MethodImpl(Inline)]
        public bool Equals(Hashed<T> src)
            => Hash.Equals(src.Hash) && Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public int CompareTo(Hashed<T> src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => Hash;
    }
}