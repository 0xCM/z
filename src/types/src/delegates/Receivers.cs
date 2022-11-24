//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a receiver that accepts a stream
    /// </summary>
    /// <typeparam name="T">The stream element type</typeparam>
    [Free]
    public delegate void StreamReceiver<T>(IEnumerable<T> src);
}