//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an association between two types for which there
    /// exists a notion of unique antecedent
    /// </summary>
    /// <typeparam name="A1">The source type</typeparam>
    /// <typeparam name="A2">The type of the successor</typeparam>
    /// <remarks>
    /// Given a universe U that contain A and B, along with a strict partial order <,
    /// reification codifies that B < A
    /// </remarks>
    public interface IAntecedant<A1,A2>
    {
        /// <summary>
        /// Given an A-value, computes the prior B-value
        /// </summary>
        /// <param name="a">The source vlue</param>
        A2 Prior();
    }
}