//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector128<sbyte> vnor(Vector128<sbyte> a, Vector128<sbyte> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector128<byte> vnor(Vector128<byte> a, Vector128<byte> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector128<short> vnor(Vector128<short> a, Vector128<short> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector128<ushort> vnor(Vector128<ushort> a, Vector128<ushort> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector128<int> vnor(Vector128<int> a, Vector128<int> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector128<uint> vnor(Vector128<uint> a, Vector128<uint> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector128<long> vnor(Vector128<long> a, Vector128<long> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector128<ulong> vnor(Vector128<ulong> a, Vector128<ulong> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector128<float> vnor(Vector128<float> a, Vector128<float> b)
        => fcpu.vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector128<double> vnor(Vector128<double> a, Vector128<double> b)
        => fcpu.vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector256<byte> vnor(Vector256<byte> a, Vector256<byte> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector256<short> vnor(Vector256<short> a, Vector256<short> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector256<sbyte> vnor(Vector256<sbyte> a, Vector256<sbyte> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector256<ushort> vnor(Vector256<ushort> a, Vector256<ushort> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector256<int> vnor(Vector256<int> a, Vector256<int> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector256<uint> vnor(Vector256<uint> a, Vector256<uint> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector256<long> vnor(Vector256<long> a, Vector256<long> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector256<ulong> vnor(Vector256<ulong> a, Vector256<ulong> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector512<byte> vnor(Vector512<byte> a, Vector512<byte> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector512<short> vnor(Vector512<short> a, Vector512<short> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector512<sbyte> vnor(Vector512<sbyte> a, Vector512<sbyte> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector512<ushort> vnor(Vector512<ushort> a, Vector512<ushort> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector512<int> vnor(Vector512<int> a, Vector512<int> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector512<uint> vnor(Vector512<uint> a, Vector512<uint> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector512<long> vnor(Vector512<long> a, Vector512<long> b)
        => vnot(Or(a, b));

    /// <summary>
    /// Computes ~(x | b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector512<ulong> vnor(Vector512<ulong> a, Vector512<ulong> b)
        => vnot(Or(a, b));
}
