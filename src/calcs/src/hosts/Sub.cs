//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Sub]
        public readonly struct Sub<T>  : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(T a, T b)
                => gmath.sub(a,b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<T> dst)
                => Calcs.sub(lhs,rhs,dst);
        }

        [Closures(UnsignedInts), Sub]
        public readonly struct BvSub<T> : IBvBinaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ScalarBits<T> Invoke(ScalarBits<T> a, ScalarBits<T> b)
                => BitVectors.sub(a,b);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.sub(a,b);
        }

        [Closures(AllNumeric), Sub]
        public readonly struct VSub128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => gcpu.vsub(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.sub(a,b);
        }

        [Closures(AllNumeric), Sub]
        public readonly struct VSub256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => gcpu.vsub(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.sub(a,b);
        }

        [Closures(AllNumeric), Sub]
        public readonly struct Sub128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
                => ref SpanBlocks.zip(a, b, dst, Calcs.vsub<T>(w128));
        }

        [Closures(AllNumeric), Sub]
        public readonly struct Sub256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
                => ref SpanBlocks.zip(a, b, dst, Calcs.vsub<T>(w256));
        }
    }
}