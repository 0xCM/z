//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiClasses;

    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory, Closures(Integers)]
        public static BitLogic<T> bitlogic<T>()
            where T : unmanaged
                => default(BitLogic<T>);

        [MethodImpl(Inline), Factory(Abs), Closures(SignedInts)]
        public static Abs<T> abs<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Abs, Closures(SignedInts)]
        public static Span<T> abs<T>(ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(abs<T>(), src, dst);

        [MethodImpl(Inline), Factory(Abs), Closures(SignedInts)]
        public static Abs128<T> abs<T>(W128 w)
            where T : unmanaged
                => default(Abs128<T>);

        [MethodImpl(Inline), Factory(Abs), Closures(SignedInts)]
        public static Abs256<T> abs<T>(W256 w)
            where T : unmanaged
                => default(Abs256<T>);

        [MethodImpl(Inline), Factory(Abs), Closures(SignedInts)]
        public static VAbs128<T> vabs<T>(W128 w)
            where T : unmanaged
                => default(VAbs128<T>);

        [MethodImpl(Inline), Factory(Abs), Closures(SignedInts)]
        public static VAbs256<T> vabs<T>(W256 w)
            where T : unmanaged
                => default(VAbs256<T>);

        [MethodImpl(Inline), Abs, Closures(SignedInts)]
        public static ref readonly SpanBlock128<T> abs<T>(in SpanBlock128<T> a, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref abs<T>(w128).Invoke(a, dst);

        [MethodImpl(Inline), Abs, Closures(SignedInts)]
        public static ref readonly SpanBlock256<T> abs<T>(in SpanBlock256<T> a, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref abs<T>(w256).Invoke(a, dst);

        [Closures(AllNumeric), Abs]
        public readonly struct Abs<T> : IUnaryOp<T>, IUnarySpanOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(T a)
                => gmath.abs(a);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, Span<T> dst)
                => gcalc.apply(Calcs.abs<T>(), a, dst);
        }

        [Closures(AllNumeric), Abs]
        public readonly struct Abs128<T> : IBlockedUnaryOp128<T>
            where T : unmanaged
        {
            public K.Abs ApiClass => default;

            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> src, in SpanBlock128<T> dst)
                => ref SpanBlocks.map(src, dst, Calcs.vabs<T>(w128));
        }

        [Closures(AllNumeric), Abs]
        public readonly struct Abs256<T> : IBlockedUnaryOp256<T>
            where T : unmanaged
        {
            public K.Abs ApiClass => default;

            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> src, in SpanBlock256<T> dst)
                => ref SpanBlocks.map(src, dst, Calcs.vabs<T>(w256));
        }

        [Closures(SignedInts), Abs]
        public readonly struct VAbs128<T> : IUnaryOp128D<T>
            where T : unmanaged
        {
            public K.Abs ApiClass => default;

            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => gcpu.vabs(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.abs(a);
        }

        [Closures(SignedInts), Abs]
        public readonly struct VAbs256<T> : IUnaryOp256D<T>
            where T : unmanaged
        {
            public K.Abs ApiClass => default;

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x)
                => gcpu.vabs(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.abs(a);
        }
    }
}