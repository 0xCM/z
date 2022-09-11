//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct RowSeq : IComparable<RowSeq>, IEquatable<RowSeq>
    {
        public readonly uint Value;

        [MethodImpl(Inline)]
        public RowSeq(uint src)
        {
            Value = src;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        [MethodImpl(Inline)]
        public bool Equals(RowSeq src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public int CompareTo(RowSeq other)
            => Value.CompareTo(other.Value);

        [MethodImpl(Inline)]
        public static implicit operator RowSeq(uint src)
            => new RowSeq(src);

        [MethodImpl(Inline)]
        public static implicit operator RowSeq(int src)
            => new RowSeq((uint)src);
    }
}