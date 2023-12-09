//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vpack512x8i(Vector512<short> a, Vector512<short> b)
        => vperm4x64(vpackss(a,b), Perm4L.ACBD);
}