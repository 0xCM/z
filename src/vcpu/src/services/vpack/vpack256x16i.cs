//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// (8x32i,8x32i) -> 16x16i
    /// <param name="x">The first source vector</param>
    /// <param name="y">The second source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vpack256x16i(Vector256<int> x, Vector256<int> y)
        => v16i(Permute4x64(v64i(vpackss(x,y)), (byte)Perm4L.ACBD));
}
