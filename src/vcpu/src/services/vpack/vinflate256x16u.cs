//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// __m256i _mm256_cvtepu8_epi16 (__m128i a)
    /// VPMOVZXBW ymm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <param name="w"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vinflate256x16u(in byte src)
        => v16u(ConvertToVector256Int16(vload(w128, src)));
        
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vinflatelo256x16u(Vector256<byte> src)
        => vpmovzxbw(w256, vlo(src));

    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vinflatehi256x16u(Vector256<byte> src)
        => vpmovzxbw(w256, vhi(src));
}
