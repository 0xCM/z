//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector128<sbyte> vxnor(Vector128<sbyte> x, Vector128<sbyte> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector128<byte> vxnor(Vector128<byte> x, Vector128<byte> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector128<short> vxnor(Vector128<short> x, Vector128<short> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector128<ushort> vxnor(Vector128<ushort> x, Vector128<ushort> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector128<int> vxnor(Vector128<int> x, Vector128<int> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector128<uint> vxnor(Vector128<uint> x, Vector128<uint> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector128<long> vxnor(Vector128<long> x, Vector128<long> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector128<ulong> vxnor(Vector128<ulong> x, Vector128<ulong> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector256<byte> vxnor(Vector256<byte> x, Vector256<byte> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector256<short> vxnor(Vector256<short> x, Vector256<short> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector256<sbyte> vxnor(Vector256<sbyte> x, Vector256<sbyte> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes the bitwise XOR between operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector256<ushort> vxnor(Vector256<ushort> x, Vector256<ushort> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector256<int> vxnor(Vector256<int> x, Vector256<int> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector256<uint> vxnor(Vector256<uint> x, Vector256<uint> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector256<long> vxnor(Vector256<long> x, Vector256<long> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector256<ulong> vxnor(Vector256<ulong> x, Vector256<ulong> y)
        => vnot(Xor(x, y));


    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector512<byte> vxnor(Vector512<byte> x, Vector512<byte> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector512<short> vxnor(Vector512<short> x, Vector512<short> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector512<sbyte> vxnor(Vector512<sbyte> x, Vector512<sbyte> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes the bitwise XOR between operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector512<ushort> vxnor(Vector512<ushort> x, Vector512<ushort> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector512<int> vxnor(Vector512<int> x, Vector512<int> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector512<uint> vxnor(Vector512<uint> x, Vector512<uint> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector512<long> vxnor(Vector512<long> x, Vector512<long> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~ (x ^ y) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Xnor]
    public static Vector512<ulong> vxnor(Vector512<ulong> x, Vector512<ulong> y)
        => vnot(Xor(x, y));
}
