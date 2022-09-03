//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct RowKey : IRowKey<RowKey,uint>
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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator RowKey(uint value)
            => new RowKey(value);

        [MethodImpl(Inline)]
        public static implicit operator RowKey<uint>(RowKey src)
            => src.Value;
    }
}