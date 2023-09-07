//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Characterizes a random source that can produce points bounded by a range
/// </summary>
/// <typeparam name="T">The primal type</typeparam>
[Free]
public interface IRandomSource<T> : IRng, IBoundSource<T>
    where T : unmanaged
{
}

[Free]
public interface IRandomSource<G,T> : IRandomSource<T>
    where T : unmanaged
    where G : IRandomSource<G,T>
{

}
