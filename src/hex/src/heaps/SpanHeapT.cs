//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly ref struct SpanHeap<T>
    {
        internal readonly Span<T> Segments;

        internal readonly ReadOnlySpan<uint> Offsets;

        internal readonly uint LastSegment;

        [MethodImpl(Inline)]
        internal SpanHeap(Span<T> segs, ReadOnlySpan<uint> offsets)
        {
            Segments = segs;
            Offsets = offsets;
            LastSegment = (uint)offsets.Length - 1;
        }

        public uint SegCount
        {
            [MethodImpl(Inline)]
            get => (uint)Segments.Length;
        }
    }
}