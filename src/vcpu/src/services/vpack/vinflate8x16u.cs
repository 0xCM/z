//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial struct vpack
{
    /// <summary>
    /// VPMOVZXWQ ymm, m64
    /// 8x16u -> 8x64u
    /// Projects 8 unsigned 16-bit integers onto 8 unsigned 64-bit integers
    /// </summary>
    /// <param name="src">The blocked memory source</param>
    /// <param name="lo">The lower target</param>
    /// <param name="hi">The upper target</param>
    [MethodImpl(Inline), Op]
    public static unsafe void vinflate8x16u(in ushort src, out Vector256<ulong> lo, out Vector256<ulong> hi)
    {
        lo = v64u(ConvertToVector256Int64(gptr(src)));
        hi = v64u(ConvertToVector256Int64(gptr(src,4)));
    }

    /// <summary>
    /// __m256i _mm256_cvtepu16_epi32 (__m128i a) VPMOVZXWD ymm, xmm
    /// 8x16u -> 8x32i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vinflate8x16u(Vector128<ushort> src, out Vector256<int> dst)
        => dst = ConvertToVector256Int32(src);

    /// <summary>
    /// VPMOVZXWD ymm, m128
    /// 8x16u -> 8x32u
    /// Projects 8 unsigned 16-bit integers onto 8 unsigned 32-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<uint> vinflate8x16u(in ushort src, out Vector256<uint> dst)
        => dst = v32u(ConvertToVector256Int32(gptr(src)));

    /// <summary>
    /// __m256i _mm256_cvtepu16_epi32 (__m128i a) VPMOVZXWD ymm, xmm
    /// 8x16u -> 8x32u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="w">The target vector width</param>
    /// <param name="t">A target component type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vinflate8x16u(Vector128<ushort> src, out Vector256<uint> dst)
        => dst = v32u(ConvertToVector256Int32(src));
}
