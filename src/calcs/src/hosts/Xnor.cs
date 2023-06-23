//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(Integers), Xnor]
        public readonly struct Xnor<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            public const BinaryBitLogicKind OpKind = BinaryBitLogicKind.Xnor;

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.xnor(a, b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> l, ReadOnlySpan<T> r, Span<T> dst)
                => Calcs.nor(l,r,dst);
        }

        [Closures(UnsignedInts), Xnor]
        public readonly struct BvXnor<T> : IBvBinaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ScalarBits<T> Invoke(ScalarBits<T> a, ScalarBits<T> b)
                => BitVectors.xnor(a,b);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.xnor(a,b);
        }

        [Closures(Integers), Xnor]
        public readonly struct VXnor128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => vgcpu.vxnor(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.xnor(a,b);
        }

        [Closures(Integers), Xnor]
        public readonly struct VXnor256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => vgcpu.vxnor(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.xnor(a,b);
        }

        [Closures(Integers), Xnor]
        public readonly struct Xnor128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vxnor<T>(w128));
        }

        [Closures(Integers), Xnor]
        public readonly struct Xnor256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vxnor<T>(w256));
        }
    }
}