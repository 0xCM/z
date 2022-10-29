//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential, Size = (int)Size)]
    public struct PageBlock2<T> : IPageBlock<PageBlock2<T>>
        where T : unmanaged, IEquatable<T>
    {
        public const uint PageCount = 2;

        public const uint Size = PageSize*PageCount;

        [MethodImpl(Inline)]
        public static ref PageBlock2<S> retype<S>(ref PageBlock2<T> src)
            where S : unmanaged, IEquatable<S>
                => ref @as<PageBlock2<T>,PageBlock2<S>>(src);

        [MethodImpl(Inline)]
        public static ref PageBlock2 untype<S>(ref PageBlock2<T> src)
            where S : unmanaged
                => ref @as<PageBlock2<T>,PageBlock2>(src);

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => PageSize/size<T>();
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public Span<T> Cells
        {
            [MethodImpl(Inline)]
            get => recover<T>(Bytes);
        }

        public ref T First
        {
            [MethodImpl(Inline)]
            get => ref first(Cells);
        }

        public ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Cells,index);
        }

        public ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Cells,index);
        }

        [MethodImpl(Inline)]
        public ref T Cell(int index)
            => ref seek(Cells, index);

        [MethodImpl(Inline)]
        public ref T Cell(uint index)
            => ref seek(Cells, index);
    }
}