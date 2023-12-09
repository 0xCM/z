//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vpack512x8u(Vector512<ushort> a, Vector512<ushort> b)
        => vperm4x64(vpackus(a,b), Perm4L.ACBD);
}