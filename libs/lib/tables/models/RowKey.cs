//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RowKey : IRowKey<RowKey,uint>
    {
        public uint Value {get;}

        [MethodImpl(Inline)]
        public RowKey(uint value)
            => Value = value;

        [MethodImpl(Inline)]
        public bool Equals(RowKey src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(RowKey src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => (int)Value;

        public override bool Equals(object src)
            => src is RowKey k && Equals(src);

        [MethodImpl(Inline)]
        public static implicit operator RowKey(uint value)
            => new RowKey(value);

        [MethodImpl(Inline)]
        public static implicit operator RowKey<uint>(RowKey src)
            => src.Value;
    }
}