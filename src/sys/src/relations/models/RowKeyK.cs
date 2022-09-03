//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct RowKey<K> : IRowKey<RowKey<K>,K>
        where K : unmanaged
    {
        public K Value {get;}

        [MethodImpl(Inline)]
        public RowKey(K value)
            => Value = value;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => nhash(Value);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(RowKey<K> src)
            => bw64(Value).CompareTo(src.Value);

        [MethodImpl(Inline)]
        public bool Equals(RowKey<K> src)
            => bw64(Value).Equals(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator RowKey<K>(K value)
            => new RowKey<K>(value);
   }
}