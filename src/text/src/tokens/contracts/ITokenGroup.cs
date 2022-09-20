//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITokenGroup
    {
        string GroupName {get;}

        uint KindCount {get;}

        uint TokenCount {get;}

        Type KindType {get;}

        Type GroupType {get;}

        ReadOnlySpan<Type> TokenTypes {get;}

        ReadOnlySeq<Token> Tokens {get;}
    }

    public interface ITokenGroup<K> : ITokenGroup
        where K : unmanaged
    {
        Type ITokenGroup.KindType
            => typeof(K);
    }
}