//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a bidirectional association between types for which
    /// the exists notions successors and antecedants
    /// </summary>
    /// <typeparam name="A">The type that succeeds B</typeparam>
    /// <typeparam name="B">The type that precedes A</typeparam>
    public interface IAdjacency<A,B> : ISuccessive<B,A>, IAntecedant<A,B>
    {

    }
}