//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    /// <summary>
    /// Defines storage for contiguous sequence of 8 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1), DataTypeAttributeD("block<n:7,t:{0}>")]
    public struct GBlock8<T> : IStorageBlock<GBlock8<T>>, ICellBlock<GBlock8<T>,T>
        where T : unmanaged
    {
        public const uint CellCount = 8;

        GBlock4<T> A;

        GBlock4<T> B;

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cover<GBlock8<T>,T>(this, CellCount);
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

        public static GBlock8<T> Empty => default;
    }
}