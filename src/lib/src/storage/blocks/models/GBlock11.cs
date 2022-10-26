//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for contiguous sequence of 11 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct GBlock11<T> : IStorageBlock<GBlock11<T>>, ICellBlock<T>
        where T : unmanaged
    {
        public const uint CellCount = 11;

        GBlock10<T> A;

        GBlock<T> B;

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cover<GBlock11<T>,T>(this, CellCount);
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

        public static GBlock11<T> Empty => default;

    }
}