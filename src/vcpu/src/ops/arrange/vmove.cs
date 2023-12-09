//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class vcpu
{
    /// <summary>
    /// src[3] -> r/m16
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target register width</param>
    /// <param name="i">The source component index</param>
    /// <param name="j">THe target component index</param>
    [MethodImpl(Inline), Op]
    public static ushort vmove(Vector128<ushort> src, W16 w, N3 i, N0 j)
        => vlo16u(vshufflelo(src,Perm4L.DBCA));

    /// <summary>
    /// src[2] -> r/m16
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target register width</param>
    /// <param name="i">The source component index</param>
    /// <param name="j">THe target component index</param>
    [MethodImpl(Inline), Op]
    public static ushort vmove(Vector128<ushort> src, W16 w, N2 i, N0 j)
        => vlo16u(vshufflelo(src,Perm4L.CBDA));

    /// <summary>
    /// src[1] -> r/m16
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target register width</param>
    /// <param name="i">The source component index</param>
    /// <param name="j">THe target component index</param>
    [MethodImpl(Inline), Op]
    public static ushort vmove(Vector128<ushort> src, W16 w, N1 i, N0 j)
        => vlo16u(vshufflelo(src,Perm4L.BCDA));
}
