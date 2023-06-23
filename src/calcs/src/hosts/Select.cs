//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(Integers), Select]
        public readonly struct VSelect128<T> : ITernaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y, Vector128<T> z)
                => vgcpu.vselect(x,y,z);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b, T c)
                => gbits.select(a,b,c);
        }

        [Closures(Integers), Select]
        public readonly struct VSelect256<T> : ITernaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> y, Vector256<T> z)
                => vgcpu.vselect(x,y,z);

            [MethodImpl(Inline)]
            public T Invoke(T a, T b, T c)
                => gbits.select(a,b,c);
        }

        [Closures(Integers), Select]
        public readonly struct Select<T> : ITernaryOp<T>, ITernarySpanOp<T>
            where T : unmanaged
        {
            public const TernaryBitLogicKind OpKind = TernaryBitLogicKind.XCA;

            [MethodImpl(Inline)]
            public T Invoke(T a, T b, T c)
                => gmath.select(a, b, c);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> a, ReadOnlySpan<T> b, ReadOnlySpan<T> c, Span<T> dst)
                => Calcs.select(a,b,c,dst);
        }

        [Closures(Integers), Select]
        public readonly struct Select128<T> : IBlockedTernaryOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> c, SpanBlock128<T> dst)
                => SpanBlocks.zip(a,b,c,dst, Calcs.vselect<T>(w128));
        }

        [Closures(Integers), Select]
        public readonly struct Select256<T> : IBlockedTernaryOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> c, SpanBlock256<T> dst)
                => SpanBlocks.zip(a,b,c,dst, Calcs.vselect<T>(w256));
        }
    }
}