//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the relative error between a one floating-point calculation and another
    /// </summary>
    /// <param name="lhs">The result of the first calculation</param>
    /// <param name="rhs">The result of the second calculation</param>
    [MethodImpl(Inline), Op]
    public static float relerr(float lhs, float rhs)
    {
        var err = dist(lhs,rhs)/lhs;
        return err.IsNaN() ? 0 : err;
    }

    /// <summary>
    /// Computes the relative error between a one floating-point calculation and another
    /// </summary>
    /// <param name="lhs">The result of the first calculation</param>
    /// <param name="rhs">The result of the second calculation</param>
    [MethodImpl(Inline), Op]
    public static double relerr(double lhs, double rhs)
    {
        var err = dist(lhs,rhs)/lhs;
        return err.IsNaN() ? 0 : err;
    }

    /// <summary>
    /// Impelements compensated floating-point summation
    /// </summary>
    /// <param name="src">The value to add to the total</param>
    /// <param name="delta">The last compensation amount</param>
    /// <param name="total">The running total</param>
    /// <remarks>See https://en.wikipedia.org/wiki/Kahan_summation_algorithm</remarks>
    [MethodImpl(Inline), Op]
    public static ref double fcsum(in double src, ref double delta, ref double total)
    {
        var y = src - delta;
        var t = total + y;
        delta = (t - total) - y;
        total = t;
        return ref total;
    }


    [MethodImpl(Inline), Op]
    public static Half sin(Half x)
        => Half.Sin(x);

    [MethodImpl(Inline), Op]
    public static float sin(float x)
        => MathF.Sin(x);

    [MethodImpl(Inline), Op]
    public static double sin(double x)
        => Math.Sin(x);

    [MethodImpl(Inline), Op]
    public static float cos(float x)
        => MathF.Cos(x);

    [MethodImpl(Inline), Op]
    public static double cos(double x)
        => Math.Cos(x);

    [MethodImpl(Inline), Op]
    public static float tan(float x)
        => MathF.Tan(x);

    [MethodImpl(Inline), Op]
    public static double tan(double x)
        => Math.Tan(x);

    [MethodImpl(Inline), Op]
    public static float asin(float x)
        => MathF.Asin(x);

    [MethodImpl(Inline), Op]
    public static double asin(double x)
        => Math.Asin(x);

    [MethodImpl(Inline), Op]
    public static float acos(float x)
        => MathF.Acos(x);

    [MethodImpl(Inline), Op]
    public static double acos(double x)
        => Math.Acos(x);

    [MethodImpl(Inline), Op]
    public static float atan(float x)
        => MathF.Atan(x);

    [MethodImpl(Inline), Op]
    public static double atan(double x)
        => Math.Atan(x);

    [MethodImpl(Inline), Op]
    public static float sinh(float x)
        => MathF.Sinh(x);

    [MethodImpl(Inline), Op]
    public static double sinh(double x)
        => Math.Sinh(x);

    [MethodImpl(Inline), Op]
    public static float cosh(float x)
        => MathF.Cosh(x);

    [MethodImpl(Inline), Op]
    public static double cosh(double x)
        => Math.Cosh(x);

    [MethodImpl(Inline), Op]
    public static float tanh(float x)
        => MathF.Tanh(x);

    [MethodImpl(Inline), Op]
    public static double tanh(double x)
        => Math.Tanh(x);

    [MethodImpl(Inline), Op]
    public static float asinh(float x)
        => MathF.Asinh(x);

    [MethodImpl(Inline), Op]
    public static double asinh(double x)
        => Math.Asinh(x);

    [MethodImpl(Inline), Op]
    public static float acosh(float x)
        => MathF.Acosh(x);

    [MethodImpl(Inline), Op]
    public static double acosh(double x)
        => Math.Acosh(x);

    [MethodImpl(Inline), Op]
    public static float atanh(float x)
        => MathF.Atanh(x);

    [MethodImpl(Inline), Op]
    public static double atanh(double x)
        => Math.Atanh(x);
}
