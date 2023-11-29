//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// Presents a generic cpu vector as a cpu vector with components of type uint16
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The source vector primal component type</typeparam>
    [MethodImpl(Inline), Concretizer, Closures(Closure)]
    public static Vector128<ushort> v16u<T>(Vector128<T> x)
        where T : unmanaged
            => x.AsUInt16();

    /// <summary>
    /// Presents a generic cpu vector as a cpu vector with components of type uint16
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The source vector primal component type</typeparam>
    [MethodImpl(Inline), Concretizer, Closures(Closure)]
    public static Vector256<ushort> v16u<T>(Vector256<T> x)
        where T : unmanaged
            => x.AsUInt16();

    /// <summary>
    /// Presents a generic cpu vector as a cpu vector with components of type int16
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The source vector primal component type</typeparam>
    [MethodImpl(Inline), Concretizer, Closures(Closure)]
    public static Vector512<ushort> v16u<T>(Vector512<T> x)
        where T : unmanaged
            => x.AsUInt16();
}
