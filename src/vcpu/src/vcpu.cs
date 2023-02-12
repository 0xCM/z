//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static sys;

    [ApiHost,Free]
    public partial class vgcpu
    {
        const NumericKind Closure = UnsignedInts;

    }

    [ApiHost,Free]
    public partial class vcpu
    {
        const NumericKind Closure = UnsignedInts;

        static Vector256<ulong> Vector256u64
        {
            [MethodImpl(Inline), Rotr]
            get => vbroadcast(w256,64ul);
        }

        static Vector256<uint> Vector256u32
        {
            [MethodImpl(Inline), Rotr]
            get => vbroadcast(w256, 32u);
        }

        static Vector128<ulong> Vector128u64
        {
            [MethodImpl(Inline), Rotr]
            get => vbroadcast(w128, 64ul);
        }

        static Vector128<uint> Vector128u32
        {
            [MethodImpl(Inline), Rotr]
            get => vbroadcast(w128,32u);
        }

    }
}