//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a discrete group structure
    /// </summary>
    /// <typeparam name="T">The operational type</typeparam>
    /// <typeparam name="S">The structure type</typeparam>
    public interface IDiscreteGroup<S,T> : IGroupLike<S,T>, IDeferredSet<S,T>
        where S : IDiscreteGroup<S,T>, new()
    {

    }

    public interface IDiscreteGroup<S> : IGroupLike<S>
        where S : IDiscreteGroup<S>, new()
    {

    }
}