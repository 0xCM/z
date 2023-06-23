//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(Integers), Nand]
        public readonly struct Nand<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            public const BinaryBitLogicKind OpKind = BinaryBitLogicKind.Nand;

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.nand(a,b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> l, ReadOnlySpan<T> r, Span<T> dst)
                => Calcs.nand(l,r,dst);
        }

        [Closures(UnsignedInts)]
        public readonly struct BvNand<T> : IBvBinaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ScalarBits<T> Invoke(ScalarBits<T> a, ScalarBits<T> b)
                => ScalarBits.nand(a,b);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.nand(a,b);
        }

        [Closures(Integers), Nand]
        public readonly struct VNand128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => vgcpu.vnand(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.nand(a,b);
        }

        [Closures(Integers), Nand]
        public readonly struct VNand256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => vgcpu.vnand(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.nand(a,b);

        }

        [Closures(Integers), Nand]
        public readonly struct Nand128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vnand<T>(w128));
        }

        [Closures(Integers), Nand]
        public readonly struct Nand256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, b, dst, Calcs.vnand<T>(w256));
        }
    }
}