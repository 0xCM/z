//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(Integers), CNonImpl]
        public readonly struct CNonImpl<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            public const BinaryBitLogicKind OpKind = BinaryBitLogicKind.CNonImpl;

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.cnonimpl(a,b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
                => Calcs.cnonimpl(a,b,dst);
        }

        [Closures(Integers), CNonImpl]
        public readonly struct VCNonImpl128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => vgcpu.vcnonimpl(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.cnonimpl(a,b);
        }

        [Closures(Integers), CNonImpl]
        public readonly struct VCNonImpl256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => vgcpu.vcnonimpl(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.cnonimpl(a,b);
        }

        [Closures(Integers), CNonImpl]
        public readonly struct CNonImpl128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vcnonimpl<T>(w128));
        }

        [Closures(Integers), CNonImpl]
        public readonly struct CNonImpl256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vcnonimpl<T>(w256));
        }
    }
}