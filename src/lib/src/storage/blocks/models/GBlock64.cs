//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    /// <summary>
    /// Defines storage for contiguous sequence of 64 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock64<T> : IStorageBlock<GBlock64<T>>, ICellBlock<T>
        where T : unmanaged
    {
        public const uint CellCount = 32;

        GBlock32<T> A;

        GBlock32<T> B;

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cover<GBlock64<T>,T>(this, CellCount);
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref first(Cells);
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First, index);
        }

        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First, index);
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        [MethodImpl(Inline)]
        public Span<T> Segment(uint i0, uint i1)
            => core.segment(Cells, i0, i1);


        [MethodImpl(Inline)]
        public Span<T> Segment(int i0, int i1)
            => core.segment(Cells, i0, i1);

        public ByteSize ByteCount
            => CellCount*size<T>();

        public static GBlock32<T> Empty => default;
    }
}