
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(AllNumeric), TestC]
        public readonly struct VTestC128<T> : IBinaryPred128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(Vector128<T> x, Vector128<T> y)
                => gcpu.vtestc(x,y);

            [MethodImpl(Inline)]
            public bit Invoke(T a, T b)
                => default;
        }

        [Closures(AllNumeric), TestC]
        public readonly struct VTestC256<T> : IBinaryPred256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(Vector256<T> x, Vector256<T> y)
                => gcpu.vtestc(x,y);

            [MethodImpl(Inline)]
            public bit Invoke(T a, T b)
                => default;
        }

        [Closures(AllNumeric), TestC]
        public readonly struct TestC128<T> : IBlockedBinaryPred128<T>
            where T : unmanaged
        {

            [MethodImpl(Inline)]
            public Span<bit> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, Span<bit> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vtestc<T>(w128));
        }

        [Closures(AllNumeric), TestC]
        public readonly struct TestC256<T> : IBlockedBinaryPred256<T>
            where T : unmanaged
        {

            [MethodImpl(Inline)]
            public Span<bit> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, Span<bit> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vtestc<T>(w256));
        }
    }
}