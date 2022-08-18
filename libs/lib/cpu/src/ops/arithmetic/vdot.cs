//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Sse;

    partial struct cpu
    {
        [MethodImpl(Inline), Dot]
        public static long vdot(Vector256<int> x, Vector256<int> y)
        {
            var product = Multiply(x,y);
            var sum = vadd(vlo(product), vhi(product));
            return sum.Cell(0) + sum.Cell(1);
        }

        [MethodImpl(Inline), Dot]
        public static ulong vdot(Vector256<uint> x, Vector256<uint> y)
        {
            var product = Multiply(x,y);
            var sum = vadd(vlo(product), vhi(product));
            return sum.Cell(0) + sum.Cell(1);
        }
    }
}