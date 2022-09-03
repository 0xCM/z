//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a structure over which both incrementing and decrementing
    /// operations are defined
    /// </summary>
    /// <typeparam name="S">The structure type</typeparam>
    [Free]
    public interface IStepwise<T> : IIncrementable<T>, IDecrementable<T>
    {

    }

    [Free]
    public interface IStepwise<F,T> : IStepwise<T>
        where F : IStepwise<F,T>, new()
    {

    }
}