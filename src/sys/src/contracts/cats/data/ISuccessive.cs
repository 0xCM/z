//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an association between two types for which there exists a notion of unique succession
    /// </summary>
    /// <typeparam name="A1">The source type</typeparam>
    /// <typeparam name="A2">The type of the successor</typeparam>
    /// <remarks>
    /// Given a universe U that contain A and B, along with a strict partial order <,
    /// reification codifies that A < B
    /// </remarks>
    public interface ISuccessive<A1,A2>
    {
        /// <summary>
        /// Given an A-value, computes the next B-value
        /// </summary>
        /// <param name="a">The source value</param>
        A2 Next();
    }
}