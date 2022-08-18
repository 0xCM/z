//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a container that owns content
    /// </summary>
    /// <typeparam name="C">The content type</typeparam>
    [Free]
    public interface IContented<C>
    {
        C Content {get;}
    }

    /// <summary>
    /// Characterizes reified container
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    /// <typeparam name="C">The content type</typeparam>
    [Free]
    public interface IContented<F,C> : IContented<C>
        where F : IContented<F,C>, new()
    {
        /// <summary>
        /// Assigns content; whether existing content is replaced, accrued or
        /// if a new container is created is determined by the reifying type
        /// and its purpose in life
        /// </summary>
        /// <param name="content">The source content</param>
        F WithContent(C content);
    }

    /// <summary>
    /// Characterizes a reified container with T-stratified content
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    /// <typeparam name="C">The content type</typeparam>
    /// <typeparam name="T">The type over which the content is stratified</typeparam>
    [Free]
    public interface IContented<F,C,T> : IContented<F,C>
        where F : IContented<F,C,T>, new()
    {

    }
}