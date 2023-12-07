//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector128<sbyte> vinc(Vector128<sbyte> src)
        => vadd(src, vunits<sbyte>(w128));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector128<byte> vinc(Vector128<byte> src)
        => vadd(src, vunits<byte>(w128));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector128<short> vinc(Vector128<short> src)
        => vadd(src, vunits<short>(w128));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector128<ushort> vinc(Vector128<ushort> src)
        => vadd(src, vunits<ushort>(w128));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector128<int> vinc(Vector128<int> src)
        => vadd(src, vunits<int>(w128));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector128<uint> vinc(Vector128<uint> src)
        => vadd(src, vunits<uint>(w128));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector128<long> vinc(Vector128<long> src)
        => vadd(src, vunits<long>(w128));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector128<ulong> vinc(Vector128<ulong> src)
        => vadd(src, vunits<ulong>(w128));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector256<sbyte> vinc(Vector256<sbyte> src)
        => vadd(src, vunits<sbyte>(w256));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector256<byte> vinc(Vector256<byte> src)
        => vadd(src, vunits<byte>(w256));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector256<short> vinc(Vector256<short> src)
        => vadd(src, vunits<short>(w256));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector256<ushort> vinc(Vector256<ushort> src)
        => vadd(src, vunits<ushort>(w256));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector256<int> vinc(Vector256<int> src)
        => vadd(src, vunits<int>(w256));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector256<uint> vinc(Vector256<uint> src)
        => vadd(src, vunits<uint>(w256));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector256<long> vinc(Vector256<long> src)
        => vadd(src, vunits<long>(w256));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector256<ulong> vinc(Vector256<ulong> src)
        => vadd(src, vunits<ulong>(w256));


    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector512<sbyte> vinc(Vector512<sbyte> src)
        => vadd(src, vunits<sbyte>(w512));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector512<byte> vinc(Vector512<byte> src)
        => vadd(src, vunits<byte>(w512));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector512<short> vinc(Vector512<short> src)
        => vadd(src, vunits<short>(w512));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector512<ushort> vinc(Vector512<ushort> src)
        => vadd(src, vunits<ushort>(w512));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector512<int> vinc(Vector512<int> src)
        => vadd(src, vunits<int>(w512));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector512<uint> vinc(Vector512<uint> src)
        => vadd(src, vunits<uint>(w512));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector512<long> vinc(Vector512<long> src)
        => vadd(src, vunits<long>(w512));

    /// <summary>
    /// Increments each component by 1
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Inc]
    public static Vector512<ulong> vinc(Vector512<ulong> src)
        => vadd(src, vunits<ulong>(w512));
}
