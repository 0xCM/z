//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<sbyte> vne(Vector128<sbyte> x, Vector128<sbyte> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<byte> vne(Vector128<byte> x, Vector128<byte> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<short> vne(Vector128<short> x, Vector128<short> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<ushort> vne(Vector128<ushort> x, Vector128<ushort> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// </summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<int> vne(Vector128<int> x, Vector128<int> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// </summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<uint> vne(Vector128<uint> x, Vector128<uint> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<long> vne(Vector128<long> x, Vector128<long> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<ulong> vne(Vector128<ulong> x, Vector128<ulong> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<sbyte> vne(Vector256<sbyte> x, Vector256<sbyte> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<byte> vne(Vector256<byte> x, Vector256<byte> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<short> vne(Vector256<short> x, Vector256<short> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<ushort> vne(Vector256<ushort> x, Vector256<ushort> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<int> vne(Vector256<int> x, Vector256<int> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<uint> vne(Vector256<uint> x, Vector256<uint> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<long> vne(Vector256<long> x, Vector256<long> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<ulong> vne(Vector256<ulong> x, Vector256<ulong> y)
        => CompareNotEqual(x,y);

    [MethodImpl(Inline), Gt]
    public static Vector512<sbyte> vne(Vector512<sbyte> a, Vector512<sbyte> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<byte> vne(Vector512<byte> a, Vector512<byte> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<short> vne(Vector512<short> a, Vector512<short> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<ushort> vne(Vector512<ushort> a, Vector512<ushort> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<int> vne(Vector512<int> a, Vector512<int> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<uint> vne(Vector512<uint> a, Vector512<uint> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<long> vne(Vector512<long> a, Vector512<long> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<ulong> vne(Vector512<ulong> a, Vector512<ulong> b)
        => CompareNotEqual(a,b);        
}
