//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System.Runtime.Intrinsics.X86;

global using static System.Runtime.Intrinsics.X86.Sse;
global using static System.Runtime.Intrinsics.X86.Sse.X64;
global using static System.Runtime.Intrinsics.X86.Fma;
global using static System.Runtime.Intrinsics.X86.Fma.X64;
global using static System.Runtime.Intrinsics.X86.Aes;
global using static System.Runtime.Intrinsics.X86.Avx;
global using static System.Runtime.Intrinsics.X86.Avx.X64;
global using static System.Runtime.Intrinsics.X86.Avx2;
global using static System.Runtime.Intrinsics.X86.Avx2.X64;
global using static System.Runtime.Intrinsics.X86.Sse2;
global using static System.Runtime.Intrinsics.X86.Sse2.X64;
global using static System.Runtime.Intrinsics.X86.Ssse3;
global using static System.Runtime.Intrinsics.X86.Ssse3.X64;
global using static System.Runtime.Intrinsics.X86.Sse41;
global using static System.Runtime.Intrinsics.X86.Sse41.X64;
global using static System.Runtime.Intrinsics.X86.Sse42;
global using static System.Runtime.Intrinsics.X86.Sse42.X64;
global using static System.Runtime.Intrinsics.X86.Sse3;
global using static System.Runtime.Intrinsics.X86.Sse3.X64;
global using static System.Runtime.Intrinsics.X86.Pclmulqdq;
global using static System.Runtime.Intrinsics.X86.Pclmulqdq.X64;

global using static System.Runtime.Intrinsics.X86.Bmi2;
global using static System.Runtime.Intrinsics.X86.Bmi2.X64;

global using static System.Runtime.Intrinsics.X86.Avx512F;
global using static System.Runtime.Intrinsics.X86.Avx512F.VL;
global using static System.Runtime.Intrinsics.X86.Avx512F.X64;

global using static System.Runtime.Intrinsics.X86.Avx512BW;
global using static System.Runtime.Intrinsics.X86.Avx512BW.VL;
global using static System.Runtime.Intrinsics.X86.Avx512BW.X64;

global using static System.Runtime.Intrinsics.X86.Avx512CD;
global using static System.Runtime.Intrinsics.X86.Avx512CD.X64;
global using static System.Runtime.Intrinsics.X86.Avx512CD.VL;

global using static System.Runtime.Intrinsics.X86.Avx512DQ;
global using static System.Runtime.Intrinsics.X86.Avx512DQ.X64;
global using static System.Runtime.Intrinsics.X86.Avx512DQ.VL;


[assembly: PartId("vcpu")]
namespace Z0.Parts
{
    public sealed class VCpu : Part<VCpu>
    {
    }
}
