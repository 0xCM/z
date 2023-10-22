//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vle(Vector128<byte> a, Vector128<byte> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vle(Vector128<sbyte> a, Vector128<sbyte> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vle(Vector128<ushort> a, Vector128<ushort> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vle(Vector128<short> a, Vector128<short> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vle(Vector128<uint> a, Vector128<uint> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vle(Vector128<int> a, Vector128<int> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vle(Vector128<ulong> a, Vector128<ulong> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vle(Vector128<long> a, Vector128<long> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vle(Vector256<byte> a, Vector256<byte> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vle(Vector256<sbyte> a, Vector256<sbyte> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vle(Vector256<ushort> a, Vector256<ushort> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vle(Vector256<short> a, Vector256<short> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vle(Vector256<uint> a, Vector256<uint> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vle(Vector256<int> a, Vector256<int> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vle(Vector256<ulong> a, Vector256<ulong> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vle(Vector256<long> a, Vector256<long> b)
        => CompareLessThanOrEqual(a,b);        


    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vle(Vector512<byte> a, Vector512<byte> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vle(Vector512<sbyte> a, Vector512<sbyte> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vle(Vector512<ushort> a, Vector512<ushort> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vle(Vector512<short> a, Vector512<short> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vle(Vector512<uint> a, Vector512<uint> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vle(Vector512<int> a, Vector512<int> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vle(Vector512<ulong> a, Vector512<ulong> b)
        => CompareLessThanOrEqual(a,b);

    /// <summary>
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vle(Vector512<long> a, Vector512<long> b)
        => CompareLessThanOrEqual(a,b);        
}