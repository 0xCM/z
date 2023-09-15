//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.C;

public record TypeDef : AstNode<TypeDef>
{
    public readonly string Defined;

    public readonly string Alias;

    public TypeDef(string defined, string alias)
    {
        Defined = default;
        Alias = alias;
    }
}


