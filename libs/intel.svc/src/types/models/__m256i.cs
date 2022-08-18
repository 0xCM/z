//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class intel
    {
        public struct __m256i<T>
            where T : unmanaged
        {
            Cell256<T> Data;

            [MethodImpl(Inline)]
            public __m256i(Vector256<T> src)
                => Data = src;

            [MethodImpl(Inline)]
            public __m256i(Cell256<T> src)
                => Data = src;

            public uint Width => 256;

            public uint CellWidth
            {
                [MethodImpl(Inline)]
                get => core.width<T>();
            }

            public uint CellCount
            {
                [MethodImpl(Inline)]
                get => Width/CellWidth;
            }

            [MethodImpl(Inline)]
            public ref T Cell(int i)
                => ref Data[i];

            public num<T> this[int i]
            {
                [MethodImpl(Inline)]
                get => Cells.cell(ref Data, i/8);

                [MethodImpl(Inline)]
                set => Cells.cell(ref Data, i/8) = value;
            }

            public T this[int max, int min]
            {
                [MethodImpl(Inline)]
                get => Cells.bits(ref Data, max, min);
                [MethodImpl(Inline)]
                set => Cells.bits(ref Data, max, min) = value;
            }

            public string Format()
                => string.Format("<{0}>", Data.ToVector().FormatHex());

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator __m256i<T>(Vector256<T> src)
                => new __m256i<T>(src);

            [MethodImpl(Inline)]
            public static implicit operator __m256i<T>(T src)
                => gcpu.vbroadcast(w256,src);

            [MethodImpl(Inline)]
            public static implicit operator Vector256<T>(__m256i<T> src)
                => src.Data;
        }
    }
}