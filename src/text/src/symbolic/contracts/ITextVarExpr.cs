//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextVarExpr
    {
        bool IsFenced {get;}

        Fence<char> Fence {get;}

        char Prefix {get;}

        bool IsPrefixed {get;}

        bool IsPrefixedFence
            => IsFenced && IsPrefixed;
        TextVarClass Class {get;}
    }    
}