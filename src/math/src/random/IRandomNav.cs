//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Characterizes a random stream navigator
/// </summary>
[Free]
public interface IRandomNav
{
    /// <summary>
    /// Moves the stream a specified number of steps forward
    /// </summary>
    /// <param name="steps">The step count</param>
    void Advance(ulong steps);

    /// <summary>
    /// Moves the stream a specified number of steps backward
    /// </summary>
    /// <param name="steps">The step count</param>
    void Retreat(ulong steps);
}

/// <summary>
/// Characterizes a random source that can be navigated
/// </summary>
/// <typeparam name="T">The primal element type</typeparam>
[Free]
public interface IRandomNav<T> : IRandomNav, IRandomSource<T>
    where T : unmanaged
{

}
