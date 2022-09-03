//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines attributes common to set representations
    /// </summary>
    public interface ISetAspect
    {
        /// <summary>
        /// Specifies whether the set is void of elements
        /// </summary>
        bool IsEmpty {get;}

        /// <summary>
        /// Specifies whether the set is finite
        /// </summary>
        bool IsFinite {get;}

        /// <summary>
        /// Specifies whether the set is discrete
        /// </summary>
        bool IsDiscrete {get;}
    }

    /// <summary>
    /// Characterizes a type that represents an infinite number of values
    /// </summary>
    /// <typeparam name="T">The member type</typeparam>
    public interface IInfiniteSet<S> : ISetAspect
        where S : IInfiniteSet<S>, new()
    {
        bool ISetAspect.IsFinite => false;
    }

    /// <summary>
    /// Characterizes a type that represents an infinite number of values
    /// </summary>
    /// <typeparam name="T">The member type</typeparam>
    public interface IInfiniteSet<S,T> : IInfiniteSet<S>
        where S : IInfiniteSet<S,T>, new()
    {

    }
}