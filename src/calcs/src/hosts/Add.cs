//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Add]
        public readonly struct Add<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(T a, T b)
                => gmath.add(a, b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
                => gcalc.apply(Calcs.add<T>(), a, b, dst);
        }

        [Closures(Closure), Add]
        public readonly struct BvAdd<T> : IBvBinaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ScalarBits<T> Invoke(ScalarBits<T> a, ScalarBits<T> b)
                => ScalarBits.add(a,b);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.add(a,b);
        }

        [Closures(AllNumeric), Add]
        public readonly struct VAdd128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            public K.Add ApiClass => default;

            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => vgcpu.vadd(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.add(a,b);
        }

        [Closures(AllNumeric), Add]
        public readonly struct VAdd256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            public K.Add ApiClass => default;

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => vgcpu.vadd(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.add(a,b);
        }

        [Closures(AllNumeric), Add]
        public readonly struct Add128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            public K.Add ApiClass => default;

            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vadd<T>(w128));
        }

        [Closures(AllNumeric), Add]
        public readonly struct Add256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            public K.Add ApiClass => default;

            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vadd<T>(w256));
        }
    }
}