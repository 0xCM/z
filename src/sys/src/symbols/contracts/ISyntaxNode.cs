//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static SyntaxModels;

    public interface ISyntaxNode
    {
        NodeName Name {get;}
    }

    public interface ISyntaxNode<S> : ISyntaxNode
        where S : ISyntaxNode<S>, new()
    {
        NodeName ISyntaxNode.Name
            => name(typeof(S).Name);
    }
}