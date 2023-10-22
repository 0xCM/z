//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    ///  __m128i _mm_packus_epi16 (__m128i a, __m128i b) PACKUSWB xmm, xmm/m128
    /// (8x16w,8x16w) -> 16x8w
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vpackus(Vector128<short> x, Vector128<short> y)
        => PackUnsignedSaturate(x,y);

    /// <summary>
    ///__m128i _mm_packus_epi32 (__m128i a, __m128i b) PACKUSDW xmm, xmm/m128
    /// (4x32w,4x32w) -> 8x16w
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vpackus(Vector128<int> x, Vector128<int> y)
        => PackUnsignedSaturate(x,y);

    /// <summary>
    /// __m256i _mm256_packus_epi16 (__m256i a, __m256i b) VPACKUSWB ymm, ymm, ymm/m256
    /// (16x8w,16x8w) -> 32x8w
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vpackus(Vector256<short> x, Vector256<short> y)
        => PackUnsignedSaturate(x,y);

    /// <summary>
    /// __m256i _mm256_packus_epi32 (__m256i a, __m256i b) VPACKUSDW ymm, ymm, ymm/m256
    /// (8x32w,8x32w) -> 16x16w
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vpackus(Vector256<int> x, Vector256<int> y)
        => PackUnsignedSaturate(x,y);

    /// <summary>
    ///  __m128i _mm_packus_epi16 (__m128i a, __m128i b) PACKUSWB xmm, xmm/m128
    /// (8x16w,8x16w) -> 16x8w
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <remarks>See https://stackoverflow.com/questions/12118910/converting-float-vector-to-16-bit-int-without-saturating</remarks>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vpackus(Vector128<ushort> x, Vector128<ushort> y)
    {
        var mask = vbroadcast(n128, (ushort)(byte.MaxValue));
        var v1 = v16i(vand(x,mask));
        var v2 = v16i(vand(y,mask));
        return PackUnsignedSaturate(v1,v2);
    }

    /// <summary>
    ///__m128i _mm_packus_epi32 (__m128i a, __m128i b) PACKUSDW xmm, xmm/m128
    /// (4x32w,4x32w) -> 8x16w
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <remarks>See https://stackoverflow.com/questions/12118910/converting-float-vector-to-16-bit-int-without-saturating</remarks>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vpackus(Vector128<uint> x, Vector128<uint> y)
    {
        var mask = vcpu.vbroadcast(n128, (uint)(ushort.MaxValue));
        var z0 = v32i(vand(x,mask));
        var z1 = v32i(vand(y,mask));
        return PackUnsignedSaturate(z0, z1);
    }

    /// <summary>
    /// __m256i _mm256_packus_epi16 (__m256i a, __m256i b) VPACKUSWB ymm, ymm, ymm/m256
    /// (16x8w,16x8w) -> 32x8w
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vpackus(Vector256<ushort> x, Vector256<ushort> y)
    {
        var mask = vcpu.vbroadcast(n256, (ushort)(byte.MaxValue));
        var v1 = v16i(vand(x,mask));
        var v2 = v16i(vand(y,mask));
        return PackUnsignedSaturate(v1,v2);
    }

    /// <summary>
    /// __m256i _mm256_packus_epi32 (__m256i a, __m256i b) VPACKUSDW ymm, ymm, ymm/m256
    /// (8x32w,8x32w) -> 16x16w
    /// [0, 1, 2, 3, 8, 9, 10, 11, 4, 5, 6, 7, 12, 13, 14, 15]
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vpackus(Vector256<uint> x, Vector256<uint> y)
    {
        var mask = vgcpu.vbroadcast<uint>(n256, (uint)(ushort.MaxValue));
        var z0 = v32i(vand(x,mask));
        var z1 = v32i(vand(y,mask));
        return PackUnsignedSaturate(z0, z1);
    }
}
