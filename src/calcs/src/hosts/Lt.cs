//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Lt]
        public readonly struct Lt<T> : IFunc<T,T,bit>, IBinarySpanPred<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly bit Invoke(T x, T y)
                => gmath.lt(x,y);

            [MethodImpl(Inline)]
            public Span<bit> Invoke(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<bit> dst)
                => gcalc.apply(this, lhs,rhs,dst);
        }

        [Closures(AllNumeric), Lt]
        public readonly struct VLt128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => vgcpu.vlt(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.ltz(a,b);
        }

        [Closures(AllNumeric), Lt]
        public readonly struct VLt256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => vgcpu.vlt(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.ltz(a,b);
        }

        [Closures(AllNumeric), Lt]
        public readonly struct Lt128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vlt<T>(w128));
        }

        [Closures(AllNumeric), Lt]
        public readonly struct Lt256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vlt<T>(w256));
        }
    }
}