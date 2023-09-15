//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.C;

public abstract record LanguageAttribute : AstNode
{
    public const string Keyword = "__attribute__";

    public abstract ReadOnlySeq<string> Operands {get;}

    public string AttributeName {get;}

    protected LanguageAttribute(string name)
    {
        AttributeName = name;
    }
}

