
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SFx;

    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(Integers), Bsrl]
        public readonly struct VBsrl128<T> : IShiftOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, byte count)
                => gcpu.vbsrl(x,count);
        }

        [Closures(Integers), Bsrl]
        public readonly struct VBsrl256<T> : IShiftOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, byte count)
                => gcpu.vbsrl(x,count);
        }

        [Closures(Integers), Bsrl]
        public readonly struct Bsrl128<T> : IBlockedUnaryImm8Op128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, [Imm] byte count, in SpanBlock128<T> dst)
                => ref zip(a, count, dst, Calcs.vbsrl<T>(n128));
        }

        [Closures(Integers), Bsrl]
        public readonly struct Bsrl256<T> : IBlockedUnaryImm8Op256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, [Imm] byte count, in SpanBlock256<T> dst)
                => ref zip(a, count, dst, Calcs.vbsrl<T>(n256));
        }
    }
}