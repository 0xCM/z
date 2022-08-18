//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Sink interface root
    /// </summary>
    [Free]
    public interface ISink
    {

    }

    /// <summary>
    /// Characterizes a sink that accepts a single input value
    /// </summary>
    /// <typeparam name="A">The input type</typeparam>
    [Free]
    public interface ISink<T> : ISink
    {
        /// <summary>
        /// Receives supplied input
        /// </summary>
        /// <param name="src">The input</param>
        void Deposit(T src);
    }
}