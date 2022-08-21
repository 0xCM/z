//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    /// <summary>
    /// Defines an inclusive address range
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct MemoryRange : IMemoryRange<MemoryRange>
    {
        [MethodImpl(Inline)]
        public static MemoryRange define(MemoryAddress min, MemoryAddress max)
            => new MemoryRange(min,max);

        [MethodImpl(Inline)]
        public static MemoryRange define(MemoryAddress min, ByteSize size)
            => new MemoryRange(min, size);

        /// <summary>
        /// The inclusive address at which the range begins
        /// </summary>
        public readonly MemoryAddress Min {get;}

        /// <summary>
        /// The inclusive address at which the range ends
        /// </summary>
        public readonly MemoryAddress Max {get;}

        [MethodImpl(Inline)]
        public MemoryRange(MemoryAddress min, MemoryAddress max)
        {
            Min = min;
            Max = max;
        }

        [MethodImpl(Inline)]
        public MemoryRange(MemoryAddress min, ByteSize size)
        {
            Min = min;
            Max = min + size;
        }

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => (ulong)Max - (ulong)Min;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => ByteCount == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => ByteCount != 0;
        }

        public override int GetHashCode()
            => (int)hash((ulong)Min, (ulong)Max);

        [MethodImpl(Inline)]
        public bool Equals(MemoryRange src)
            => Min == src.Min && Max == src.Max;

        [MethodImpl(Inline)]
        public bool Contains(MemoryRange src)
            => src.Min >= Min && src.Max <= Max;

        [MethodImpl(Inline)]
        public bool Contains(MemoryAddress src)
            => src.Location >= Min && src.Location <= Max;

        [MethodImpl(Inline)]
        public int CompareTo(MemoryRange src)
            => this == src ? 0 : this < src ? -1 : 1;

        public string Format()
            => string.Format("[{0}]", string.Concat(Min.Format(), Chars.Comma, Chars.Space, Max.Format()));

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator<(MemoryRange a, MemoryRange b)
            => a.Min < b.Min;

        [MethodImpl(Inline)]
        public static bool operator>(MemoryRange a, MemoryRange b)
            => a.Min > b.Min;

        [MethodImpl(Inline)]
        public static bool operator<=(MemoryRange a, MemoryRange b)
            => a.Min <= b.Min;

        [MethodImpl(Inline)]
        public static bool operator>=(MemoryRange a, MemoryRange b)
            => a.Min >= b.Min;

        [MethodImpl(Inline)]
        public static implicit operator MemoryRange((MemoryAddress start, MemoryAddress end) src)
            => new MemoryRange(src.start, src.end);

        public static MemoryRange Empty => default;
    }
}