//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct RowSequence : IComparable<RowSequence>, IEquatable<RowSequence>
    {
        public readonly uint Value;

        [MethodImpl(Inline)]
        public RowSequence(uint src)
        {
            Value = src;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        [MethodImpl(Inline)]
        public bool Equals(RowSequence src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public int CompareTo(RowSequence other)
            => Value.CompareTo(other.Value);

        [MethodImpl(Inline)]
        public static implicit operator RowSequence(uint src)
            => new RowSequence(src);

        [MethodImpl(Inline)]
        public static implicit operator RowSequence(int src)
            => new RowSequence((uint)src);
    }
}