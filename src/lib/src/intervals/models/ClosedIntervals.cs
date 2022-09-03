//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = Intervals;

    /// <summary>
    /// Defines a segmented partition over a contiguous buffer
    /// </summary>
    public ref struct ClosedIntervals<T>
        where T : unmanaged, IEquatable<T>
    {
        readonly Index<T> Buffer;

        public Index<ClosedInterval<T>> Ranges;

        public uint SegCount;

        [MethodImpl(Inline)]
        public ClosedIntervals(Index<T> buffer, uint max)
        {
            Buffer = buffer;
            Ranges = alloc<ClosedInterval<T>>(max);
            SegCount = 0;
        }

        [MethodImpl(Inline)]
        public ClosedIntervals(Index<T> buffer, Index<ClosedInterval<T>> ranges)
        {
            Buffer = buffer;
            Ranges = ranges;
            SegCount = 0;
        }

        public uint MaxSegCount
        {
            [MethodImpl(Inline)]
            get => (uint)Ranges.Length;
        }

        [MethodImpl(Inline)]
        public ref ClosedInterval<T> Range(byte index)
            => ref Ranges[index];

        [MethodImpl(Inline)]
        public ref ClosedInterval<T> Range(uint index)
            => ref Ranges[index];

        [MethodImpl(Inline)]
        public void Range(uint index, T i0, T i1)
            => Range(index) = (i0,i1);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
   }
}