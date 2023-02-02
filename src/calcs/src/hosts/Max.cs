//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(AllNumeric), Max]
        public readonly struct Max<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.max(a, b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
                => gcalc.apply(this, a,b,dst);
        }

        [Closures(AllNumeric), Max]
        public readonly struct VMax128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => gcpu.vmax(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.max(a,b);
        }

        [Closures(AllNumeric), Max]
        public readonly struct VMax256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => gcpu.vmax(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.max(a,b);
        }

        [Closures(AllNumeric), Max]
        public readonly struct Max128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vmax<T>(w128));
        }

        [Closures(AllNumeric), Max]
        public readonly struct Max256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vmax<T>(w256));
        }
    }
}