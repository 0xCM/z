//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// (8x32w,8x32w) -> 16x16w
    /// </summary>
    /// <param name="x">The first source vector</param>
    /// <param name="y">The second source vector</param>
    /// <remarks>The vpackus intrinsic emits a vector in the following form:
    /// [0, 1, 2, 3, 8, 9, 10, 11, 4, 5, 6, 7, 12, 13, 14, 15]
    /// To make use of the result, it must be permuted to a more reasonable order,
    /// [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
    /// </remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vpack256x16u(Vector256<uint> x, Vector256<uint> y)
        => v16u(Permute4x64(v64u(vpackus(x,y)), (byte)Perm4L.ACBD));
}
