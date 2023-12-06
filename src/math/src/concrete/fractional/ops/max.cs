//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    [MethodImpl(Inline), Max]
    public static Half max(Half a, Half b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static float max(float a, float b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static double max(double a, double b)
        => a > b ? a : b;
}