//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class intel
    {
        const NumericKind Closure = NumericKind.UnsignedInts;

        const string group = "intel";

        [MethodImpl(Inline)]
        public static CmpPred128<T> eq<T>(__m128i<T> a, __m128i<T> b)
            where T : unmanaged
                => new CmpPred128<T>(CmpPredKind.EQ,a,b);

        [MethodImpl(Inline), Closures(Closure)]
        public static __m128i<T> m128i<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Closures(Closure)]
        public static __m256i<T> m256i<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Closures(Closure)]
        public static __m512i<T> m512i<T>()
            where T : unmanaged
                => default;

        public static __m128i<byte> z128i(W8 w)
            => default;

        public static __m128i<sbyte> z128i(W8i w)
            => default;

        public static __m128i<ushort> z128i(W16 w)
            => default;

        public static __m128i<uint> z128i(W32 w)
            => default;

        public static __m128i<ulong> z128i(W64 w)
            => default;

        public static __m256i<byte> z256i(W8 w)
            => default;

        public static __m512i<byte> z512i(W8 w)
            => default;
    }
}