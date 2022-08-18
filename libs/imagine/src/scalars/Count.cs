//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a data structure that measures a nonnegative count (I mean, really, is there any other kind?) of 32-bit capacity
    /// </summary>
    public record struct Count : ICount
    {
        public uint Value;

        [MethodImpl(Inline)]
        public Count(uint value)
            => Value = value;

        [MethodImpl(Inline)]
        public Count(int value)
            => Value = (uint)value;

        [MethodImpl(Inline)]
        public bool Equals(Count src)
            => Value == src.Value;

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Value;

        public int CompareTo(Count src)
            => Value.CompareTo(src.Value);

        uint ICounted.Count
             => Value;

        [MethodImpl(Inline)]
        public static implicit operator Count(uint count)
            => new Count(count);

        [MethodImpl(Inline)]
        public static implicit operator Count(int count)
            => new Count((uint)count);

        [MethodImpl(Inline)]
        public static implicit operator Count(ushort src)
            => new Count(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(Count src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator byte(Count src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ushort(Count src)
            => (ushort)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ulong(Count src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator int(Count src)
            => (int)src.Value;

        [MethodImpl(Inline)]
        public static Count operator +(Count a, Count b)
            => new Count(a.Value + b.Value);

        [MethodImpl(Inline)]
        public static Count operator ++(Count src)
            => new Count(src.Value++);

        [MethodImpl(Inline)]
        public static Count operator --(Count src)
            => new Count(src.Value--);

        public static Count Zero => default;
    }
}