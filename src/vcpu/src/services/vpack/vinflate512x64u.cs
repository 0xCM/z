//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    /// <summary>
    /// 8x32u -> 8x64u
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vinflate512x64u(Vector256<uint> src)
        => Vector512.Create(vlo256x64u(src), vhi256x64u(src));

    /// <summary>
    /// 8x16x -> (4x64u,4x64u)
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="lo">The lo target</param>
    /// <param name="hi">The hi target</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vinflate512x64u(Vector128<ushort> src)
        => Vector512.Create(vcpu.vpmovzxwq(w256, src), vhi256x64u(src));
}
