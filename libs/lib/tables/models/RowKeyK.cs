//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct RowKey<K> : IRowKey<RowKey<K>,K>
        where K : unmanaged
    {
        public K Value {get;}

        [MethodImpl(Inline)]
        public RowKey(K value)
            => Value = value;

        public override int GetHashCode()
            => (int)alg.hash.calc(bw64(Value));

        [MethodImpl(Inline)]
        public int CompareTo(RowKey<K> src)
            => bw64(Value).CompareTo(src.Value);

        [MethodImpl(Inline)]
        public bool Equals(RowKey<K> src)
            => bw64(Value).Equals(src.Value);

        public override bool Equals(object src)
            => src is RowKey<K> k && Equals(src);

        [MethodImpl(Inline)]
        public static implicit operator RowKey<K>(K value)
            => new RowKey<K>(value);
   }
}