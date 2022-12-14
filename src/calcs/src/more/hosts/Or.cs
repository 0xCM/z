//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    using K = ApiClasses.Or;

    partial struct CalcHosts
    {
        [Closures(Integers), Or]
        public readonly struct Or<T> : IBinaryOp<T>, IBinarySpanOp<T>, IClassified<K,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.or(a,b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> l, ReadOnlySpan<T> r, Span<T> dst)
                => Calcs.or(l,r,dst);
        }

        [Closures(Closure), Or]
        public readonly struct BvOr<T> : IBvBinaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ScalarBits<T> Invoke(ScalarBits<T> a, ScalarBits<T> b)
                => BitVectors.or(a,b);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.or(a,b);
        }

        [Closures(Integers), Or]
        public readonly struct VOr128<T> : IBinaryOp128D<T>, IClassified<K,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => gcpu.vor(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.or(a,b);
        }

        [Closures(Integers), Or]
        public readonly struct VOr256<T> : IBinaryOp256D<T>, IClassified<K,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => gcpu.vor(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.or(a,b);
        }

        [Closures(Integers), Or]
        public readonly struct Or128<T> : IBlockedBinaryOp128<T>, IClassified<K,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
                => ref SpanBlocks.zip(a, b, dst, Calcs.vor<T>(w128));
        }

        [Closures(Integers), Or]
        public readonly struct Or256<T> : IBlockedBinaryOp256<T>, IClassified<K,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
                => ref SpanBlocks.zip(a, b, dst, Calcs.vor<T>(w256));
        }
    }
}