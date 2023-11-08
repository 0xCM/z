//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Characterizes a finite sequence of terms
/// </summary>
/// <typeparam name="T">The term type</typeparam>
public interface ILogixSeqExpr<T> : IExpr
    where T : IEquatable<T>
{
    /// <summary>
    /// The terms in the sequence
    /// </summary>
    Index<T> Terms {get;}

    /// <summary>
    /// Sequence value accessor/manipulator
    /// </summary>
    T this[int index] {get;set;}

    /// <summary>
    /// The number of terms in the sequence
    /// </summary>
    int Length {get;}

    bool INullity.IsEmpty
        => Terms.IsEmpty;

    bool INullity.IsNonEmpty
        => Terms.IsNonEmpty;
}
