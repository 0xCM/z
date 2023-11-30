//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Loads a scalar into the first component of a 128-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vscalar(W128 w, sbyte a)
        => Vector128.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 128-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vscalar(W128 w, byte a)
        => Vector128.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 128-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vscalar(W128 w, short a)
        => Vector128.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 128-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vscalar(W128 w, ushort a)
        => Vector128.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 128-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vscalar(W128 w, int a)
        => Vector128.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 128-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vscalar(W128 w, uint a)
        => Vector128.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 128-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vscalar(W128 w, long a)
        => Vector128.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 128-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vscalar(W128 w, ulong a)
        => Vector128.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 128-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vscalar(W256 w, sbyte a)
        => Vector256.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vscalar(W256 w, byte a)
        => Vector256.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vscalar(W256 w, short a)
        => Vector256.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vscalar(W256 w, ushort a)
        => Vector256.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vscalar(W256 w, int a)
        => Vector256.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vscalar(W256 w, uint a)
        => Vector256.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vscalar(W256 w, long a)
        => Vector256.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vscalar(W256 w, ulong a)
        => Vector256.CreateScalarUnsafe(a);


    /// <summary>
    /// Loads a scalar into the first component of a 128-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vscalar(W512 w, sbyte a)
        => Vector512.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 512-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vscalar(W512 w, byte a)
        => Vector512.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 512-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vscalar(W512 w, short a)
        => Vector512.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 512-bit vector
    /// </summary>
    /// <param name="a">The scalar to load</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vscalar(W512 w, ushort a)
        => Vector512.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 512-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vscalar(W512 w, int a)
        => Vector512.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 512-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vscalar(W512 w, uint a)
        => Vector512.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 512-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vscalar(W512 w, long a)
        => Vector512.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 512-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vscalar(W512 w, ulong a)
        => Vector512.CreateScalarUnsafe(a);
}
