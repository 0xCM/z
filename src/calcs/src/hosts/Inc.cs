//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Inc]
        public readonly struct Inc<T> : IUnaryOp<T>, IUnarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(T a)
                => gmath.inc(a);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> src, Span<T> dst)
                => Calcs.inc(src,dst);
        }

        [NumericClosures(Integers)]
        public readonly struct VInc128<T> : IUnaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => gcpu.vinc(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.inc(a);
        }

        [NumericClosures(Integers)]
        public readonly struct VInc256<T> : IUnaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x)
                => gcpu.vinc(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.inc(a);
        }

        [NumericClosures(AllNumeric), Inc]
        public readonly struct Inc128<T> : IBlockedUnaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> src, SpanBlock128<T> dst)
                => SpanBlocks.map(src, dst, Calcs.vinc<T>(w128));
        }

        [NumericClosures(AllNumeric), Inc]
        public readonly struct Inc256<T> : IBlockedUnaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> src, SpanBlock256<T> dst)
                => SpanBlocks.map(src, dst, Calcs.vinc<T>(w256));
        }
    }
}