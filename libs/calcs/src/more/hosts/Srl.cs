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
    using static Numeric;

    partial struct CalcHosts
    {
        [Closures(Integers), Srl]
        public readonly struct VSrl128<T> : IShiftOp128D<T>, IShiftOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, byte count)
                => gcpu.vsrl(x,count);

            [MethodImpl(Inline)]
            public T Invoke(T a, byte count)
                => gmath.srl(a,count);
        }

        [Closures(Integers), Srl]
        public readonly struct VSrl256<T> : IShiftOp256D<T>, IShiftOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, byte count)
                => gcpu.vsrl(x,count);

            [MethodImpl(Inline)]
            public T Invoke(T a, byte count)
                => gmath.srl(a,count);
        }

        public readonly struct VSrlr128<T> : IBinaryOp128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> count)
                => gcpu.vsrl(x,count);

            [MethodImpl(Inline)]
            public T Invoke(T a, T count)
                => gmath.srl(a, force<T,byte>(count));
        }

        public readonly struct VSrlr256<T> : IBinaryOp256<T>
            where T : unmanaged
        {

            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, Vector256<T> count)
                => gcpu.vsrl(x,count);

            [MethodImpl(Inline)]
            public T InvokeScalar(T a, T offset)
                => gmath.srl(a, force<T,byte>(offset));
        }

        [Closures(Integers), Srl]
        public readonly struct Srl<T> : IUnaryImm8Op<T>, ISpanShift<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public T Invoke(T a, byte count)
                => gmath.srl(a, count);

            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> src, byte count, Span<T> dst)
                => gcalc.srl(src, count, dst);
        }

        [Closures(Integers), Srlv]
        public readonly struct Srlv<T> : IVarSpanShift<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Span<T> Invoke(ReadOnlySpan<T> src, ReadOnlySpan<byte> counts, Span<T> dst)
                => gcalc.srlv(src,counts,dst);
        }

        [Closures(Integers), Srl]
        public readonly struct Srl128<T> : IBlockedUnaryImm8Op128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, [Imm] byte count, in SpanBlock128<T> dst)
                => ref zip(a, count, dst, Calcs.vsrl<T>(n128));
        }

        [Closures(Integers), Srl]
        public readonly struct Srl256<T> : IBlockedUnaryImm8Op256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, [Imm] byte count, in SpanBlock256<T> dst)
                => ref zip(a, count, dst, Calcs.vsrl<T>(n256));
        }
    }
}