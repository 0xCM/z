//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial struct vpack
{
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vinflate512x16u(in byte src)
    {
        var lo = vcpu.vpmovzxbw(vload(w128, src));
        var hi = vcpu.vpmovzxbw(vload(w128, add(src, 16)));
        return vgcpu.vconcat(lo,hi);
    }

    /// <summary>
    /// 32x8u -> (16x16u, 16x16u)
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vinflate512x16u(Vector256<byte> src)
        => Vector512.Create(vlo256x16u(src), vhi256x16u(src));
}
