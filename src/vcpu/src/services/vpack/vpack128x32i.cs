//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// 4x64w -> 4x32w
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vpack128x32i(Vector256<long> src)
        => vparts(w128i, (int)vcell(src, 0), (int)vcell(src, 1), (int)vcell(src, 2), (int)vcell(src, 3));
}
