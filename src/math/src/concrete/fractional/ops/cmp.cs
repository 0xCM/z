//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class fmath
{
    public static ReadOnlySpan<bool> cmp(Span<float> a, Span<float> b, FpCmpMode kind)
    {
        var count =  sys.min(a.Length,b.Length);
        var dst = span<bool>(count);
        for(var i = 0; i<count; i++)
            seek(dst,i) = fmath.cmp(a[i], b[i], kind);
        return dst;
    }

    public static ReadOnlySpan<bool> cmp(Span<double> a, Span<double> b, FpCmpMode kind)
    {
        var count = sys.min(a.Length,b.Length);
        var dst = span<bool>(count);
        for(var i = 0; i< count; i++)
            seek(dst,i) = fmath.cmp(a[i], b[i], kind);
        return dst;
    }

    /// <summary>
    /// Returns true if the source value is greater than zero, false otherwise
    /// </summary>
    /// <param name="a">The value to inspect</param>
    [MethodImpl(Inline), Positive]
    public static bit positive(float a)
        => a > 0;

    /// <summary>
    /// Returns true if the source value is greater than zero, false otherwise
    /// </summary>
    /// <param name="a">The value to inspect</param>
    [MethodImpl(Inline), Positive]
    public static bit positive(double a)
        => a > 0;

    /// <summary>
    /// Returns true if the source value is less than zero, false otherwise
    /// </summary>
    /// <param name="x">The value to inspect</param>
    [MethodImpl(Inline), Negative]
    public static bit negative(float x)
        => x < 0;

    /// <summary>
    /// Returns true if the source value is less than zero, false otherwise
    /// </summary>
    /// <param name="x">The value to inspect</param>
    [MethodImpl(Inline), Negative]
    public static bit negative(double x)
        => x < 0;

    /// <summary>
    /// Compares two operands via their <see cref='IComparable'> implementations
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Eq]
    public static int cmp(float a, float b)
        => a.CompareTo(b);

    /// <summary>
    /// Compares two operands via their <see cref='IComparable'> implementations
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Eq]
    public static int cmp(double a, double b)
        => a.CompareTo(b);

    [MethodImpl(Inline), Eq]
    public static bit eq(Half a, Half b)
        => a == b;

    [MethodImpl(Inline), Eq]
    public static bit eq(float a, float b)
        => a == b;

    [MethodImpl(Inline), Eq]
    public static bit eq(double a, double b)
        => a == b;

    [MethodImpl(Inline), Neq]
    public static bit neq(float a, float b)
        => a != b;

    [MethodImpl(Inline), Neq]
    public static bit neq(double a, double b)
        => a != b;

    [MethodImpl(Inline), Gt]
    public static bit gt(float a, float b)
        => a > b;

    [MethodImpl(Inline), Gt]
    public static bit gt(double a, double b)
        => a > b;

    [MethodImpl(Inline), GtEq]
    public static bit gteq(float a, float b)
        => a >= b;

    [MethodImpl(Inline), GtEq]
    public static bit gteq(double a, double b)
        => a >= b;

    [MethodImpl(Inline), Lt]
    public static bit lt(float lhs, float rhs)
        => lhs < rhs;

    [MethodImpl(Inline), Lt]
    public static bit lt(double lhs, double rhs)
        => lhs < rhs;

    [MethodImpl(Inline), LtEq]
    public static bit lteq(float lhs, float rhs)
        => lhs <= rhs;

    [MethodImpl(Inline), LtEq]
    public static bit lteq(double lhs, double rhs)
        => lhs <= rhs;

    [MethodImpl(Inline), Nonz]
    public static bit nonz(float src)
        => src != 0;

    [MethodImpl(Inline), Nonz]
    public static bit nonz(double src)
        => src != 0;

    [MethodImpl(Inline), Op]
    public static float nonz(float src, float alt)
        => src != 0 ? alt : src;

    [MethodImpl(Inline), Op]
    public static double nonz(double src, double alt)
        => src != 0 ? alt : src;

    [MethodImpl(Inline), Op]
    public static double width(float lhs, float rhs)
        => abs((double)rhs - (double)lhs);

    [MethodImpl(Inline), Op]
    public static double width(double lhs, double rhs)
        => abs(rhs - lhs);

    [MethodImpl(Inline), Op]
    public static bit within(float a, float b, float delta)
        => a > b ? a - b <= delta
            : b - a <= delta;

    [MethodImpl(Inline), Op]
    public static bit within(double a, double b, double delta)
        => a > b ? a - b <= delta
            : b - a <= delta;

    /// <summary>
    /// Returns true if the the test value lies in the closed interval formed by lower and upper bounds
    /// </summary>
    /// <param name="x">The test value</param>
    /// <param name="a">The lower bound</param>
    /// <param name="b">The upper bound</param>
    [MethodImpl(Inline), Between]
    public static bit between(float x, float a, float b)
        => x >= a && x <= b;

    /// <summary>
    /// Returns true if the the test value lies in the closed interval formed by lower and upper bounds
    /// </summary>
    /// <param name="x">The test value</param>
    /// <param name="a">The lower bound</param>
    /// <param name="b">The upper bound</param>
    [MethodImpl(Inline), Between]
    public static bit between(double x, double a, double b)
        => x >= a && x <= b;

    [Op]
    public static bit cmp(float x, float y, FpCmpMode mode)
    {
        var result = mode switch
        {
            FpCmpMode.EQ_OQ => x == y,
            FpCmpMode.EQ_OS => x == y,
            FpCmpMode.EQ_UQ => x == y,
            FpCmpMode.EQ_US => x == y,

            FpCmpMode.NEQ_OQ => x != y,
            FpCmpMode.NEQ_OS => x != y,
            FpCmpMode.NEQ_UQ => x != y,
            FpCmpMode.NEQ_US => x != y,

            FpCmpMode.LT_OQ => x < y,
            FpCmpMode.LT_OS => x < y,

            FpCmpMode.GT_OQ =>  x > y,
            FpCmpMode.GT_OS =>  x > y,

            FpCmpMode.LE_OQ =>  x <= y,
            FpCmpMode.LE_OS =>  x <= y,

            FpCmpMode.GE_OQ => x >= y,
            FpCmpMode.GE_OS => x >= y,

            FpCmpMode.NGE_UQ => !(x >= y),
            FpCmpMode.NGE_US => !(x >= y),

            FpCmpMode.NGT_UQ => !(x > y),
            FpCmpMode.NGT_US => !(x > y),

            FpCmpMode.NLE_UQ => !(x <= y),
            FpCmpMode.NLE_US => !(x <= y),

            FpCmpMode.NLT_UQ => !(x < y),
            FpCmpMode.NLT_US => !(x < y),

            _ => throw new NotSupportedException()
        };

        return result;
    }

    [Op]
    public static bit cmp(double x, double y, FpCmpMode mode)
    {
        var result = mode switch
        {
            FpCmpMode.EQ_OQ => x == y,
            FpCmpMode.EQ_OS => x == y,
            FpCmpMode.EQ_UQ => x == y,
            FpCmpMode.EQ_US => x == y,

            FpCmpMode.NEQ_OQ => x != y,
            FpCmpMode.NEQ_OS => x != y,
            FpCmpMode.NEQ_UQ => x != y,
            FpCmpMode.NEQ_US => x != y,

            FpCmpMode.LT_OQ => x < y,
            FpCmpMode.LT_OS => x < y,

            FpCmpMode.GT_OQ =>  x > y,
            FpCmpMode.GT_OS =>  x > y,

            FpCmpMode.LE_OQ =>  x <= y,
            FpCmpMode.LE_OS =>  x <= y,

            FpCmpMode.GE_OQ => x >= y,
            FpCmpMode.GE_OS => x >= y,

            FpCmpMode.NGE_UQ => !(x >= y),
            FpCmpMode.NGE_US => !(x >= y),

            FpCmpMode.NGT_UQ => !(x > y),
            FpCmpMode.NGT_US => !(x > y),

            FpCmpMode.NLE_UQ => !(x <= y),
            FpCmpMode.NLE_US => !(x <= y),

            FpCmpMode.NLT_UQ => !(x < y),
            FpCmpMode.NLT_US => !(x < y),

            _ => throw new NotSupportedException()
        };

        return result;
    }
}
