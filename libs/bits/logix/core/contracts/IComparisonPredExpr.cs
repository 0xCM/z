//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a comparison expression that evaluates as a predicate where a single bit, or bitvector,
    /// characterizes the evaluation result. This is in contradistinction to the more general typed comparison expression
    /// where the result is predicated on the type and may be scalar/vector/etc in nature
    /// </summary>
    /// <typeparam name="T">The type over which the comparison is defined</typeparam>
    public interface IComparisonPredExpr<T> : IComparisonExpr<T>
    {

    }
}