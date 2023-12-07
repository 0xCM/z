//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static CpuBytes;

partial class vcpu
{
    /// <summary>
    /// Creates a 128-bit vector where each component is of unit value
    /// </summary>
    /// <param name="w">The vector width selector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector128<T> vunits<T>(N128 w)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
            return generic<T>(vload(w, first(Units128x8u)));
        else if(typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
            return generic<T>(vload(w, first(Units128x16u)));
        else if(typeof(T) == typeof(uint) || typeof(T) == typeof(int))
            return generic<T>(vload(w,first(Units128x32u)));
        else if(typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
            return generic<T>(vload(w,first(Units128x64u)));
        else
            throw no<T>();
    }

    /// <summary>
    /// Creates a 256-bit vector where each component is of unit value
    /// </summary>
    /// <param name="w">The vector width selector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector256<T> vunits<T>(N256 w)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
            return generic<T>(vload(w, first(Units256x8u)));
        else if(typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
            return generic<T>(vload(w, first(Units256x16u)));
        else if(typeof(T) == typeof(uint) || typeof(T) == typeof(int))
            return generic<T>(vload(w, first(Units256x32u)));
        else if(typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
            return generic<T>(vload(w, first(Units256x64u)));
        else
            throw no<T>();
    }

    /// <summary>
    /// Creates a 512-bit vector where each component is of unit value
    /// </summary>
    /// <param name="w">The vector width selector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector512<T> vunits<T>(W512 w)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
            return generic<T>(vload(w, first(Units512x8u)));
        else if(typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
            return generic<T>(vload(w, first(Units512x16u)));
        else if(typeof(T) == typeof(uint) || typeof(T) == typeof(int))
            return generic<T>(vload(w, first(Units512x32u)));
        else if(typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
            return generic<T>(vload(w, first(Units512x64u)));
        else
            throw no<T>();
    }
}
