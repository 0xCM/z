//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RowSequence : IComparable<RowSequence>, IEquatable<RowSequence>
    {
        public uint Value {get;}

        [MethodImpl(Inline)]
        public RowSequence(uint src)
        {
            Value = src;
        }

        [MethodImpl(Inline)]
        public bool Equals(RowSequence src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => (int)Value;

        public override bool Equals(object src)
            => src is RowSequence s && Equals(s);

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