//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(Integers), Sll]
        public readonly struct VSll128<T> : IShiftOp128D<T>, IShiftOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, byte count)
                => vgcpu.vsll(x,count);

            [MethodImpl(Inline)]
            public T Invoke(T a, byte count)
                => gmath.sll(a,count);
        }

        [Closures(Integers), Sll]
        public readonly struct VSll256<T> : IShiftOp256D<T>, IShiftOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, byte count)
                => vgcpu.vsll(x,count);

            [MethodImpl(Inline)]
            public T Invoke(T a, byte count)
                => gmath.sll(a,count);
        }


        [Closures(Integers), Sll]
        public readonly struct Sll<T> : IUnaryImm8Op<T>, ISpanShift<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public T Invoke(T a, byte offset)
                => gmath.sll(a, offset);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> src, byte count, Span<T> dst)
                => Calcs.sll(src,count,dst);
        }

        [Closures(Integers), Sll]
        public readonly struct Sll128<T> : IBlockedUnaryImm8Op128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock128<T> Invoke(SpanBlock128<T> a, [Imm] byte count, SpanBlock128<T> dst)
                => SpanBlocks.zip(a, count, dst, Calcs.vsll<T>(n128));
        }

        [Closures(Integers), Sll]
        public readonly struct Sll256<T> : IBlockedUnaryImm8Op256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public SpanBlock256<T> Invoke(SpanBlock256<T> a, [Imm] byte count, SpanBlock256<T> dst)
                => SpanBlocks.zip(a, count, dst, Calcs.vsll<T>(n256));
        }
    }
}