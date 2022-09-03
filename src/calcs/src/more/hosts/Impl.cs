//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(Integers), Impl]
        public readonly struct Impl<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            public const BinaryBitLogicKind OpKind = BinaryBitLogicKind.Impl;

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.impl(a,b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
                => Calcs.impl(a,b,dst);
        }

        [Closures(Integers), Impl]
        public readonly struct VImpl128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => gcpu.vimpl(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.impl(a,b);
        }

        [Closures(Integers), Impl]
        public readonly struct VImpl256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => gcpu.vimpl(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.impl(a,b);
        }

        [Closures(Integers), Impl]
        public readonly struct Impl128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
                => ref zip(a, b, dst, Calcs.vimpl<T>(w128));
        }

        [Closures(Integers), Impl]
        public readonly struct Impl256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
                => ref zip(a, b, dst, Calcs.vimpl<T>(w256));
        }
    }
}