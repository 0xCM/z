//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vpack512x16u(Vector512<uint> x, Vector512<uint> y)
        => v16u(Permute4x64(v64u(vpackus(x,y)), (byte)Perm4L.ACBD));
}