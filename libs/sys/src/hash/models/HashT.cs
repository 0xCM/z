//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Hash<T> : IComparable<Hash<T>>
        where T : unmanaged, IHashCode, IEquatable<T>, IComparable<T>
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public Hash(T src)
        {
            Value = src;
        }

        public override int GetHashCode()
            => sys.i32(Value.Data);

        [MethodImpl(Inline)]
        public bool Equals(Hash<T> src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(Hash<T> src)
            => Value.CompareTo(src.Value);

        public static implicit operator Hash<T>(T src)
            => new Hash<T>(src);
    }
}