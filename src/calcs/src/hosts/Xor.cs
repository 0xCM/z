//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(Integers), Xor]
        public readonly struct Xor<T> : IBinaryOp<T>, IBinarySpanOp<T>
            where T : unmanaged
        {
            public const BinaryBitLogicKind OpKind = BinaryBitLogicKind.Xnor;

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.xor(a,b);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> l, ReadOnlySpan<T> r, Span<T> dst)
                => Calcs.xor(l,r,dst);
        }

        [Closures(UnsignedInts), Xor]
        public readonly struct BvXor<T> : IBvBinaryOp<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly ScalarBits<T> Invoke(ScalarBits<T> a, ScalarBits<T> b)
                => BitVectors.xor(a,b);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gmath.xor(a,b);
        }

        [Closures(Integers), Xor]
        public readonly struct VXor128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => gcpu.vxor(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.xor(a,b);
        }

        [Closures(Integers), Xor]
        public readonly struct VXor256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y)
                => gcpu.vxor(x,y);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b)
                => gbits.xor(a,b);
        }

        [Closures(Integers), Xor]
        public readonly struct Xor128<T> : IBlockedBinaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
                => ref SpanBlocks.zip(a, b, dst, Calcs.vxor<T>(w128));
        }

        [Closures(Integers), Xor]
        public readonly struct Xor256<T> : IBlockedBinaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
                => ref SpanBlocks.zip(a, b, dst, Calcs.vxor<T>(w256));
        }
    }
}