//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    using static sys;

    public struct __m128i<T>
        where T : unmanaged
    {
        Cell128<T> Data;

        [MethodImpl(Inline)]
        public __m128i(Vector128<T> src)
            => Data = src;

        [MethodImpl(Inline)]
        public __m128i(Cell128<T> src)
            => Data = src;

        public uint Width => 128;

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

        public bit this[int i]
        {
            [MethodImpl(Inline)]
            get => Data.TestBit((byte)i);

            [MethodImpl(Inline)]
            set => Data.SetBit((byte)i,value);
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

        public string Format(NumericBaseKind @base)
        {
            switch(@base)
            {
                case NumericBaseKind.Base10:
                    return string.Format("<{0}>", Data.ToVector().Format());
                case NumericBaseKind.Base16:
                    return string.Format("<{0}>", Data.ToVector().FormatHex());
            }
            return EmptyString;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator __m128i<T>(Vector128<T> src)
            => new __m128i<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator __m128i<T>(T src)
            => gcpu.vbroadcast(w128,src);

        [MethodImpl(Inline)]
        public static implicit operator Vector128<T>(__m128i<T> src)
            => src.Data.ToVector();
    }
}