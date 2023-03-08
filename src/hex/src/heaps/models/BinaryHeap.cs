//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly ref struct BinaryHeap
    {
        readonly Span<byte> Data;

        internal readonly Span<uint> Offsets;

        public readonly uint Capacity;

        [MethodImpl(Inline)]
        public BinaryHeap(Span<byte> src, Span<uint> offsets)
        {
            Data = src;
            Offsets = offsets;
            Capacity = (uint)offsets.Length;
        }

        [MethodImpl(Inline)]
        public Span<T> Cells<T>()
            where T : unmanaged
                => recover<T>(Data);

        [MethodImpl(Inline)]
        public ref uint Offset(uint index)
            => ref seek(Offsets, index);

        [MethodImpl(Inline)]
        public ref uint Offset(int index)
            => ref seek(Offsets, index);
    }
}