//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// (4x64w,4x64w) -> 8x32w
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vpack256x32u(Vector256<ulong> a, Vector256<ulong> b)
        => vconcat(vpack128x32u(a), vpack128x32u(b));
}
