//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    [MethodImpl(Inline), Min]
    public static Half min(Half a, Half b)
        => a < b ? a : b;

    [MethodImpl(Inline), Min]
    public static float min(float a, float b)
        => a < b ? a : b;

    [MethodImpl(Inline), Min]
    public static double min(double a, double b)
        => a < b ? a : b;
}