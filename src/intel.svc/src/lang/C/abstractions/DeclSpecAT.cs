//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.C;

public abstract record DeclSpec<A,T> : AstNode<A,T>
    where A : DeclSpec<A,T>
{
    public readonly string Name;

    protected DeclSpec(string name)
    {
        Name = name;
    }
}

