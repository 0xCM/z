//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a totally ordered structure
    /// </summary>
    /// <typeparam name="T">The structure reification type</typeparam>
    [Free]
    public interface IOrdered<T>
    {
        /// <summary>
        /// Determines whether this:T & rhs:T => this < rhs
        /// </summary>
        /// <param name="rhs">The operand to compare</param>
        bool Lt(T rhs);

        /// <summary>
        /// Determines whether this:T & rhs:T => this <= rhs
        /// </summary>
        /// <param name="rhs">The operand to compare</param>
        bool LtEq(T rhs);

        /// <summary>
        /// Determines whether this:T & rhs:T => this > rhs
        /// </summary>
        /// <param name="rhs">The operand to compare</param>
        bool Gt(T rhs);

        /// <summary>
        /// Determines whether this:T & rhs:T => this >= rhs
        /// </summary>
        /// <param name="rhs">The operand to compare</param>
        bool GtEq(T rhs);
    }

    [Free]
    public interface IOrdered<F,T> : IOrdered<T>
        where F : IOrdered<F,T>, new()
    {

    }
}