//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;

    partial struct cpu
    {
        [MethodImpl(Inline), TestZ]
        public static bit testc(ulong a, ulong b)
            => TestC(vbroadcast(w128, a), vbroadcast(w128, b));

        [MethodImpl(Inline), TestZ]
        public static bit testc(ulong a)
            => TestC(vbroadcast(w128, a), vcpu.vones<ulong>(w128));
    }
}