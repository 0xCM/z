//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(AllNumeric), Min]
        public readonly struct Min<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.min(a, b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<T> dst)
                => gcalc.apply(this, lhs,rhs,dst);
        }

        [Closures(AllNumeric), Min]
        public readonly struct VMin128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => gcpu.vmin(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.min(a,b);
        }

        [Closures(AllNumeric), Min]
        public readonly struct VMin256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => gcpu.vmin(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.min(a,b);
        }

        [Closures(AllNumeric), Min]
        public readonly struct Min128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vmin<T>(w128));
        }

        [Closures(AllNumeric), Min]
        public readonly struct Min256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vmin<T>(w256));
        }
    }
}