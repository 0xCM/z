//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the signature of an operator that accepts a primal value and
    /// partitions the value, or portion thereof, into segments of common length
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="dst">The target span of sufficient length to receive the partition segments</param>
    /// <typeparam name="S">The primal source type</typeparam>
    /// <typeparam name="T">The primal target type</typeparam>
    [Free]
    public delegate void SpanPartitioner<S,T>(S src, Span<T> dst)
        where T : unmanaged;
}