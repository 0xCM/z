//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Key<T> : IHashed
        where T : unmanaged
    {
        public readonly T Value;

        public readonly Hash32 Hash;

        [MethodImpl(Inline)]
        public Key(T src)
        {
            Value = src;
            Hash = sys.nhash(src);
        }

        [MethodImpl(Inline)]
        public Key(T src, uint hash)
        {
            Value = src;
            Hash = hash;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        Hash32 IHashed.Hash
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator Key<T>(T src)
            => new Key<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(Key<T> src)
            => src.Value;
    }
}