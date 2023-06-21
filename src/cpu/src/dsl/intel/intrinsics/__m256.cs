//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    public struct __m256
    {
        Cell256<float> Data;

        [MethodImpl(Inline)]
        public __m256(Vector256<float> src)
            => Data = src;

        [MethodImpl(Inline)]
        public __m256(Cell256<float> src)
            => Data = src;

        public uint Width => 256;

        public uint CellWidth
        {
            [MethodImpl(Inline)]
            get => sys.width<float>();
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Width/CellWidth;
        }

        [MethodImpl(Inline), UnscopedRef]
        public ref float Cell(int i)
            => ref Data[i];

        public num<float> this[int i]
        {
            [MethodImpl(Inline)]
            get => gcells.cell(ref Data, i/8);

            [MethodImpl(Inline)]
            set => gcells.cell(ref Data, i/8) = value;
        }

        public float this[int max, int min]
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
        public static implicit operator __m256(Vector256<float> src)
            => new __m256(src);

        [MethodImpl(Inline)]
        public static implicit operator __m256(float src)
            => vgcpu.vbroadcast(w256,src);

        [MethodImpl(Inline)]
        public static implicit operator Vector256<float>(__m256 src)
            => src.Data;
    }
}