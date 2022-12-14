//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(UnsignedInts), Not]
        public readonly struct BvNot<T> : IBvUnaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ScalarBits<T> Invoke(ScalarBits<T> a)
                => BitVectors.not(a);

            [MethodImpl(Inline)]
            public T Invoke(T a) => gmath.not(a);
        }

        [Closures(Integers), Not]
        public readonly struct VNot128<T> : IUnaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x)
                => gcpu.vnot(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gbits.not(a);
        }

        [NumericClosures(Integers), Not]
        public readonly struct VNot256<T> : IUnaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x)
                => gcpu.vnot(x);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gbits.not(a);
        }

        [Closures(Integers), Not]
        public readonly struct Not<T> : IUnaryOp<T>, IUnarySpanOp<T>
            where T : unmanaged
        {
            public const UnaryBitLogicKind OpKind = UnaryBitLogicKind.Not;

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gmath.not(a);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> src, Span<T> dst)
                => Calcs.not(src,dst);
        }

        [NumericClosures(Integers), Not]
        public readonly struct Not128<T> : IBlockedUnaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> src, in SpanBlock128<T> dst)
                => ref SpanBlocks.map(src, dst, Calcs.vnot<T>(w128));
        }

        [NumericClosures(Integers), Not]
        public readonly struct Not256<T> : IBlockedUnaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> src, in SpanBlock256<T> dst)
                => ref SpanBlocks.map(src, dst, Calcs.vnot<T>(w256));
        }

    }
}