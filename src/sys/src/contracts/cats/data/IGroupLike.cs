//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IGroupLike<T> : IInvertive<T>, IMonoid<T>
    {

    }

    /// <summary>
    /// Characterizes a group structure
    /// </summary>
    /// <typeparam name="T">The type over which the structure is defind</typeparam>
    /// <typeparam name="S">The structure type</typeparam>
    public interface IGroupLike<S,T> : IGroupLike<S>
        where S : IGroupLike<S,T>, new()
    {

    }
}