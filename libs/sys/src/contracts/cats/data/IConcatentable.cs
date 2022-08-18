//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IConcatenable<T>
    {
        T Concat(T lhs, T rhs);
    }

    /// <summary>
    /// Characterizes a reification that defines an intrinsic concatentation operator
    /// </summary>
    /// <typeparam name="S">The reifying type</typeparam>
    [Free]
    public interface IConcatenable<F,T>
        where F : IConcatenable<F,T>, new()
    {
        /// <summary>
        /// Concatenates the intrinsic value with a suplied value
        /// </summary>
        /// <param name="rhs">The right value supplied to the concatenation operator</param>
        F Concat(F rhs);
    }
}