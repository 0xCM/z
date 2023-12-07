//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class vcpu
{
    /// <summary>
    /// Replicates a 16-bit source over a 32-bit target
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="w">The target width</param>
    [MethodImpl(Inline), Op]
    public static uint broadcast(ushort src, N32 w)
        => vbroadcast(w128, src).AsUInt32().GetElement(0);

    /// <summary>
    /// Replicates an 8-bit source over a 64-bit target
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="w">The target width</param>
    [MethodImpl(Inline), Op]
    public static ulong broadcast(byte src, N64 w)
        => vbroadcast(w128, src).AsUInt64().GetElement(0);

    /// <summary>
    /// Replicates a 16-bit source over a 64-bit target
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="w">The target width</param>
    [MethodImpl(Inline), Op]
    public static ulong broadcast(ushort src, N64 w)
        => vbroadcast(w128, src).AsUInt64().GetElement(0);

    /// <summary>
    /// Replicates a 32-bit source over a 64-bit target
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="w">The target width</param>
    [MethodImpl(Inline), Op]
    public static ulong broadcast(uint src, N64 w)
        => vbroadcast(w128, src).AsUInt64().GetElement(0);

    /// <summary>
    /// Creates a target vector where each component is initialized with the same value
    /// __m128i _mm_broadcastb_epi8 (__m128i a) VPBROADCASTB xmm, m8
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<sbyte> vbroadcast(W128 w, sbyte src)
        => BroadcastScalarToVector128(&src);

    /// <summary>
    ///  __m128i _mm_broadcastb_epi8 (__m128i a) VPBROADCASTB xmm, m8
    /// Creates a target vector where each component is initialized with the same value
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<byte> vbroadcast(W128 w, byte src)
        => BroadcastScalarToVector128(&src);

    /// <summary>
    /// Creates a target vector where each component is initialized with the same value
    ///  __m128i _mm_broadcastw_epi16 (__m128i a) VPBROADCASTW xmm, m16
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<short> vbroadcast(W128 w, short src)
        => BroadcastScalarToVector128(&src);

    /// <summary>
    /// Creates a target vector where each component is initialized with the same value
    /// __m128i _mm_broadcastw_epi16 (__m128i a) VPBROADCASTW xmm, m16
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<ushort> vbroadcast(W128 w, ushort src)
        => BroadcastScalarToVector128(&src);

    /// <summary>
    /// Creates a target vector where each component is initialized with the same value
    /// __m128i _mm_broadcastd_epi32 (__m128i a) VPBROADCASTD xmm, m32
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<int> vbroadcast(W128 w, int src)
        => BroadcastScalarToVector128(&src);

    /// <summary>
    /// Creates a target vector where each component is initialized with the same value
    /// __m128i _mm_broadcastd_epi32 (__m128i a) VPBROADCASTD xmm, m32
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<uint> vbroadcast(W128 w, uint src)
        => BroadcastScalarToVector128(&src);

    /// <summary>
    /// Creates a target vector where each component is initialized with the same value
    /// __m128i _mm_broadcastq_epi64 (__m128i a) VPBROADCASTQ xmm, m64
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<long> vbroadcast(W128 w, long src)
        => BroadcastScalarToVector128(&src);

    /// <summary>
    /// Creates a target vector where each component is initialized with the same value
    /// __m128i _mm_broadcastq_epi64 (__m128i a)
    /// VPBROADCASTQ xmm, m64
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<ulong> vbroadcast(W128 w, ulong src)
        => BroadcastScalarToVector128(&src);

    /// <summary>
    /// __m256i _mm256_broadcastb_epi8 (__m128i a)
    /// VPBROADCASTB ymm, m8
    /// Creates a target vector where each component is initialized with the same value
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<sbyte> vbroadcast(W256 w, sbyte src)
        => BroadcastScalarToVector256(&src);

    /// <summary>
    /// __m256i _mm256_broadcastb_epi8 (__m128i a) VPBROADCASTB ymm, m8
    /// Creates a target vector where each component is initialized with the same value
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<byte> vbroadcast(W256 w, byte src)
        => BroadcastScalarToVector256(&src);

    /// <summary>
    ///  __m256i _mm256_broadcastw_epi16 (__m128i a) VPBROADCASTW ymm, m16
    /// Creates a target vector where each component is initialized with the same value
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<short> vbroadcast(W256 w, short src)
        => BroadcastScalarToVector256(&src);

    /// <summary>
    ///  __m256i _mm256_broadcastw_epi16 (__m128i a) VPBROADCASTW ymm, m16
    /// Creates a target vector where each component is initialized with the same value
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ushort> vbroadcast(W256 w, ushort src)
        => BroadcastScalarToVector256(&src);

    /// <summary>
    /// __m256i _mm256_broadcastd_epi32 (__m128i a) VPBROADCASTD ymm, m32
    /// Creates a target vector where each component is initialized with the same value
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<int> vbroadcast(W256 w, int src)
        => BroadcastScalarToVector256(&src);

    /// <summary>
    /// __m256i _mm256_broadcastd_epi32 (__m128i a) VPBROADCASTD ymm, m32
    /// Creates a target vector where each component is initialized with the same value
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<uint> vbroadcast(W256 w, uint src)
        => BroadcastScalarToVector256(&src);

    /// <summary>
    /// __m256i _mm256_broadcastq_epi64 (__m128i a) VPBROADCASTQ ymm, m64
    /// Creates a target vector where each component is initialized with the same value
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<long> vbroadcast(W256 w, long src)
        => BroadcastScalarToVector256(&src);

    /// <summary>
    ///  __m256i _mm256_broadcastq_epi64
    ///  (__m128i a) VPBROADCASTQ ymm, m64
    /// Creates a target vector where each component is initialized with the same value
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ulong> vbroadcast(W256 w, ulong src)
        => BroadcastScalarToVector256(&src);

    /// <summary>
    /// __m512i _mm512_broadcastb_epi8 (__m128i a)
    /// VPBROADCASTB zmm1 {k1}{z}, xmm2/m8
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<sbyte> vbroadcast(W512 w, sbyte src)
        => BroadcastScalarToVector512(vbroadcast(w128, src));
        
    /// <summary>
    /// __m512i _mm512_broadcastb_epi8 (__m128i a)
    /// VPBROADCASTB zmm1 {k1}{z}, xmm2/m8
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<byte> vbroadcast(W512 w, byte src)
        => BroadcastScalarToVector512(vbroadcast(w128, src));

    /// <summary>
    /// __m512i _mm512_broadcastw_epi16 (__m128i a)
    /// VPBROADCASTW zmm1 {k1}{z}, xmm2/m16
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<short> vbroadcast(W512 w, short src)
        => BroadcastScalarToVector512(vbroadcast(w128, src));

    /// <summary>
    /// __m512i _mm512_broadcastw_epi16 (__m128i a)
    /// VPBROADCASTW zmm1 {k1}{z}, xmm2/m16
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<ushort> vbroadcast(W512 w, ushort src)
        => BroadcastScalarToVector512(vbroadcast(w128, src));

    /// <summary>
    /// __m512i _mm512_broadcastd_epi32 (__m128i a)
    /// VPBROADCASTD zmm1 {k1}{z}, xmm2/m32
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<int> vbroadcast(W512 w, int src)
        => BroadcastScalarToVector512(vbroadcast(w128, src));

    /// <summary>
    /// __m512i _mm512_broadcastd_epi32 (__m128i a)
    /// VPBROADCASTD zmm1 {k1}{z}, xmm2/m32
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<uint> vbroadcast(W512 w, uint src)
        => BroadcastScalarToVector512(vbroadcast(w128, src));

    /// <summary>
    /// Broadcast the source value to all target elements
    /// __m512i _mm512_broadcastq_epi64 (__m128i a)
    /// VPBROADCASTQ zmm1 {k1}{z}, xmm2/m64
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<long> vbroadcast(W512 w, long src)
        => BroadcastScalarToVector512(vbroadcast(w128,src));

    /// <summary>
    /// Broadcast the source value to all target elements
    /// __m512i _mm512_broadcastq_epi64 (__m128i a)
    /// VPBROADCASTQ zmm1 {k1}{z}, xmm2/m64
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<ulong> vbroadcast(W512 w, ulong src)
        => BroadcastScalarToVector512(vbroadcast(w128,src));
}
