//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


partial class vcpu
{
    /// <summary>
    /// Transposes a 4x4 matrix of unsigned integers, adapted from MSVC intrinsic headers
    /// </summary>
    /// <param name="row0">The first row</param>
    /// <param name="row1">The second row</param>
    /// <param name="row2">The third row</param>
    /// <param name="row3">The fourth row</param>
    [MethodImpl(Inline), Op]
    public static void vtranspose(ref Vector128<uint> row0, ref Vector128<uint> row1, ref Vector128<uint> row2, ref Vector128<uint> row3)
    {
        var tmp0 = Shuffle(v32f(row0), v32f(row1), 0x44);
        var tmp2 = Shuffle(v32f(row0), v32f(row1), 0xEE);
        var tmp1 = Shuffle(v32f(row2), v32f(row3), 0x44);
        var tmp3 = Shuffle(v32f(row2),v32f(row3), 0xEE);
        row0 = v32u(Shuffle(tmp0, tmp1, 0x88));
        row1 = v32u(Shuffle(tmp0, tmp1, 0xDD));
        row2 = v32u(Shuffle(tmp2,tmp3, 0x88));
        row3 = v32u(Shuffle(tmp2, tmp3, 0xDD));
    }
}
