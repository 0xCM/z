//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Eq]
        public readonly struct Eq<T> : IFunc<T,T,bit>,  IBinarySpanPred<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly bit Invoke(T x, T y)
                => gmath.eq(x,y);

            [MethodImpl(Inline)]
            public Span<bit> Invoke(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<bit> dst)
                => gcalc.apply(this, lhs, rhs, dst);
        }

        [Closures(AllNumeric), Eq]
        public readonly struct Eq128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
                => ref zip(a, b, dst, Calcs.veq<T>(w128));
        }

        [Closures(AllNumeric), Eq]
        public readonly struct Eq256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
                => ref zip(a, b, dst, Calcs.veq<T>(w256));
        }

        [Closures(AllNumeric), Eq]
        public readonly struct VEq128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => gcpu.veq(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.eqz(a,b);
        }

        [Closures(AllNumeric), Eq]
        public readonly struct VEq256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => gcpu.veq(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.eqz(a,b);
        }
    }
}