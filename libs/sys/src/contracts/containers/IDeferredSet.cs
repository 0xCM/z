//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a reified set over elements of parametric type
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    /// <typeparam name="T">The element type</typeparam>
    [Free]
    public interface IDeferredSet<F,T> : IFiniteDeferral<F,T>, ICounted, INullity
        where F : IDeferredSet<F,T>, new()
    {
        /// <summary>
        /// Determines whether a value is a member
        /// </summary>
        /// <param name="candidate">The potential member</param>
        bool Contains(T candidate);

        /// <summary>
        /// Determines whether the current set is a subset of a specified set.
        /// </summary>
        /// <param name="rhs">The candidate superset</param>
        /// <param name="proper">Specifies whether only proper subsets are considered "subsets"</param>
        bool IsSubset(F rhs, bool proper = true);

        /// <summary>
        /// Determines whether the current set is a superset of a specified set.
        /// </summary>
        /// <param name="rhs">The candidate subset</param>
        /// <param name="proper">Specifies whether only proper subsets are considered "subsets"</param>
        bool IsSuperset(F rhs, bool proper = true);

        /// <summary>
        /// Calculates the union between the current set and a specified set and
        /// returns a new set that embodies this result
        /// </summary>
        /// <param name="rhs">The set with which to union/param>
        F Union(F rhs);

        /// <summary>
        /// Calculates the intersection between the current set and a specified set and
        /// returns a new set that embodies this result
        /// </summary>
        /// <param name="rhs">The set with which to intersect</param>
        F Intersect(F rhs);

        /// <summary>
        /// Calculates the set difference, or symmetric difference, between the current
        /// set and a specified set and returns a new set that embodies this result
        /// </summary>
        /// <param name="rhs">The set that should be differenced</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Symmetric_difference</remarks>
        F Difference(F rhs, bool symmetric = false);
    }
}