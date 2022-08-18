//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a set over elements of parametric type
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    [Free]
    public interface IConstSet<T> : IDeferredSource<T>, ICounted, INullity
    {
        /// <summary>
        /// Determines whether a value is a member
        /// </summary>
        /// <param name="candidate">The potential member</param>
        bool Contains(T candidate);
    }

    /// <summary>
    /// Characterizes a reified set over elements of parametric type
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    /// <typeparam name="T">The element type</typeparam>
    [Free]
    public interface IConstSet<F,T> : IConstSet<T>
        where F : struct, IConstSet<F,T>
    {
        /// <summary>
        /// Determines whether the current set is a subset of a specified set.
        /// </summary>
        /// <param name="rhs">The candidate superset</param>
        /// <param name="proper">Specifies whether only proper subsets are considered "subsets"</param>
        bool IsSubset(F rhs, bool proper);

        /// <summary>
        /// Determines whether the current set is a superset of a specified set.
        /// </summary>
        /// <param name="rhs">The candidate subset</param>
        /// <param name="proper">Specifies whether only proper subsets are considered "subsets"</param>
        bool IsSuperset(F rhs, bool proper);
    }
}