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
        public readonly K Value;

        [MethodImpl(Inline)]
        public RowKey(K value)
            => Value = value;

        public bool IsEmpty 
            => false;

        public bool IsNonEmpty 
            => true;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => nhash(Value);
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"{Value}";

        public override string ToString()
            => Format();

        K IRowKey<K>.Value
            => Value;

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