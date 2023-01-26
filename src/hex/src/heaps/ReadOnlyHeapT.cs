//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly ref struct ReadOnlyHeap<T>
    {
        internal readonly ReadOnlySpan<T> Segments;

        internal readonly ReadOnlySpan<uint> Offsets;

        internal readonly uint LastSegment;

        [MethodImpl(Inline)]
        public ReadOnlyHeap(ReadOnlySpan<T> segs, ReadOnlySpan<uint> offsets)
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