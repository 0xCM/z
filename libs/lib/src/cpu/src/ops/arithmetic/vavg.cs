//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     using System;
     using System.Runtime.CompilerServices;
     using System.Runtime.Intrinsics;

     using static System.Runtime.Intrinsics.X86.Sse2;
     using static System.Runtime.Intrinsics.X86.Avx2;
     using static Root;

     partial struct cpu
     {
          /// <summary>
          /// __m128i _mm_avg_epu8 (__m128i a, __m128i b) PAVGB xmm, xmm/m128
          /// </summary>
          /// <param name="a">The left vector</param>
          /// <param name="b">The right vector</param>
          [MethodImpl(Inline), Asm(ApiAsmClass.PAVGB)]
          public static Vector128<byte> vavg(Vector128<byte> a, Vector128<byte> b)
               => Average(a,b);

          /// <summary>
          /// __m128i _mm_avg_epu16 (__m128i a, __m128i b) PAVGW xmm, xmm/m128
          /// </summary>
          /// <param name="a">The left vector</param>
          /// <param name="b">The right vector</param>
          [MethodImpl(Inline), Asm(ApiAsmClass.PAVGW)]
          public static Vector128<ushort> vavg(Vector128<ushort> a, Vector128<ushort> b)
               => Average(a,b);

          /// <summary>
          /// __m256i _mm256_avg_epu8 (__m256i a, __m256i b) VPAVGB ymm, ymm, ymm/m256
          /// </summary>
          /// <param name="a">The left vector</param>
          /// <param name="b">The right vector</param>
          [MethodImpl(Inline), Asm(ApiAsmClass.VPAVGB)]
          public static Vector256<byte> vavg(Vector256<byte> a, Vector256<byte> b)
               => Average(a,b);

          /// <summary>
          ///  __m256i _mm256_avg_epu16 (__m256i a, __m256i b) VPAVGW ymm, ymm, ymm/m256
          /// </summary>
          /// <param name="a">The left vector</param>
          /// <param name="b">The right vector</param>
          [MethodImpl(Inline), Asm(ApiAsmClass.VPAVGW)]
          public static Vector256<ushort> vavg(Vector256<ushort> a, Vector256<ushort> b)
               => Average(a,b);
     }
}