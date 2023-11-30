//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector128<sbyte> vimpl(Vector128<sbyte> a, Vector128<sbyte> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector128<byte> vimpl(Vector128<byte> a, Vector128<byte> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector128<short> vimpl(Vector128<short> a, Vector128<short> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector128<ushort> vimpl(Vector128<ushort> a, Vector128<ushort> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector128<int> vimpl(Vector128<int> a, Vector128<int> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector128<uint> vimpl(Vector128<uint> a, Vector128<uint> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector128<long> vimpl(Vector128<long> a, Vector128<long> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector128<ulong> vimpl(Vector128<ulong> a, Vector128<ulong> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector256<sbyte> vimpl(Vector256<sbyte> a, Vector256<sbyte> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector256<byte> vimpl(Vector256<byte> a, Vector256<byte> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector256<short> vimpl(Vector256<short> a, Vector256<short> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector256<ushort> vimpl(Vector256<ushort> a, Vector256<ushort> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector256<int> vimpl(Vector256<int> a, Vector256<int> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector256<uint> vimpl(Vector256<uint> a, Vector256<uint> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector256<long> vimpl(Vector256<long> a, Vector256<long> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector256<ulong> vimpl(Vector256<ulong> a, Vector256<ulong> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector512<sbyte> vimpl(Vector512<sbyte> a, Vector512<sbyte> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector512<byte> vimpl(Vector512<byte> a, Vector512<byte> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector512<short> vimpl(Vector512<short> a, Vector512<short> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector512<ushort> vimpl(Vector512<ushort> a, Vector512<ushort> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector512<int> vimpl(Vector512<int> a, Vector512<int> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector512<uint> vimpl(Vector512<uint> a, Vector512<uint> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector512<long> vimpl(Vector512<long> a, Vector512<long> b)
        => Or(a, vnot(b));

    /// <summary>
    /// Computes the material implication, x | ~y for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Impl]
    public static Vector512<ulong> vimpl(Vector512<ulong> a, Vector512<ulong> b)
        => Or(a, vnot(b));        
}
