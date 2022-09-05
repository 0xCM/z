//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct RowKey : IRowKey<RowKey,uint>
    {
        public readonly uint Value;

        [MethodImpl(Inline)]
        public RowKey(uint value)
            => Value = value;

        [MethodImpl(Inline)]
        public bool Equals(RowKey src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(RowKey src)
            => Value.CompareTo(src.Value);

        public bool IsEmpty 
            => false;

        public bool IsNonEmpty 
            => true;

        uint IRowKey<uint>.Value
            => Value;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"{Value}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator RowKey(uint value)
            => new RowKey(value);

        [MethodImpl(Inline)]
        public static implicit operator RowKey<uint>(RowKey src)
            => src.Value;
    }
}