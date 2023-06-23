//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(UnsignedInts), Nor]
        public readonly struct BvNor<T> : IBvBinaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ScalarBits<T> Invoke(ScalarBits<T> a, ScalarBits<T> b)
                => ScalarBits.nor(a,b);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.nor(a,b);
        }

        [Closures(Integers)]
        public readonly struct VNor128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => vgcpu.vnor(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                 => gbits.nor(a,b);
        }

        [Closures(Integers)]
        public readonly struct VNor256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => vgcpu.vnor(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.nor(a,b);
        }

        [Closures(Integers), Nor]
        public readonly struct Nor<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            public const BinaryBitLogicKind OpKind = BinaryBitLogicKind.Nor;

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.nor(a,b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> l, ReadOnlySpan<T> r, Span<T> dst)
                => Calcs.nor(l,r,dst);
        }

        [Closures(Integers), Nor]
        public readonly struct Nor128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vnor<T>(w128));
        }

        [Closures(Integers), Nor]
        public readonly struct Nor256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vnor<T>(w256));
        }
    }
}