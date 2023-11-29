//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Presents a generic cpu vector as a cpu vector with components of type float64
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The source vector primal component type</typeparam>
    [MethodImpl(Inline), Concretizer, Closures(Closure)]
    public static Vector128<double> v64f<T>(Vector128<T> x)
        where T : unmanaged
            => x.AsDouble();

    /// <summary>
    /// Presents a generic cpu vector as a cpu vector with components of type float64
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The source vector primal component type</typeparam>
    [MethodImpl(Inline), Concretizer, Closures(Closure)]
    public static Vector256<double> v64f<T>(Vector256<T> x)
        where T : unmanaged
            => x.AsDouble();

    /// <summary>
    /// Presents a generic cpu vector as a cpu vector with components of type float64
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The source vector primal component type</typeparam>
    [MethodImpl(Inline), Concretizer, Closures(Closure)]
    public static Vector512<double> v64f<T>(Vector512<T> x)
        where T : unmanaged
            => x.AsDouble();
}
