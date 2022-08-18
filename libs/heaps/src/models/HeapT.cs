//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Heaps;

    internal class Heap<T>
    {
        readonly Index<T> Data;

        readonly Index<uint> Offsets;

        public readonly uint CellCount;

        [MethodImpl(Inline)]
        public Heap(Index<T> src, uint[] offsets)
        {
            Data = src;
            Offsets = offsets;
            CellCount = (uint)Require.equal(src.Length, offsets.Length);
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        [MethodImpl(Inline)]
        public ref uint Offset(uint index)
            => ref Offsets[index];

        [MethodImpl(Inline)]
        public Span<T> Segment(uint index)
            => api.segment(this, index);

        public Span<T> this[uint index]
        {
            [MethodImpl(Inline)]
            get => Segment(index);
        }
    }
}