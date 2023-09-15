//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.C;

public abstract record AstNode : IAstNode
{

}

public abstract record AstNode<T> : AstNode, IAstNode<T>
    where T : AstNode<T>
{
    
}

public abstract record AstNode<T,A>
    where T : AstNode<T,A>
{
    
}

