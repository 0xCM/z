//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    /// <summary>
    /// 8x16u -> 64u (a scalar)
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static ulong vpack64u(Vector128<ushort> src)
        => vgcpu.vcell64(vpackus(src, default), 0);

    /// <summary>
    /// 8x32u -> 64u (a scalar)
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static ulong vpack64u(Vector256<uint> src)
        => vpack64u(vpack128x16u(src));
}
