//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 640640
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Size = (int)Size)]
    public struct PageBlock64<T> : IPageBlock<PageBlock64<T>>
        where T : unmanaged, IEquatable<T>
    {
        public const uint PageCount = 64;

        public const uint Size = PageSize*PageCount;

        [MethodImpl(Inline)]
        public static ref PageBlock64<S> retype<S>(ref PageBlock64<T> src)
            where S : unmanaged, IEquatable<S>
                => ref @as<PageBlock64<T>,PageBlock64<S>>(src);

        [MethodImpl(Inline)]
        public static ref PageBlock64 untype<S>(ref PageBlock64<T> src)
            where S : unmanaged
                => ref @as<PageBlock64<T>,PageBlock64>(src);

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