//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct vpack
{
    /// <summary>
    /// VPMOVZXBQ ymm, m32
    /// 4x8u -> 4x64i
    /// Projects four unsigned 8-bit integers onto 4 signed 64-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    /// <param name="i">Signals a sign extension</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<long> vinflate4x64u(in byte src)
        => ConvertToVector256Int64(gptr(src));

    /// <summary>
    /// 4x32w -> 4x64w
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vinflate4x64i(Vector128<int> src)
        => ConvertToVector256Int64(src);        
}