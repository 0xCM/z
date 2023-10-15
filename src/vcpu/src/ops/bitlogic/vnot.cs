//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector128<sbyte> vnot(Vector128<sbyte> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector128<byte> vnot(Vector128<byte> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector128<short> vnot(Vector128<short> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector128<ushort> vnot(Vector128<ushort> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector128<int> vnot(Vector128<int> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector128<uint> vnot(Vector128<uint> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector128<long> vnot(Vector128<long> a)
        => vnot(a.AsUInt32()).AsInt64();

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector128<ulong> vnot(Vector128<ulong> a)
        => vnot(a.AsUInt32()).AsUInt64();

    [MethodImpl(Inline), Op]
    public static Vector128<float> vnot(Vector128<float> a)
        => Xor(a, CompareEqual(a, a));

    [MethodImpl(Inline), Op]
    public static Vector128<double> vnot(Vector128<double> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector256<sbyte> vnot(Vector256<sbyte> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector256<byte> vnot(Vector256<byte> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector256<short> vnot(Vector256<short> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector256<ushort> vnot(Vector256<ushort> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector256<int> vnot(Vector256<int> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector256<uint> vnot(Vector256<uint> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector256<long> vnot(Vector256<long> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector256<ulong> vnot(Vector256<ulong> a)
        => Xor(a, CompareEqual(a, a));

    [MethodImpl(Inline), Op]
    public static Vector256<float> vnot(Vector256<float> a)
        => Xor(a, Compare(a, a, FloatComparisonMode.OrderedEqualNonSignaling));

    [MethodImpl(Inline), Op]
    public static Vector256<double> vnot(Vector256<double> a)
        => Xor(a, Compare(a, a, FloatComparisonMode.OrderedEqualNonSignaling));


    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector512<sbyte> vnot(Vector512<sbyte> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector512<byte> vnot(Vector512<byte> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector512<short> vnot(Vector512<short> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector512<ushort> vnot(Vector512<ushort> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector512<int> vnot(Vector512<int> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector512<uint> vnot(Vector512<uint> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector512<long> vnot(Vector512<long> a)
        => Xor(a, CompareEqual(a, a));

    /// <summary>
    /// Computes the bitwise negation of the source vector
    /// </summary>
    /// <param name="a">The source vector</param>
    [MethodImpl(Inline), Not]
    public static Vector512<ulong> vnot(Vector512<ulong> a)
        => Xor(a, CompareEqual(a, a));

}
