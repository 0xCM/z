//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    /// <summary>
    /// 16x8i -> 16x32i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target width</param>
    /// <param name="t">A target cell type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vinflate512x32i(Vector128<sbyte> src)
        => Vector512.Create(vlo256x32i(src), vhi256x32i(src));

    /// <summary>
    /// 16x16i -> 16x32i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target vector width</param>
    /// <param name="t">A target type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vinflate512x32i(Vector256<short> src)
        => Vector512.Create(vlo256x32i(src), vhi256x32i(src));
}
