//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the arithmetic product of the operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Mul]
    public static float mul(float a, float b)
        => a * b;

    /// <summary>
    /// Computes the arithmetic product of the operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Mul]
    public static double mul(double a, double b)
        => a * b;

    /// <summary>
    /// Computes z := (a*b) mod m
    /// </summary>
    /// <param name="a">The first factor</param>
    /// <param name="b">The second factor</param>
    /// <param name="m">The modulus</param>
    [MethodImpl(Inline), ModMul]
    public static float modmul(float a, float b, float m)
        => (a*b) % m;

    /// <summary>
    /// Computes z := (a*b) mod m
    /// </summary>
    /// <param name="a">The first factor</param>
    /// <param name="b">The second factor</param>
    /// <param name="m">The modulus</param>
    [MethodImpl(Inline), ModMul]
    public static double modmul(double a, double b, double m)
        => (a*b) % m;

    /// <summary>
    /// Computes dst = (div(a,b), mod(a,b))
    /// </summary>
    /// <param name="a">The dividend</param>
    /// <param name="b">The divisor</param>
    [MethodImpl(Inline), DivMod]
    public static ConstPair<float> divmod(float a, float b)
        => (div(a,b), mod(a,b));

    /// <summary>
    /// Computes dst = (div(a,b), mod(a,b))
    /// </summary>
    /// <param name="a">The dividend</param>
    /// <param name="b">The divisor</param>
    [MethodImpl(Inline), DivMod]
    public static ConstPair<double> divmod(double a, double b)
        => (div(a,b), mod(a,b));

    /// <summary>
    /// Computes the smallest integral value greater than or equal to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static float ceil(float src)
        => MathF.Ceiling(src);

    /// <summary>
    /// Computes the smallest integral value greater than or equal to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static double ceil(double src)
        => Math.Ceiling(src);

    /// <summary>
    /// Clamps the source value to an inclusive maximum
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="max">The maximum value</param>
    [MethodImpl(Inline), Clamp]
    public static float clamp(float src, float max)
        => src > max ? max : src;

    /// <summary>
    /// Clamps the source value to an inclusive maximum
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="max">The maximum value</param>
    [MethodImpl(Inline), Clamp]
    public static double clamp(double src, double max)
        => src > max ? max : src;

    [MethodImpl(Inline), Divides]
    public static bool divides(float a, float b)
        => b % a == 0;

    [MethodImpl(Inline), Divides]
    public static bool divides(double a, double b)
        => b % a == 0;

    [MethodImpl(Inline), Fma]
    public static float fma(float x, float y, float z)
        => MathF.FusedMultiplyAdd(x,y,z);

    [MethodImpl(Inline), Fma]
    public static double fma(double x, double y, double z)
        => Math.FusedMultiplyAdd(x, y, z);

    [MethodImpl(Inline), Op]
    public static Sign sign(float src)
        => (SignKind)MathF.Sign(src);

    [MethodImpl(Inline), Op]
    public static Sign sign(double src)
        => (SignKind)Math.Sign(src);

    [MethodImpl(Inline), Square]
    public static float square(float src)
        => mul(src,src);

    [MethodImpl(Inline), Square]
    public static double square(double src)
        => mul(src,src);
}
