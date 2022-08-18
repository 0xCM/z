//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a reification structure over an integer type
    /// </summary>
    /// <typeparam name="S">The reification type</typeparam>
    /// <typeparam name="T">The underlying type</typeparam>
    public interface IIntegral<S,T> : IIntegral<S>
        where S : IIntegral<S,T>, new() { }

    public interface IIntegral<S> :  IRealNumeric<S>, IStepwise<S>
        where S : IIntegral<S>, new()
    { }
}