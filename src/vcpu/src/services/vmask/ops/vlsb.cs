//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static BitMasks;
using static sys;
using static vgcpu;

partial struct vmask
{
    /// <summary>
    /// The least bit of each cell is enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <param name="t">A component type representative</param>
    /// <typeparam name="T">The component data type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N1 f, N1 d, T t = default)
        where T : unmanaged
            => vbroadcast(w, lsb<T>(f,d,t));

    /// <summary>
    /// [01]
    /// The least bit of each 2-bit segment is enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <param name="t">A component type representative</param>
    /// <typeparam name="T">The component data type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N2 f, N1 d, T t = default)
        where T : unmanaged
            => vbroadcast(w,lsb<T>(f,d,t));

    /// <summary>
    /// [0001]
    /// The least bit of each 4-bit segment is enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <param name="t">A component type representative</param>
    /// <typeparam name="T">The component data type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N4 f, N1 d, T t = default)
        where T : unmanaged
            => vbroadcast(w,lsb(f,d,t));

    /// <summary>
    /// [00000001]
    /// The least bit of each 8-bit segment is enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <param name="t">A component type representative</param>
    /// <typeparam name="T">The component data type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N8 f, N1 d)
        where T : unmanaged
            => vbroadcast(w,lsb<T>(f,d));

    /// <summary>
    /// [00000000 00000001]
    /// The least bit of each 16-bit segment is enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <param name="t">A component type representative</param>
    /// <typeparam name="T">The component data type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N16 f, N1 d)
        where T : unmanaged
            => generic<T>(vbroadcast<ulong>(w, lsb64(f, d)));

    /// <summary>
    /// [00000011]
    /// The least 2 bits of each 8-bits are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <param name="t">A component type representative</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N8 f, N2 d)
        where T : unmanaged
            => vbroadcast(w,lsb<T>(f,d));

    /// <summary>
    /// [00000111]
    /// The least 3 bits of each 8-bits are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N8 f, N3 d)
        where T : unmanaged
            => vbroadcast(w,lsb<T>(f,d));

    /// <summary>
    /// [00001111]
    /// The least 4 bits of each 8-bits are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <param name="t">A component type representative</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N8 f, N4 d)
        where T : unmanaged
            => vbroadcast(w, lsb<T>(f,d));

    /// <summary>
    /// [00011111]
    /// The least 5 bits of each 8-bits are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <param name="t">A component type representative</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N8 f, N5 d)
        where T : unmanaged
            => vbroadcast(w, lsb<T>(f,d));

    /// <summary>
    /// [00111111]
    /// The least 6 bits of each 8-bits are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <param name="t">A component type representative</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N8 f, N6 d, T t = default)
        where T : unmanaged
            => vbroadcast(w, lsb(f,d,t));

    /// <summary>
    /// [01111111]
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <param name="t">A component type representative</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N8 f, N7 d, T t = default)
        where T : unmanaged
            => vbroadcast(w, lsb(f,d,t));

    /// <summary>
    /// [00....01]
    /// The least bit of each component is enabled
    /// </summary>
    /// <param name="n">The repetition frequency</param>
    /// <typeparam name="T">The component data type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N1 f, N1 d, T t = default)
        where T : unmanaged
            => vbroadcast(w,lsb(f,d,t));

    /// <summary>
    /// [01 01 01 01]
    /// The least bit of each 2-bit segment is enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <typeparam name="T">The component data type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N2 f, N1 d, T t = default)
        where T : unmanaged
            => vbroadcast(w,lsb(f,d,t));

    /// <summary>
    /// [0001 0001]
    /// The least bit of each 4-bit segment is enabled
    /// </summary>
    /// <param name="f">The repetition frequency</param>
    /// <typeparam name="T">The component data type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N4 f, N1 d,T t = default)
        where T : unmanaged
            => vbroadcast(w, lsb<T>(f,d,t));

    /// <summary>
    /// [00000001]
    /// The least bit of each 8-bit segment is enabled
    /// </summary>
    /// <param name="f">The repetition frequency</param>
    /// <typeparam name="T">The component data type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N8 f, N1 d,T t = default)
        where T : unmanaged
            => vbroadcast(w, lsb<T>(f,d,t));

    /// <summary>
    /// [00000000 00000001]
    /// The least significant bit out of each 16 bits is enabled
    /// </summary>
    /// <param name="f">The repetition frequency</param>
    /// <typeparam name="T">The component data type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N16 f, N1 d,T t = default)
        where T : unmanaged
            => generic<T>(vbroadcast<ulong>(w, lsb64(f, d)));

    /// <summary>
    /// [00000011]
    /// The least significant 2 bits of each 8-bit segment are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N8 f, N2 d, T t = default)
        where T : unmanaged
            => vbroadcast(w, lsb<T>(f,d));

    /// <summary>
    /// [00000111]
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N8 f, N3 d, T t = default)
        where T : unmanaged
            => vbroadcast(w, lsb<T>(f,d));

    /// <summary>
    /// [00001111]
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N8 f, N4 d, T t = default)
        where T : unmanaged
            => vbroadcast(w,lsb<T>(f,d));

    /// <summary>
    /// [00011111]
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N8 f, N5 d, T t = default)
        where T : unmanaged
            => vbroadcast(w,lsb<T>(f,d));

    /// <summary>
    /// [00111111]
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N8 f, N6 d, T t = default)
        where T : unmanaged
            => vbroadcast(w, lsb<T>(f,d));

    /// <summary>
    /// [01111111]
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">The bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N8 f, N7 d, T t = default)
        where T : unmanaged
            => vbroadcast(w, lsb<T>(f,d));

    /// <summary>
    /// The f least significant bits of each 8 bit segment are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">A value in the range [2,7] that defines the bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vlsb<T>(W128 w, N8 f, byte d, T t = default)
        where T : unmanaged
            => generic<T>(vbroadcast<byte>(w, lsb8f(d)));

    /// <summary>
    /// The f least significant bits of each 8 bit segment are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">A value in the range [2,7] that defines the bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vlsb<T>(W256 w, N8 f, byte d, T t = default)
        where T : unmanaged
            => generic<T>(vbroadcast<byte>(w, lsb8f(d)));
}
