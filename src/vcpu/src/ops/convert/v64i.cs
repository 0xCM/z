//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Presents a generic cpu vector as a cpu vector with components of type int64
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The source vector primal component type</typeparam>
    [MethodImpl(Inline), Concretizer, Closures(Closure)]
    public static Vector128<long> v64i<T>(Vector128<T> x)
        where T : unmanaged
            => x.AsInt64();

    /// <summary>
    /// Presents a generic cpu vector as a cpu vector with components of type int64
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The source vector primal component type</typeparam>
    [MethodImpl(Inline), Concretizer, Closures(Closure)]
    public static Vector256<long> v64i<T>(Vector256<T> x)
        where T : unmanaged
            => x.AsInt64();

    /// <summary>
    /// Presents a generic cpu vector as a cpu vector with components of type uint8
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The source vector primal component type</typeparam>
    [MethodImpl(Inline), Concretizer, Closures(Closure)]
    public static Vector512<long> v64i<T>(Vector512<T> x)
        where T : unmanaged
            => x.AsInt64();
}
