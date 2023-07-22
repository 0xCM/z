//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    using static sys;

    public struct __m512i<T>
        where T : unmanaged
    {
        Cell512<T> Data;

        [MethodImpl(Inline)]
        public __m512i(Vector512<T> src)
            => Data = src;

        [MethodImpl(Inline)]
        public __m512i(Cell512<T> src)
            => Data = src;

        public uint Width => 512;

        public uint CellWidth
        {
            [MethodImpl(Inline)]
            get => width<T>();
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Width/CellWidth;
        }

        [MethodImpl(Inline), UnscopedRef]
        public ref T Cell(int i)
            => ref Data[i];

        public string Format()
            => string.Format("<{0}>", Data.ToVector());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator __m512i<T>(Vector512<T> src)
            => new __m512i<T>(src);


        [MethodImpl(Inline)]
        public static implicit operator Vector512<T>(__m512i<T> src)
            => src.Data;
    }
}