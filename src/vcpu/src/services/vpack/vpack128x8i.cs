//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// 16x16i -> 16x8i
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vpack128x8i(Vector256<short> src)
        => vpackss(vlo(src), vhi(src));
}
