//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly ref struct BinaryHeap<T>
        where T : unmanaged
    {
        readonly Span<T> Data;

        readonly Span<uint> Offsets;

        public readonly uint Capacity;

        [MethodImpl(Inline)]
        public BinaryHeap(Span<T> src, Span<uint> offsets)
        {
            Data = src;
            Offsets = offsets;
            Capacity = (uint)Require.equal(src.Length, offsets.Length);
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [MethodImpl(Inline)]
        public ref uint Offset(uint index)
            => ref seek(Offsets, index);

        [MethodImpl(Inline)]
        public static implicit operator BinaryHeap(BinaryHeap<T> src)
            => new BinaryHeap(recover<T,byte>(src.Data), src.Offsets);

        [MethodImpl(Inline)]
        public static implicit operator BinaryHeap<T>(BinaryHeap src)
            => new BinaryHeap<T>(src.Cells<T>(), src.Offsets);
    }
}