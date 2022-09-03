//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static SFx;

    partial struct CalcHosts
    {
        [Closures(Integers), Sll]
        public readonly struct VSll128<T> : IShiftOp128D<T>, IShiftOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, byte count)
                => gcpu.vsll(x,count);

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
                => gcpu.vsll(x,count);

            [MethodImpl(Inline)]
            public T Invoke(T a, byte count)
                => gmath.sll(a,count);
        }

        public readonly struct VSllr128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> offsets)
                => gcpu.vsll(x,offsets);

            [MethodImpl(Inline)]
            public T Invoke(T a, T offset)
                => gmath.sll(a, Numeric.force<T,byte>(offset));
        }

        public readonly struct VSllr256<T> : IBinaryOp256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> offset)
                => gcpu.vsll(x,offset);

            [MethodImpl(Inline)]
            public T Invoke(T a, T offset)
                => gmath.sll(a, Numeric.force<T,byte>(offset));
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

        [Closures(Integers), Sllv]
        public readonly struct Sllv<T> : IVarSpanShift<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> src, ReadOnlySpan<byte> counts, Span<T> dst)
                => Calcs.sllv(src,counts,dst);
        }

        [Closures(Integers), Sll]
        public readonly struct Sll128<T> : IBlockedUnaryImm8Op128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, [Imm] byte count, in SpanBlock128<T> dst)
                => ref zip(a, count, dst, Calcs.vsll<T>(n128));
        }

        [Closures(Integers), Sll]
        public readonly struct Sll256<T> : IBlockedUnaryImm8Op256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, [Imm] byte count, in SpanBlock256<T> dst)
                => ref zip(a, count, dst, Calcs.vsll<T>(n256));
        }
    }
}