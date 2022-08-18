//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IOrderedNumeric<S> :  IStepwise<S>,  IOrdered<S>,  IRational<S>
        where S : IOrderedNumeric<S>, new() {}

    /// <summary>
    /// Characterizes a structural number with order
    /// </summary>
    /// <typeparam name="S">The reification type</typeparam>
    /// <typeparam name="T">The underlying type</typeparam>
    public interface IOrderedNumeric<S,T> : IOrderedNumeric<S>
        where S : IOrderedNumeric<S,T>, new() {}

}