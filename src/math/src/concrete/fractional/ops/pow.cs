//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    [MethodImpl(Inline), Op]
    public static Half pow(Half src, Half exp)
        => Half.Pow(src,exp);

    [MethodImpl(Inline), Op]
    public static float pow(float src, float exp)
        => MathF.Pow(src,exp);

    [MethodImpl(Inline), Op]
    public static double pow(double src, double exp)
        => Math.Pow(src,exp);
}