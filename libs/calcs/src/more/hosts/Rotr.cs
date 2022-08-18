
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
        [Closures(Integers), Rotr]
        public readonly struct VRotr128<T> : IShiftOp128D<T>, IShiftOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, byte offset)
                => gcpu.vrotr(x,offset);

            [MethodImpl(Inline)]
            public T Invoke(T a, byte offset)
                => gbits.rotr(a,offset);
        }

        [Closures(Integers), Rotr]
        public readonly struct VRotr256<T> : IShiftOp256D<T>, IShiftOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, byte count)
                => gcpu.vrotr(x,count);

            [MethodImpl(Inline)]
            public T Invoke(T a, byte count)
                => gbits.rotr(a,count);
        }

        [Closures(Integers), Rotr]
        public readonly struct Rotr128<T> : IBlockedUnaryImm8Op128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> a, [Imm] byte count, in SpanBlock128<T> dst)
                => ref zip(a, count, dst, Calcs.vrotr<T>(n128));
        }

        [Closures(Integers), Rotr]
        public readonly struct Rotr256<T> : IBlockedUnaryImm8Op256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> a, [Imm] byte count, in SpanBlock256<T> dst)
                => ref zip(a, count, dst, Calcs.vrotr<T>(n256));
        }
    }
}