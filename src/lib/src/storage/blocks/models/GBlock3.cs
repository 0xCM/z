//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    /// <summary>
    /// Defines storage for contiguous sequence of 3 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock3<T> : IStorageBlock<GBlock3<T>>, ICellBlock<GBlock3<T>,T>
        where T : unmanaged
    {
        public const uint CellCount = 3;

        GBlock<T> A;

        GBlock2<T> B;

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cover<GBlock3<T>,T>(this, CellCount);
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

        public ByteSize ByteCount
            => CellCount*size<T>();

        public static GBlock3<T> Empty => default;

    }
}