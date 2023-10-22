//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector128<byte> vmin(Vector128<byte> x, Vector128<byte> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector128<sbyte> vmin(Vector128<sbyte> x, Vector128<sbyte> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector128<short> vmin(Vector128<short> x, Vector128<short> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector128<ushort> vmin(Vector128<ushort> x, Vector128<ushort> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector128<int> vmin(Vector128<int> x, Vector128<int> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector128<uint> vmin(Vector128<uint> x, Vector128<uint> y)
        => Min(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector128<long> vmin(Vector128<long> x, Vector128<long> y)
        => Min(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline)]
    public static Vector128<ulong> vmin(Vector128<ulong> x, Vector128<ulong> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Min]
    public static Vector256<byte> vmin(Vector256<byte> x, Vector256<byte> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Min]
    public static Vector256<sbyte> vmin(Vector256<sbyte> x, Vector256<sbyte> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector256<short> vmin(Vector256<short> x, Vector256<short> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector256<ushort> vmin(Vector256<ushort> x, Vector256<ushort> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector256<int> vmin(Vector256<int> x, Vector256<int> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector256<uint> vmin(Vector256<uint> x, Vector256<uint> y)
        => Min(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector256<long> vmin(Vector256<long> x, Vector256<long> y)
        => Min(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector256<ulong> vmin(Vector256<ulong> x, Vector256<ulong> y)
        => Min(x, y);
        
    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Min]
    public static Vector512<byte> vmin(Vector512<byte> x, Vector512<byte> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Min]
    public static Vector512<sbyte> vmin(Vector512<sbyte> x, Vector512<sbyte> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector512<short> vmin(Vector512<short> x, Vector512<short> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector512<ushort> vmin(Vector512<ushort> x, Vector512<ushort> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector512<int> vmin(Vector512<int> x, Vector512<int> y)
        => Min(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector512<uint> vmin(Vector512<uint> x, Vector512<uint> y)
        => Min(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector512<long> vmin(Vector512<long> x, Vector512<long> y)
        => Min(x, y);
        
    /// <summary>
    /// Computes the maximum values of corresponding components
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Min]
    public static Vector512<ulong> vmin(Vector512<ulong> x, Vector512<ulong> y)
        => Min(x, y);
}
