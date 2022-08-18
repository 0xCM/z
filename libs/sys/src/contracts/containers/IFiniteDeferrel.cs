//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    /// <summary>
    /// Characterizes a finite deferred T-sequence
    /// </summary>
    /// <typeparam name="T">The sequence element type</typeparam>
    [Free]
    public interface IFiniteDeferral<T> : IDeferred<T>, IFinite
    {
        /// <summary>
        /// Brings the deferral to life
        /// </summary>
        T[] Force()
            => Content.ToArray();
    }

    /// <summary>
    /// Characterizes a reified finite sequence
    /// </summary>
    /// <typeparam name="S">The reifying type</typeparam>
    /// <typeparam name="T">The sequence element type</typeparam>
    [Free]
    public interface IFiniteDeferral<F,T> : IDeferred<F,T>, IFiniteDeferral<T>
        where F : IFiniteDeferral<F,T>, new()
    {

    }
}