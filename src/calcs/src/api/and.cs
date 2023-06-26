//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;
    using static ApiClassKind;

    using K = ApiClasses;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(And), Closures(Closure)]
        public static And<T> and<T>()
            where T : unmanaged
                => default(And<T>);

        [MethodImpl(Inline), And, Closures(Closure)]
        public static Span<T> and<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(and<T>(), a,b,dst);

        [MethodImpl(Inline), Factory(And), Closures(Closure)]
        public static BvAnd<T> bvand<T>()
            where T : unmanaged
                => sfunc<BvAnd<T>>();

        [MethodImpl(Inline), Factory(And), Closures(Closure)]
        public static VAnd128<T> vand<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VAnd128<T>);

        [MethodImpl(Inline), Factory(And), Closures(Closure)]
        public static VAnd256<T> vand<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VAnd256<T>);

        [MethodImpl(Inline), Factory(And), Closures(Closure)]
        public static And128<T> and<T>(W128 w)
            where T : unmanaged
                => default(And128<T>);

        [MethodImpl(Inline), Factory(And), Closures(Closure)]
        public static And256<T> and<T>(W256 w)
            where T : unmanaged
                => default(And256<T>);

        [Closures(Integers), And]
        public readonly struct And<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            public T Invoke(T a, T b)
                => gmath.and(a,b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
                => gcalc.apply(and<T>(), a, b, dst);
        }

        [Closures(UnsignedInts), And]
        public readonly struct BvAnd<T> : IBvBinaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ScalarBits<T> Invoke(ScalarBits<T> a, ScalarBits<T> b)
                => ScalarBits.and(a,b);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.and(a,b);
        }

        [Closures(Integers), And]
        public readonly struct VAnd128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            public K.And ApiClass => default;

            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => vgcpu.vand(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.and(a,b);
        }

        [Closures(Integers), And]
        public readonly struct VAnd256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            public K.And ApiClass => default;

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => vgcpu.vand(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.and(a,b);
        }

        [Closures(Integers), And]
        public readonly struct And128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            public K.And ApiClass => default;

            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, vand<T>(w128));
        }

        [Closures(Integers), And]
        public readonly struct And256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            public K.And ApiClass => default;

            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, vand<T>(w256));
        }

        [MethodImpl(Inline), And, Closures(Closure)]
        public static SpanBlock128<T> and<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged
                => and<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), And, Closures(Closure)]
        public static SpanBlock256<T> and<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged
                => and<T>(w256).Invoke(a, b, dst);


        /// <summary>
        /// Computes lhs[i] := lhs[i] & rhs[i] for i = 0...N-1
        /// </summary>
        /// <param name="lhs">The left operand which will be updated in-place</param>
        /// <param name="rhs">The right operand</param>
        /// <typeparam name="N">The length type</typeparam>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline)]
        public static Block256<N,T> and<N,T>(Block256<N,T> lhs, Block256<N,T> rhs)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var dst = RowVectors.blockalloc<N,T>();
            and<T>(lhs.Data, rhs.Data, dst);
            return dst;
        }
    }
}