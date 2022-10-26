//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines storage for contiguous sequence of 12 T-cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1), DataTypeAttributeD("block<n:12,t:{0}>")]
    public struct GBlock12<T> : IStorageBlock<GBlock12<T>>
        where T : unmanaged
    {
        public const uint CellCount = 12;

        GBlock6<T> A;

        GBlock6<T> B;

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => cover<GBlock12<T>,T>(this, CellCount);
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

        public static GBlock12<T> Empty => default;

    }
}