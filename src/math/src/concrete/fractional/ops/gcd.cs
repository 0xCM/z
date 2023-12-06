//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    [MethodImpl(Inline), Op]
    public static Half gcd(Half a, Half b)
    {
        var x = abs(a);
        var y = abs(b);
        while (y != Half.Zero)
        {
            var rem = mod(x,y);
            x = y;
            y = rem;
        }

        return x;
    }

    [MethodImpl(Inline), Op]
    public static float gcd(float a, float b)
    {
        var x = abs(a);
        var y = abs(b);
        while (y != 0)
        {
            var rem = mod(x,y);
            x = y;
            y = rem;
        }

        return x;
    }

    [MethodImpl(Inline), Op]
    public static double gcd(double a, double b)
    {
        var x = abs(a);
        var y = abs(b);
        while (y != 0)
        {
            var rem = mod(x,y);
            x = y;
            y = rem;
        }

        return x;
    }
}