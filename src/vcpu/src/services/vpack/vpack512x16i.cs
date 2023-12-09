//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    [MethodImpl(Inline), Op]
    public static Vector512<short> vpack512x16i(Vector512<int> x, Vector512<int> y)
        => v16i(Permute4x64(v64u(vpackss(x,y)), (byte)Perm4L.ACBD));
}