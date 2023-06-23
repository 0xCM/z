//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(AllNumeric), Gt]
        public readonly struct VGt128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => vgcpu.vgt(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.gtz(a,b);
        }

        [Closures(AllNumeric), Gt]
        public readonly struct VGt256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => vgcpu.vgt(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.gtz(a,b);
        }

        [Closures(AllNumeric), Gt]
        public readonly struct Gt<T> : IFunc<T,T,bit>, IBinarySpanPred<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public bit Invoke(T a, T b)
                => gmath.gt(a,b);

            [MethodImpl(Inline)]
            public Span<bit> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<bit> dst)
                => gcalc.apply(this, a,b,dst);
        }

        [Closures(AllNumeric), Gt]
        public readonly struct Gt128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vgt<T>(w128));
        }

        [Closures(AllNumeric), Gt]
        public readonly struct Gt256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vgt<T>(w256));
        }
    }
}