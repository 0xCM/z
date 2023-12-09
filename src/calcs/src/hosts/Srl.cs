//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
                => vgcpu.vsrl(x,count);

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
                => vgcpu.vsrl(x,count);

            [MethodImpl(Inline)]
            public T Invoke(T a, byte count)
                => gmath.srl(a,count);
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

    }
}