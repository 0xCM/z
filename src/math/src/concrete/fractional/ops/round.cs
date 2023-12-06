//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    [MethodImpl(Inline), Op]
    public static Half round(Half src, int scale)
        => Half.Round(src, scale);

    [MethodImpl(Inline), Op]
    public static float round(float src, int scale)
        => MathF.Round(src, scale);

    [MethodImpl(Inline), Op]
    public static double round(double src, int scale)
        => Math.Round(src, scale);
}