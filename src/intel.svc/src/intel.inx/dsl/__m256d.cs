//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    using static sys;

    public struct __m256d
    {
        Cell256<double> Data;

        [MethodImpl(Inline)]
        public __m256d(Vector256<double> src)
            => Data = src;

        [MethodImpl(Inline)]
        public __m256d(Cell256<double> src)
            => Data = src;

        public uint Width => 256;

        public uint CellWidth
        {
            [MethodImpl(Inline)]
            get => width<double>();
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Width/CellWidth;
        }

        [MethodImpl(Inline), UnscopedRef]
        public ref double Cell(int i)
            => ref Data[i];

        public num<double> this[int i]
        {
            [MethodImpl(Inline)]
            get => gcells.cell(ref Data, i/8);

            [MethodImpl(Inline)]
            set => gcells.cell(ref Data, i/8) = value;
        }

        public double this[int max, int min]
        {
            [MethodImpl(Inline)]
            get => gcells.bits(ref Data, max, min);
            [MethodImpl(Inline)]
            set => gcells.bits(ref Data, max, min) = value;
        }

        public string Format()
            => string.Format("<{0}>", Data.ToVector().FormatHex());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator __m256d(Vector256<double> src)
            => new __m256d(src);

        [MethodImpl(Inline)]
        public static implicit operator __m256d(double src)
            => vgcpu.vbroadcast(w256,src);

        [MethodImpl(Inline)]
        public static implicit operator Vector256<double>(__m256d src)
            => src.Data;
    }
}