//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IPipe
    {

    }

    /// <summary>
    /// Defines in a fundamental sense what in means to be a pipe: the joining of a source and a sink
    /// </summary>
    /// <typeparam name="T">The subject type</typeparam>
    [Free]
    public interface IPipe<T> : IPipe, ISink<T>, ISource<T>
    {


    }

    /// <summary>
    /// Characterizes a transformative pipe accepting <typeparamref name='S'/> input values and
    /// emitting <typeparamref name='T'/> output values
    /// </summary>
    /// <typeparam name="S">The input type</typeparam>
    /// <typeparam name="T">The output type</typeparam>
    [Free]
    public interface IPipe<S,T> : IPipe, ISink<S>, ISource<T>
    {

    }
}