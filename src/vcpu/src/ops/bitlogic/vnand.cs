//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector128<sbyte> vnand(Vector128<sbyte> a, Vector128<sbyte> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector128<byte> vnand(Vector128<byte> a, Vector128<byte> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector128<short> vnand(Vector128<short> a, Vector128<short> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector128<ushort> vnand(Vector128<ushort> a, Vector128<ushort> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector128<int> vnand(Vector128<int> a, Vector128<int> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector128<uint> vnand(Vector128<uint> a, Vector128<uint> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector128<long> vnand(Vector128<long> a, Vector128<long> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector128<ulong> vnand(Vector128<ulong> a, Vector128<ulong> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector256<byte> vnand(Vector256<byte> a, Vector256<byte> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector256<short> vnand(Vector256<short> a, Vector256<short> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector256<sbyte> vnand(Vector256<sbyte> a, Vector256<sbyte> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector256<ushort> vnand(Vector256<ushort> a, Vector256<ushort> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector256<int> vnand(Vector256<int> a, Vector256<int> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector256<uint> vnand(Vector256<uint> a, Vector256<uint> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector256<long> vnand(Vector256<long> a, Vector256<long> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector256<ulong> vnand(Vector256<ulong> a, Vector256<ulong> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector512<byte> vnand(Vector512<byte> a, Vector512<byte> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector512<short> vnand(Vector512<short> a, Vector512<short> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector512<sbyte> vnand(Vector512<sbyte> a, Vector512<sbyte> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector512<ushort> vnand(Vector512<ushort> a, Vector512<ushort> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector512<int> vnand(Vector512<int> a, Vector512<int> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector512<uint> vnand(Vector512<uint> a, Vector512<uint> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector512<long> vnand(Vector512<long> a, Vector512<long> b)
        => vnot(And(a, b));

    /// <summary>
    /// Computes ~(x & b) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector512<ulong> vnand(Vector512<ulong> a, Vector512<ulong> b)
        => vnot(And(a, b));

}
