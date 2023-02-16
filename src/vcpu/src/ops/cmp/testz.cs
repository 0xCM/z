//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;

    partial class vcpu
    {
        [MethodImpl(Inline), TestZ]
        public static bit testz(ulong a, ulong b)
            => TestZ(vbroadcast(w128, a), vbroadcast(w128, b));
   }
}