//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vxornot(Vector128<sbyte> x, Vector128<sbyte> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vxornot(Vector128<byte> x, Vector128<byte> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vxornot(Vector128<short> x, Vector128<short> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vxornot(Vector128<ushort> x, Vector128<ushort> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vxornot(Vector128<int> x, Vector128<int> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vxornot(Vector128<uint> x, Vector128<uint> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vxornot(Vector128<long> x, Vector128<long> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vxornot(Vector128<ulong> x, Vector128<ulong> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vxornot(Vector256<byte> x, Vector256<byte> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vxornot(Vector256<short> x, Vector256<short> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vxornot(Vector256<sbyte> x, Vector256<sbyte> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vxornot(Vector256<ushort> x, Vector256<ushort> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vxornot(Vector256<int> x, Vector256<int> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vxornot(Vector256<uint> x, Vector256<uint> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vxornot(Vector256<long> x, Vector256<long> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vxornot(Vector256<ulong> x, Vector256<ulong> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vxornot(Vector512<byte> x, Vector512<byte> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vxornot(Vector512<short> x, Vector512<short> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vxornot(Vector512<sbyte> x, Vector512<sbyte> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vxornot(Vector512<ushort> x, Vector512<ushort> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vxornot(Vector512<int> x, Vector512<int> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vxornot(Vector512<uint> x, Vector512<uint> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vxornot(Vector512<long> x, Vector512<long> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes x ^ ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vxornot(Vector512<ulong> x, Vector512<ulong> y)
        => Xor(x, vnot(y));
}
