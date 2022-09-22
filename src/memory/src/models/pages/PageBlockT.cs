//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential, Size = (int)Size)]
    public struct PageBlock<T> : IPageBlock<PageBlock<T>>
        where T : unmanaged, IEquatable<T>
    {
        public const uint Size = PageSize;

        public const uint PageCount = 1;

        [MethodImpl(Inline)]
        public static ref PageBlock<S> retype<S>(ref PageBlock<T> src)
            where S : unmanaged, IEquatable<S>
                => ref @as<PageBlock<T>,PageBlock<S>>(src);

        [MethodImpl(Inline)]
        public static ref PageBlock1 untype<S>(ref PageBlock<T> src)
            where S : unmanaged
                => ref @as<PageBlock<T>,PageBlock1>(src);

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