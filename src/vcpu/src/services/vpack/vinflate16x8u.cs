//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct vpack
{
    /// <summary>
    /// VPMOVZXBW ymm, m128
    /// 16x8u -> 16x16u
    /// Projects 16 unsigned 8-bit integers onto 16 unsigned 16-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ushort> vinflate16x8u(in byte src)
        => ConvertToVector256Int16(gptr(src)).AsUInt16();
}
